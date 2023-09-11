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
    public class CardHistoryRepository : Repository<CardHistory>, ICardHistoryRepository
    {
        private ApplicationDbContext _db;
        public CardHistoryRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

    

        public void Update(CardHistory obj)
        {
            var objFromDb = _db.CardHistory.FirstOrDefault(u => u.Id == obj.Id);

            if (objFromDb != null)
            {

                objFromDb.Date = obj.Date;
                objFromDb.CardId = obj.CardId;
                objFromDb.Id = obj.Id;
                objFromDb.PlaceName = obj.PlaceName;
                objFromDb.Amount = obj.Amount;
                objFromDb.Type = obj.Type;

            }
        }
    }
}
