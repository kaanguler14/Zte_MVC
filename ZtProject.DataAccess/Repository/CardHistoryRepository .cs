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
            _db.CardHistory.Update(obj);
        }
    }
}
