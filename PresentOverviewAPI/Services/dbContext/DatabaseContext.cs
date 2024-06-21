using Microsoft.EntityFrameworkCore;
using PresentOverviewAPI.Model;

namespace PresentOverviewAPI.Services.dbContext
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; } = null!;
    }
}
