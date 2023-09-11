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
    public class CardRepository : Repository<Card>, ICardRepository
    {
        private ApplicationDbContext _db;
        public CardRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

    

        public void Update(Card obj)
        {
            var objFromDb = _db.Card.FirstOrDefault(u => u.Id == obj.Id);

          if (objFromDb != null) {

                objFromDb.number = obj.number;
                objFromDb.BankClientId = obj.BankClientId;
                objFromDb.limit = obj.limit;
                objFromDb.Id = obj.Id;
                objFromDb.Name = obj.Name;
             
            }
        }
    }
}
