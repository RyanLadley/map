using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Tutorial.Models.Context;
using Tutorial.Models.Entities;

namespace Tutorial.Models.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private MainContext _context;
        
        public RegionRepository(MainContext context)
        {
            _context = context;
        }
        public void Add(Region Region)
        {
            _context.Add(Region);
            _context.SaveChanges();
        }

        public Region Get(long id)
        {
            return _context.Regions
                .Include(region => region.Locations)
                .FirstOrDefault(region => region.Id == id);
        }

        public List<Region> GetAllForState(string stateId)
        {
            return _context.Regions
                .Where(region => region.StateId == stateId).ToList();
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
