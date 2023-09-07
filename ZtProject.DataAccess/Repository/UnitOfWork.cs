using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZtProject.DataAccess.Data;
using ZtProject.DataAccess.Repository.IRepository;

namespace ZtProject.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IAccountRepository Account { get; private set; }
        private ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db) 
        {
            _db = db;
            Account = new AccountRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
