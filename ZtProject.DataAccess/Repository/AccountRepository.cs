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
            _db.Accounts.Update(obj);
        }
    }
}
