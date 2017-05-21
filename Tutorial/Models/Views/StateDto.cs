using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutorial.Models.Entities;

namespace Tutorial.Models.Views
{
    public class StateDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public ICollection<RegionDto> Regions { get; set; }

        public static StateDto MapFromEntity(State state)
        {
            var dto = new StateDto();
            dto.Id = state.Id;
            dto.Name = state.Name;
            dto.Regions = state.Regions.Select(region => RegionDto.MapFromEntity(region)).ToList();

            return dto;
        }
    }
}
