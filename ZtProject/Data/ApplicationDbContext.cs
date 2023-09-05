using Microsoft.EntityFrameworkCore;
using ZtProject.Models;

namespace ZtProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Account> Accounts { get; set; }

      

    }
}
