using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


using PresentOverviewAPI.Model;
using PresentOverviewAPI.Controllers.Interface;
using PresentOverviewAPI.Services.dbContext;

namespace PresentOverviewAPI.Controllers
{
    public class PeopleController : IPeopleController
    {
        private readonly DatabaseContext _context;
        public PeopleController(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Person>> GetPersons()
        {
            return await _context.Persons.ToListAsync();
        }

        public async Task<Person> GetPerson(int id)
        {
            var person = await _context.Persons.FindAsync(id);

            return person;
        }

        public async Task PutPerson(int id, Person person)
        {

            _context.Entry(person).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
                {
                    throw new Exception();
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<Person> PostPerson(Person person)
        {
            _context.Persons.Add(person);
            await _context.SaveChangesAsync();

            return person;
        }

        public async Task DeletePerson(Person person)
        {
            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();
        }

        private bool PersonExists(int id)
        {
            return _context.Persons.Any(e => e.Id == id);
        }
    }
}
