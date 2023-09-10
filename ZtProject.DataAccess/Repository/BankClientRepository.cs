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
    internal class BankClientRepository : Repository<BankClient>, IBankClientRepository
    {
        private ApplicationDbContext _db;
        public BankClientRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }



        public void Update(BankClient obj)
        {
            _db.Clients.Update(obj);
        }

      
    }
}
