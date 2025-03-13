using Microsoft.AspNetCore.Mvc;
using WykladVS2022.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WykladVS2022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        // GET: api/<PersonController>
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return new Person[] {
                new Person { Id = 1, Name = "Jan", Surname= "Kowalski" },
                new Person { Id = 2, Name = "Stanisław", Surname = "Nowaka" }
                };                      
        }

        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PersonController>
        [HttpPost]
        public string Post([FromBody] string value)
        {
            return value.ToString();
        }

        // PUT api/<PersonController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
