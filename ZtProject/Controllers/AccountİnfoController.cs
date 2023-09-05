using Microsoft.AspNetCore.Mvc;
using ZtProject.Data;
using ZtProject.Models;

namespace ZtProject.Controllers
{
    public class AccountİnfoController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AccountİnfoController(ApplicationDbContext db)
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
        public IActionResult Create(Category obj)
        {
            _db.Accounts.Add(obj);  
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
