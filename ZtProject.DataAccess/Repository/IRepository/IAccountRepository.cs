using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZtProject.Models;

namespace ZtProject.DataAccess.Repository.IRepository
{
    public interface IAccountRepository :IRepository<Account>
    {
        void Update(Account obj);


    }
}
