using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using ZtProject.DataAccess.Repository.IRepository;
using ZtProject.Models;
using ZtProject.Utility;

namespace ZtProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    [Authorize(Roles =SD.Role_Admin)]
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
            List<ApplicationUser> objRequestList = _unitOfWork.ApplicationUser.GetAll(u=>u.CardRequest==true).ToList();
            
            
            return View(objRequestList);
        }



          public IActionResult Create(string ? id)
            {
            ViewBag.Id = id;
         
            return View();

      
        }

        [HttpPost]
        public IActionResult Create(Card obj,string id,IFormFile? file)
        {

            
            

            string number = GenerateRandom16DigitNumber();
           
            obj.number = number;
            obj.BankClientId = id;


            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if(file != null)
                {
                    string fileName =Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string cardPath = Path.Combine(wwwRootPath,@"images\card"); 

                    if(!string.IsNullOrEmpty(obj.ImageUrl)) {
                        var oldImage = Path.Combine(wwwRootPath, obj.ImageUrl.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImage))
                        {
                            System.IO.File.Delete(oldImage);
                        }

                    }

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
