using System.Collections.Generic;
using Tutorial.Models.Entities;

namespace Tutorial.Repositories
{
    public interface IStateRepository
    {
        void Add(State state);
        State Get(string id);
        List<State> GetAll();
        void Remove(string id);
        void Update(string id);
    }
}
