using Microsoft.EntityFrameworkCore;
using ZtProject.Models;

namespace ZtProject.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<BankClient> Clients { get; set; }

      

    }
}
