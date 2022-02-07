using Microsoft.EntityFrameworkCore;
using OddyWeb.Model;

namespace OddyWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Category>?Categories{ get; set; }

    }
}
