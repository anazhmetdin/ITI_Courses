﻿using Microsoft.AspNetCore.Mvc;

namespace Cars.Controllers
{
    public class Home : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
