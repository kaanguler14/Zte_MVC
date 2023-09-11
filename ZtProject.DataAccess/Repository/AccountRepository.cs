using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZtProject.DataAccess.Data;
using ZtProject.DataAccess.Repository.IRepository;
using ZtProject.Models;

namespace ZtProject.DataAccess.Repository
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        private ApplicationDbContext _db;
        public AccountRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

    

        public void Update(Account obj)
        {
            var objFromDb =_db.Accounts.FirstOrDefault(u => u.Id == obj.Id);

            if (objFromDb != null) {
                objFromDb.AccountBalance = obj.AccountBalance;
                objFromDb.AccountStatus = obj.AccountStatus;
                objFromDb.AccountType = obj.AccountType;
                objFromDb.OpeningDate = obj.OpeningDate;
                objFromDb.ClosingDate = obj.ClosingDate;
                objFromDb.ClientId = obj.ClientId;  
            }


          
        }
    }
}
