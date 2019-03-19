using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CharacterService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CharacterService.Controllers
{
    private static readonly List<Character> _data = new List<Character>()
    {
        new Character {id = 1, name = "Rick"},
        new Character {id = 2, name = "Bob"}
    };

    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        // GET: api/Character
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return _data;
        }

        // GET: api/Character/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return _data[id];
        }

        // POST: api/Character
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Character/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
