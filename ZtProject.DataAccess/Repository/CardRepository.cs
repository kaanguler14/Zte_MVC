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
            _db.Card.Update(obj);
        }
    }
}
