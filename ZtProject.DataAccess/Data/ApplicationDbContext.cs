using Microsoft.EntityFrameworkCore;
using ZtProject.Models;

namespace ZtProject.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        Random random = new Random();
        public DbSet<Account> Accounts { get; set; }
        public DbSet<BankClient> Clients { get; set; }
        public DbSet<Card> Card { get; set; }
        public DbSet<CardHistory> CardHistory { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BankClient>().HasData(
                new BankClient { Id = 19722290612, Name = "Kaan", Surname = "Güler", MailAddress = "kaangulergs@gmail.com", Password = "password", Number = random.Next(1000, 9999).ToString(), StreetAdress = "Çıkınlar", City = "Bolu", State = "Center", PostalCode = "14100" }
                );

            modelBuilder.Entity<Account>().HasData(
               new Account { Id = 1, IBAN = "TR1477895786321484635789631", AccountType = "MMA", AccountBalance = 0, AccountStatus = "Passive", OpeningDate = DateTime.Now, ClosingDate =null, ClientId = 19722290612 }
               );

            modelBuilder.Entity<Card>().HasData(
               new Card { Id = 1, Name = "Bankkart", limit=10000,number = "8975050006755148", BankClientId = 19722290612 },
               new Card { Id = 2, Name = "Bankkart", limit=10000,number = "7355051246755148", BankClientId = 19722290612 }
               );
            modelBuilder.Entity<CardHistory>().HasData(
               new CardHistory { Id = 1, PlaceName = "Yemek Sepeti", Date = new DateTime(2023,8,25), Amount = 145,Type="Food",CardId=1 },
               new CardHistory { Id = 2, PlaceName = "Migros ", Date = new DateTime(2023,12,25), Amount = 200,Type="Market",CardId=2 }
               );
        }



    }
}
