using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutorial.Models.Context;
using Tutorial.Models.Entities;

namespace Tutorial.Repositories
{
    public class StateRepository : IStateRepository
    {
        private MainContext _context;

        public StateRepository(MainContext context)
        {
            _context = context;
        }

        public void Add(State state)
        {
            _context.Add(state);
            _context.SaveChanges();
        }

        public State Get(string id)
        {
            return _context.States.FirstOrDefault(state => state.Id == id);
        }

        public List<State> GetAll()
        {
            var states = _context.States
                .Include(state => state.Regions)    
                .ToList();

            return states;
        }

        public void Remove(string id)
        {
            throw new NotImplementedException();
        }

        public void Update(string id)
        {
            throw new NotImplementedException();
        }
    }
}
