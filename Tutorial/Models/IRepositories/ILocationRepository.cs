using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutorial.Models.Entities;

namespace Tutorial.Models.IRepositories
{
    public interface ILocationRepository
    {
        void Add(Location location);
        Location Get(long id);
        List<Location> GetAll();
        void Remove(long id);
        void Update(long id);
    }
}
