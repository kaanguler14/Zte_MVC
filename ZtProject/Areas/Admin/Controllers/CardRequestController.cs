﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZtProject.DataAccess.Repository.IRepository;
using ZtProject.Models;

namespace ZtProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CardRequestController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IWebHostEnvironment _webHostEnvironment;
        public CardRequestController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Card> objRequestList = _unitOfWork.Card.GetAll(includeProperties: "BankClient").ToList();
            long a = 0;
            
            for (int i = 0; i < objRequestList.Count; i++) { 
                
                if (objRequestList[i].BankClient.Id == a)
                {
                    objRequestList.Remove(objRequestList[i]);
                }
                else
                {
                    a = objRequestList[i].BankClient.Id;
                }
            }

            return View(objRequestList);
        }



        public IActionResult Create(long ? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Card CardFromDb = _unitOfWork.Card.Get(u => u.Id == id, includeProperties: "BankClient");
            if (CardFromDb == null)
            {
                return NotFound();
            }
            

            return View(CardFromDb);
        }

        [HttpPost]
        public IActionResult Create(Card obj,IFormFile? file)
        {


            string number = GenerateRandom16DigitNumber();
            
            obj.number = number;


            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if(file != null)
                {
                    string fileName =Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string cardPath = Path.Combine(wwwRootPath,@"images\card"); 

                    using (var fileStream = new FileStream(Path.Combine(cardPath, fileName),FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    obj.ImageUrl = @"\images\card" + fileName;
                    
                }

                _unitOfWork.Card.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Category Creaeted Successfully";
                return RedirectToAction("Index");
            }

            return View();


        }

        static string GenerateRandom16DigitNumber()
        {
            // Rastgele sayı üreteceğimiz uzunluk
            int length = 16;

            // Rastgele sayı üretmek için kullanılacak karakterler
            string characters = "0123456789";

            // Rastgele sayıyı tutacak bir char dizisi oluşturun
            char[] randomArray = new char[length];

            // Rastgele sayıyı oluşturun
            Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                int index = random.Next(characters.Length);
                randomArray[i] = characters[index];
            }

            // Char dizisini birleştirip string olarak döndürün
            string randomString = new string(randomArray);

            return randomString;
        }

    }


}
