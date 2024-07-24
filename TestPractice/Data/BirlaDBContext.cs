using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TestPractice.Models;

namespace TestPractice.Data
{
    public class BirlaDBContext : DbContext
    {
        public BirlaDBContext(DbContextOptions<BirlaDBContext> options):base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
      //  public DbSet<UserRole> UserRoles { get; set; }
    }
}
