using Microsoft.AspNetCore.Mvc;
using ZtProject.DataAccess.Repository.IRepository;
using ZtProject.Models;

namespace ZtProject.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CardHistoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CardHistoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<CardHistory> objCardHistoryList = _unitOfWork.CardHistory.GetAll().ToList();
            return View(objCardHistoryList);
        }
    }
}
