using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ZtProject.DataAccess.Data;
using ZtProject.DataAccess.Repository.IRepository;
using ZtProject.Models;

namespace ZtProject.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class AccountInfoController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public AccountInfoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Account> objAccountList = _unitOfWork.Account.GetAll(includeProperties:"Client").ToList();

         


            return View(objAccountList);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Account obj)
        {




            Random rand = new Random();
            var RandomInt64 = new Random();

            string countryCode = "TR"; 
            string bankCode = rand.Next(1000, 9999).ToString(); 

            string accountNumber = RandomInt64.NextInt64(100000000000, 999999999999).ToString(); 

            string iban = GenerateIBAN(countryCode, bankCode, accountNumber);

            obj.IBAN = iban;
            obj.AccountBalance = 0;
            obj.OpeningDate = DateTime.Now;
           

            if (ModelState.IsValid)
            {
                _unitOfWork.Account.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Category Creaeted Successfully";
                return RedirectToAction("Index");
            }

            return View();


        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Account AccountFromDb = _unitOfWork.Account.Get(u => u.Id == id, includeProperties: "Client");
            if (AccountFromDb == null)
            {
                return NotFound();
            }

            return View(AccountFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Account obj)
        {


            if (ModelState.IsValid)
            {
               
                _unitOfWork.Account.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Category Updated Successfully";
                return RedirectToAction("Index");
            }

            return View();


        }



        static string GenerateIBAN(string countryCode, string bankCode, string accountNumber)
        {
            // Combine country code, bank code, and account number
            string fullNumber = bankCode + accountNumber + countryCode + "00";

            // Calculate the modulo 97 of the full number
            int modulo = 0;
            foreach (char c in fullNumber)
            {
                int digit = char.IsDigit(c) ? c - '0' : c - 'A' + 10;
                modulo = (10 * modulo + digit) % 97;
            }

            // Calculate the check digits
            int checkDigits = 98 - modulo;

            // Format the IBAN with leading zeros if necessary
            string formattedIBAN = countryCode + checkDigits.ToString("00") + bankCode + accountNumber;

            return formattedIBAN;
        }

    }
}
