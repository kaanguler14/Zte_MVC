using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using ZtProject.DataAccess.Repository.IRepository;
using ZtProject.Models;
using ZtProject.Models.ViewModels;

namespace ZtProject.Areas.Customer.Controllers
{

    [Area("Customer")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _unitOfWork = _unitOfWork;
        }

        public IActionResult Index()
        {
           List<Account> Account = _unitOfWork.Account.GetAll(u=>u.ClientId == User.FindFirstValue(ClaimTypes.NameIdentifier), includeProperties:"Client").ToList();
           List<Card> Card = _unitOfWork.Card.GetAll(u=>u.BankClientId== User.FindFirstValue(ClaimTypes.NameIdentifier), includeProperties:"BankClient").ToList();

            var viewModel = new Tuple<List<Account>, List<Card>>(Account, Card);

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}