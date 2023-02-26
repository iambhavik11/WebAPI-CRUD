using Fullstack_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Fullstack_API.Data
{
    // Inject it in Program.cs / Startup.cs before build with Connection string
    public class FullstackDbContext : DbContext
    {
        public FullstackDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
