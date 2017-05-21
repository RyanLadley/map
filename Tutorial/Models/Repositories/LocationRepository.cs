using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutorial.Models.Context;
using Tutorial.Models.Entities;
using Tutorial.Models.IRepositories;

namespace Tutorial.Models.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private MainContext _context;
        public LocationRepository(MainContext context)
        {
            _context = context;
        }
        public void Add(Location location)
        {
            throw new NotImplementedException();
        }

        public Location Get(long id)
        {
            return _context.Locations.FirstOrDefault(location => location.Id == id);
        }

        public List<Location> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(long id)
        {
            throw new NotImplementedException();
        }

        public void Update(long id)
        {
            throw new NotImplementedException();
        }
    }
}
