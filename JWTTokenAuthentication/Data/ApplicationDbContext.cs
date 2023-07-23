using JWTTokenAuthentication.Models;
using Microsoft.EntityFrameworkCore;

namespace JWTTokenAuthentication.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        public DbSet<Users> users { get; set; }
    }
}
