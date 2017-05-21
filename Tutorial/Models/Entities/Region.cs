using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tutorial.Models.Entities
{
    public class Region
    {

        public long Id { get; set; }
        public string Name { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }

        public string StateId { get; set; }
        public virtual State State { get; set; }

        public ICollection<Location> Locations { get; set; }


        public Region()
        {
            Locations = new List<Location>();
        }
    }
}
