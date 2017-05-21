using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tutorial.Models.Entities
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string Thumbnail { get; set; }

        public long RegionId { get; set; }
        public virtual Region Region { get; set; }
    }
}
