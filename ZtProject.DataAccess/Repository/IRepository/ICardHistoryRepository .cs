using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZtProject.Models;

namespace ZtProject.DataAccess.Repository.IRepository
{
    public interface ICardHistoryRepository :IRepository<CardHistory>
    {
        void Update(CardHistory obj);


    }
}
