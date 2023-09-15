using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZtProject.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IAccountRepository Account { get; }
        ICardRepository Card { get; }
        ICardHistoryRepository CardHistory { get; }

        IBankClientRepository BankClient { get; }
        IApplicationUser ApplicationUser { get; }
  

        void Save();

    }
}
