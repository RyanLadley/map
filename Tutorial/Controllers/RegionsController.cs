using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tutorial.Models.Repositories;
using Tutorial.Models.Views;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tutorial.Controllers
{
    [Route("api/states/{stateId}/regions")]
    public class RegionsController : Controller
    {
        IRegionRepository _repository;

        public RegionsController(IRegionRepository repo)
        {
            _repository = repo;
        }

        [HttpGet]
        public IActionResult GetRegionsForState(string stateId)
        {
            var regions = _repository.GetAllForState(stateId).Select(region => RegionDetailsDto.MapFromEntity(region)).ToList();
            return Ok(regions);
        }

        [HttpGet("{id}")]
        public IActionResult GetRegion(long id)
        {
            var region = _repository.Get(id);
            var regionDto = RegionDetailsDto.MapFromEntity(region);
            return Ok(regionDto);
        }
    }
}
