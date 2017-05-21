using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tutorial.Models.Entities
{
    public class State
    {
        public State()
        {
            Regions = new List<Region>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public ICollection<Region>  Regions { get; set; }
    }
}
