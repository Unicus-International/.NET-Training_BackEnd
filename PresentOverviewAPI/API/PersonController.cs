using Microsoft.AspNetCore.Mvc;

using PresentOverviewAPI.Model;

namespace PresentOverviewAPI.API
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        [HttpGet]
        public Person All()
        {
            return new Person { Id = 1 };
        }
    }
}
