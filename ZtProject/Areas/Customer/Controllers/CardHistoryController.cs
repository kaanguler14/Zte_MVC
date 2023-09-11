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

        public IActionResult Index(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            List<CardHistory> CardHistoryFromDb = _unitOfWork.CardHistory.GetAll(u => u.Id == id, includeProperties: "Card").ToList();
            if (CardHistoryFromDb == null)
            {
                return NotFound();
            }

            return View(CardHistoryFromDb);
          
        
        }
    }
}
