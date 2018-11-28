using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using xs.demos.backend.models;

namespace xs.demos.backend.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        // GET: api/Person
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return new List<Person>() { new Person(), new Person() };
        }

        // GET: api/Person/5
        [HttpGet("{id}", Name = "Get")]
        public Person Get(int id)
        {
            return new Person();
        }

        // POST: api/Person
        [HttpPost]
        public void Post([FromBody] Person value)
        {
        }

        // PUT: api/Person/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Person value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
