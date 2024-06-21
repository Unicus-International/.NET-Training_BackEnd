using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PresentOverviewAPI.Controllers;
using PresentOverviewAPI.Controllers.Interface;
using PresentOverviewAPI.Model;
using PresentOverviewAPI.Services.dbContext;

namespace PresentOverviewAPI.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleAPIController : ControllerBase
    {
        private readonly IPeopleController _peopleController;

        public PeopleAPIController(IPeopleController peopleController)
        {
            _peopleController = peopleController;
        }

        // GET: api/People
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersons()
        {
            var personList = await _peopleController.GetPersons();
            return Ok(personList);
        }

        // GET: api/People/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            var person = await _peopleController.GetPerson(id);

            if (person == null)
            {
                return NotFound();
            }

            return person;
        }

        // PUT: api/People/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson(int id, Person person)
        {
            if (id != person.Id)
            {
                return BadRequest();
            }
            try
            {
                await _peopleController.PutPerson(id, person);
            }
            catch (Exception ex)
            {
            }
            

            return NoContent();
        }

        // POST: api/People
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson(Person person)
        {
            var newPerson = await _peopleController.PostPerson(person);

            return newPerson;
        }

        // DELETE: api/People/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var person = await _peopleController.GetPerson(id);
            if (person == null)
            {
                return NotFound();
            }

            await _peopleController.DeletePerson(person);

            return NoContent();
        }

    }
}
