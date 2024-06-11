using Microsoft.EntityFrameworkCore;

namespace PresentOverviewAPI.Model
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) 
        { 
        }

        public DbSet<Person> Persons { get; set; } = null!;
    }
}
