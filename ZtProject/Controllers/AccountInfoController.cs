using Microsoft.AspNetCore.Mvc;
using ZtProject.Data;
using ZtProject.Models;

namespace ZtProject.Controllers
{
    public class AccountInfoController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AccountInfoController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Account> objAccountList = _db.Accounts.ToList();

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
       
            string countryCode = "TR"; // Replace with the appropriate country code
            string bankCode = rand.Next(1000,9999).ToString(); // Replace with the bank code

            string accountNumber = RandomInt64.NextInt64(100000000000, 999999999999).ToString(); // Replace with the account number

            string iban = GenerateIBAN(countryCode, bankCode, accountNumber);

            obj.IBAN = iban;
            obj.AccountBalance = 0;
            obj.OpeningDate = DateTime.Now;
            obj.AccountType = "Deposit";
            obj.AccountStatus = "passive";

            if (ModelState.IsValid)
            {
                _db.Accounts.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category Creaeted Successfully";
                return RedirectToAction("Index");
            }

            return View();
          
            
        }

        public IActionResult Edit(int? id)
        {
            if (id==null || id==0) 
            {
                return NotFound();
            }

            Account AccountFromDb = _db.Accounts.Find(id);
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
                _db.Accounts.Update(obj);
                _db.SaveChanges();
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
                int digit = Char.IsDigit(c) ? (c - '0') : (c - 'A' + 10);
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
