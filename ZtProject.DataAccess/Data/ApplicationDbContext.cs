using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ZtProject.Models;

namespace ZtProject.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        Random random = new Random();
        public DbSet<Account> Accounts { get; set; }
        public DbSet<BankClient> Clients { get; set; }
        public DbSet<Card> Card { get; set; }
        public DbSet<CardHistory> CardHistory { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
      
     



    }
}
