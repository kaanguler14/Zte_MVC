using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace ZtProject.Models.ViewModels
{
    public class AccountVM
    {
        public Account Account { get; set; }

        public IEnumerable<SelectListItem> BankClientList { get; set; }
    }
}
