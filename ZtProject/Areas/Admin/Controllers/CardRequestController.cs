using Microsoft.AspNetCore.Mvc;
using ZtProject.DataAccess.Repository.IRepository;
using ZtProject.Models;

namespace ZtProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CardRequestController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CardRequestController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Account> objRequestList = _unitOfWork.Account.GetAll(u=>u.Client.CardRequest==true,includeProperties: "Client").ToList();

            return View(objRequestList);
        }
    }
}
