using Microsoft.EntityFrameworkCore;
using MyAccount.Models;
namespace MyAccount.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<RegisterVM> Accounts { get; set; }
        public DbSet<StudentProfile> StudentProfiles { get; set; }
    }
}
