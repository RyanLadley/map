using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutorial.Models.Entities;

namespace Tutorial.Models.Views
{
    public class LocationDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string Thumbnail { get; set; }

        public long RegionId { get; set; }

        public static LocationDto MapFromEntity(Location location)
        {
            var dto = new LocationDto();
            dto.Id = location.Id;
            dto.Name = location.Name;
            dto.Latitude = location.Latitude;
            dto.Longitude = location.Longitude;
            dto.RegionId = location.RegionId;
            dto.Thumbnail = location.Thumbnail;

            return dto;
        }
    }
}
