using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CharacterRestService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CharacterRestService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private static readonly List<Character> _data = new List<Character>()
        {
            new Character { Id = 1, Name = "Nick" },
            new Character { Id = 2, Name = "Fred" },
        };

        // GET: api/Character
        [HttpGet]
        [ProducesResponseType(typeof(Character), StatusCodes.Status200OK)]
        public IEnumerable<Character> Get()
        {
            return _data;
            // whenever an action method returns something that's not an IActionResult
            // ... it's auto wrapped in 200 OK res
        }

        // Nick did some fast recode with naming routes with rename in method and then edit accordingly 
        // wasnt able to follow
        [HttpGet("{id}", Name = "GetById")]
        [ProducesResponseType(typeof(Character), StatusCodes.Status200OK)]
        public ActionResult<Character> Get(int id)
        {
            if (_data.FirstOrDefault(x => x.Id == id) is var character)
            {
                return character;
            }
            return NotFound();
        }

        // return types should generally be IActionResult or some subtype of that,
        // or ActionResult<type-of-data-in-body>

        // POST: api/Character
        [HttpPost]
        [ProducesResponseType(typeof(Character), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Character), StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody, Bind("Name")] Character character)
        {
            // some overposting vulnerability here... I do not want client to be able to set ID.
            // either  I can make sure to ignore that value if he sends it
            // or can explicitly not bind it
            var newId = _data.Max(x => x.Id) + 1;
            character.Id = newId;
            _data.Add(character);

            return CreatedAtRoute("GetById", new { id = newId }, character);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Character), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Character), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Character), StatusCodes.Status400BadRequest)]
        public IActionResult Put(int id, [FromBody, Bind("Name")] Character character)
        {
            // implementation choice, whether PUT on nonexistent res is successful or error
            if (_data.FirstOrDefault(x => x.Id == id) is var existing)
            {
                existing.Name = character.Name;
                return NoContent(); // 204
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Character), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Character), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            if (_data.FirstOrDefault(x => x.Id == id) is var existing)
            {
                _data.Remove(existing);
                return NoContent(); // 204
            }
            return NotFound();
        }
    }
}
