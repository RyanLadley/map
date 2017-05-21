using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tutorial.Models.Entities;
using Tutorial.Repositories;
using Tutorial.Models.Views;

namespace Tutorial.Controllers
{
    [Route("api/states")]
    public class StatesController : Controller
    {

        IStateRepository _repository; 

        public StatesController(IStateRepository repo)
        {
            _repository = repo;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            var states = _repository.GetAll().Select(state=> StateDto.MapFromEntity(state)).ToList();
            return Ok(states);
        }

       
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var location = _repository.Get(id);
            return new ObjectResult(location);
        }

        
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
