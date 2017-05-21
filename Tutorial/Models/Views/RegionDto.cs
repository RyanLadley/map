using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutorial.Models.Entities;

namespace Tutorial.Models.Views
{
    public class RegionDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }

        public string StateId { get; set; }

        public static RegionDto MapFromEntity(Region region)
        {
            var dto = new RegionDto();
            dto.Id = region.Id;
            dto.Name = region.Name;
            dto.Latitude = region.Latitude;
            dto.Longitude = region.Longitude;
            dto.StateId = region.StateId;

            return dto;
        }
    }
}
