using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PresentOverviewAPI.Model;

namespace PresentOverviewAPI.Controllers.Interface
{
    public interface IPeopleController
    {
        Task<IEnumerable<Person>> GetPersons();

        Task<Person> GetPerson(int id);

        Task PutPerson(int id, Person person);

        Task<Person> PostPerson(Person person);

        Task DeletePerson(Person person);
    }
}
