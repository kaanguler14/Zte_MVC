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
            var objFromDb = _db.Clients.FirstOrDefault(u => u.Id == obj.Id);

            if (objFromDb != null)
            {

                objFromDb.StreetAdress = obj.StreetAdress;
                objFromDb.MailAddress = obj.MailAddress;
                objFromDb.Password = obj.Password;
                objFromDb.City = obj.City;
                objFromDb.CardRequest = obj.CardRequest;
                objFromDb.Id = obj.Id;
                objFromDb.Surname = obj.Surname;
                objFromDb.Number = obj.Number;
                objFromDb.PostalCode = obj.PostalCode;
                objFromDb.State = obj.State;
                objFromDb.StreetAdress = obj.StreetAdress;

            }
        }

      
    }
}
