app.controller('homeController', ['$scope', '$location', 'getRequest', function ($scope, $location, getRequest) {
    var activeStateColor = "#569A68";
    var defaultStateColor = "B1BEE6"

    getRequest.request('/api/states').then(function (response) {
        $scope.states = response.data;
    });

    $scope.height = 600;
    $scope.width = 1100;

    var map = new Datamap({
        element: document.getElementById('datamap'),
        scope: 'usa',
        height: $scope.height,
        width: $scope.width,

        geographyConfig: {
            //highlighBorderColor: '#EAA9A8',
            //highlighBorderWidth: 2,
            borderWidth: 2,
            highlightOnHover: false,
            popupOnHover: false
        },

        fills: {
            'bubbles': '#E18282',
            'selected': '#569A68',
            'defaultFill': defaultStateColor
        },

        done: function (datamap) {
            datamap.svg.selectAll('.datamaps-subunit').on('mouseenter', function (geography) {
                /*var stateId = geography.id;
                var fillkey = {}
                fillkey[stateId] = {
                    fillKey: 'selected'
                };
                //datamap.updateChoropleth(fillkey);
                //console.log(geography);*/
            })
                .on('click', function (geography) {
                    initBubbles(geography.id);
                    zoomMap(datamap, geography);
                });
        }
    });

    var initBubbles = function (stateId) {
        map.bubbles(stateRegions(stateId), {
            popupTemplate: function (geography, data) {
                return ['<div class="hoverinfo"><strong>' + data.name + '</strong></div>'].join('');
            }
        });
        
        map.svg.selectAll('.datamaps-bubble').on("click", function (region) {
            var newPath = "/states/" + region.stateId + "/regions/" + region.id;
            console.log(newPath)
            $location.path(newPath);
            $scope.$apply()
        })
    }

    
    //Help from https://bl.ocks.org/mbostock/2206590
    var centered = null; //Centered outisde of center function to allow deselect
    var zoomMap = function (datamap, geography) {
        var x, y, k;
        
        var g = datamap.svg.selectAll('.datamaps-subunit')
        g.style("fill", defaultStateColor);
        var bubbles = datamap.svg.selectAll('.datamaps-bubble');

        if (centered === geography) { 
            return resetZoom(datamap, g, bubbles); 
        }
        centered = geography
        datamap.svg.select("." + geography.id).style("fill", activeStateColor); //Must happen after transitions

        var width = $scope.width;
        var height = $scope.height;
        
        var projection = d3.geo.albersUsa()
            .scale(1070)
            .translate([width / 2, height / 2]);

        var path = d3.geo.path()
            .projection(projection);

        var bounds = path.bounds(geography),
            dx = bounds[1][0] - bounds[0][0],
            dy = bounds[1][1] - bounds[0][1],
            x = (bounds[0][0] + bounds[1][0]) / 2,
            y = (bounds[0][1] + bounds[1][1]) / 2,
            scale = .9 / Math.max(dx / width, dy / height),
            translate = [width / 2 - scale * x, height / 2 - scale * y];
        
        bubbles.style("display", "None");
        g.transition()
            .duration(750)
            .style("stroke-width", 1.5 / scale + "px")
            .attr("transform", "translate(" + translate + ")scale(" + scale + ")")
            .call(endTransitions, function () {
                bubbles.transition()
                    .style("stroke-width", 1.5 / scale + "px")
                    .attr("transform", "translate(" + translate + ")scale(" + scale + ")")
                    .style("display", "Block");
            });
        
    };


    var resetZoom = function (datamap, g, bubbles) {
        centered = null;

        g.transition()
            .duration(750)
            .style("stroke-width", "1.5px")
            .attr("transform", "");
            
        map.bubbles([], {});
    }

    var endTransitions = function (transition, callback) {
        if (transition.size() === 0) { callback() }
        var n = 0;
        transition
            .each(function () { ++n; })
            .each("end", function () { if (!--n) callback(); });
    };

    var stateRegions = function (id) {
        for (var i = 0; i < $scope.states.length; i++) {
            if ($scope.states[i].id == id) {
                var regions = $scope.states[i].regions;
                regions = appendRegions(regions);
                return regions;
            }
        }
        console.log("There was a problem obtaining the regions for " + id);
        return "Error";
    }

    var appendRegions = function (regions) {
        for (var i = 0; i < regions.length; i++) {
            regions[i].radius = 2;
            regions[i].fillKey = 'bubbles';
        }
        return regions;
    }
}]);

app.controller('regionsController', ['$scope', '$routeParams', 'getRequest', function ($scope, $routeParams, getRequest) {
    //Google maps api key  AIzaSyB5OcHLGGPAamonx9H9MTUUmSS4RcArIQ4 
    $scope.map = { center: { latitude: 0, longitude: 0 }}
    getRequest.request('/api/states/' + $routeParams.stateId + '/regions/' + $routeParams.regionId).then(function (response) {
        $scope.region = response.data;
        $scope.map = { center: { latitude: $scope.region.latitude, longitude: $scope.region.longitude }};
    });

    var currentModel = null;
    $scope.onClick = function (marker, eventName, model) {
        //Check that the selected model and the click model are not the same
        //Also check that the currentModel has been initilised
        if (currentModel != model && currentModel) currentModel.show = false;
        currentModel = model;
        model.show = !model.show;
    };
}]);