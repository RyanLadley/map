using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutorial.Models.Entities;

namespace Tutorial.Models.Views
{
    public class RegionDetailsDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }

        public string StateId { get; set; }
        public ICollection<LocationDto> Locations { get; set; }


        public static RegionDetailsDto MapFromEntity(Region region)
        {
            var dto = new RegionDetailsDto();
            dto.Id = region.Id;
            dto.Name = region.Name;
            dto.Latitude = region.Latitude;
            dto.Longitude = region.Longitude;
            dto.StateId = region.StateId;

            dto.Locations = region.Locations.Select(location => LocationDto.MapFromEntity(location)).ToList();
            
            return dto;
        }
    }
}
