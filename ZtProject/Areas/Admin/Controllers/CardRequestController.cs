﻿using Microsoft.AspNetCore.Mvc;

namespace ZtProject.Areas.Admin.Controllers
{
    public class CardRequestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
