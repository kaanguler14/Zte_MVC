using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using ZtProject.DataAccess.Data;
using ZtProject.DataAccess.Repository.IRepository;
using ZtProject.Models;

namespace ZtProject.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class CardController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CardController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Card> objCardList = _unitOfWork.Card.GetAll(u=>u.BankClientId == User.FindFirstValue(ClaimTypes.NameIdentifier), includeProperties: "BankClient").ToList();

            return View(objCardList);
        }
        public IActionResult Details()
        {
            List<Card> objCardHistoryList = _unitOfWork.Card.GetAll(includeProperties:"BankClient").ToList();

            return View(objCardHistoryList);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Card obj)
        {




            Random rand = new Random();
            var RandomInt64 = new Random();

            
            string bankCode = rand.Next(1000, 9999).ToString(); // Replace with the bank code

            string accountNumber = RandomInt64.NextInt64(100000000000, 999999999999).ToString(); // Replace with the account number

            string number = GenerateNumber(bankCode, accountNumber);

            obj.number = number;

            obj.BankClientId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (ModelState.IsValid)
            {
                _unitOfWork.Card.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Thanks for Card Request";
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

            Card CardFromDb = _unitOfWork.Card.Get(u => u.Id == id);
            if (CardFromDb == null)
            {
                return NotFound();
            }

            return View(CardFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Card obj)
        {


            if (ModelState.IsValid)
            {
                _unitOfWork.Card.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Category Updated Successfully";
                return RedirectToAction("Index");
            }

            return View();


        }
        public IActionResult CardRequest()
        {
            string a =User.FindFirstValue(ClaimTypes.NameIdentifier);
            Console.WriteLine(a);
            ApplicationUser ClientFromDb = _unitOfWork.ApplicationUser.Get(u => u.Id == User.FindFirstValue(ClaimTypes.NameIdentifier));
            if(ClientFromDb == null)
            {
                return NotFound();
            }

            return View(ClientFromDb);
        }

        [HttpPost]
        public IActionResult CardRequest(ApplicationUser obj)
        {
            obj.CardRequest =true;

            if (ModelState.IsValid)
            {
                _unitOfWork.ApplicationUser.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Category Updated Successfully";
                return RedirectToAction("Index");
            }

            return View();


        }

        public IActionResult ChangeValue(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Account CardFromDb = _unitOfWork.Account.Get(u => u.Id == id, includeProperties: "Client");
            if (CardFromDb == null)
            {
                return NotFound();
            }
            CardFromDb.Client.CardRequest = true;

            return View(Index);
        }

        [HttpPost]
        public IActionResult ChangeValue(Card obj)
        {
            obj.BankClient.CardRequest =true;

            if (ModelState.IsValid)
            {

                _unitOfWork.Card.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Category Updated Successfully";
                return RedirectToAction("Index");
            }

            return View("Index");


        }


        static string GenerateNumber( string bankCode, string accountNumber)
        {
            // Combine country code, bank code, and account number
            string fullNumber = bankCode + accountNumber+ "00";

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
            string formattedNumber = checkDigits.ToString("00") + bankCode + accountNumber;

            return formattedNumber;
        }

    }
}
