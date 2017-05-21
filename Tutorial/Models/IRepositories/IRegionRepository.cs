using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutorial.Models.Entities;

namespace Tutorial.Models.Repositories
{
    public interface IRegionRepository 
    {
        void Add(Region region);
        Region Get(long id);
        List<Region> GetAllForState(string stateId);
        void Remove(long id);
        void Update(long id);
    }
}
