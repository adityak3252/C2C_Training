using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swaad.Models;
using Swaad.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Swaad.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFoodItemRepo _foodItemRepo;
        //DI
        public HomeController(IFoodItemRepo foodItemRepo)
        {
            _foodItemRepo = foodItemRepo;
        }

        public IActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel
            {
                TodaysMenu = _foodItemRepo.TodaySpecial
            };
            return View(homeViewModel);
        }
    }
}
