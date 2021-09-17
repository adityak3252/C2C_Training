using Microsoft.AspNetCore.Mvc;
using Swaad.Models;
using Swaad.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swaad.Controllers
{
    public class FoodItemController : Controller
    {
        private readonly IFoodItemRepo _foodItemRepo;
        private readonly ICategoryRepo _categoryRepo;

        //DI

        public FoodItemController(IFoodItemRepo foodItemRepo, ICategoryRepo categoryRepo)
        {
            _foodItemRepo = foodItemRepo;
            _categoryRepo = categoryRepo;
        }

        public IActionResult Index(string FoodSearch)
        {
            ViewData["GetFoodItems"] = FoodSearch;
            var query = _foodItemRepo.AllFoodItems;
            if(!String.IsNullOrEmpty(FoodSearch))
            {
                query = query.Where(x => x.FoodName.Contains(FoodSearch) || x.FoodDescription.Contains(FoodSearch));
            }
            var foodListViewModel = new FoodListViewModel
            {
                FoodItems = query.ToList(),
                CurrentCategory = ""
            };
            return View(foodListViewModel);
        }
        public IActionResult CategoryFilter(string category)
        {
            IEnumerable<FoodItem> fooditems;
            string currentcategory;

            if (string.IsNullOrEmpty(category))
            {
                fooditems = _foodItemRepo.AllFoodItems.OrderBy(f => f.FoodId);
                currentcategory = "all food dishes";
            }
            else
            {
                fooditems = _foodItemRepo.AllFoodItems.Where(f => f.Category.CategoryName == category).OrderBy(f => f.FoodId);
                currentcategory = _categoryRepo.AllCategories.FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
            }
            return View(new FoodListViewModel { FoodItems = fooditems, CurrentCategory = currentcategory });
        }

        public IActionResult Details(int id)
        {
            var fooditem = _foodItemRepo.GetFoodItemById(id);
            if (fooditem == null)
            {
                return NotFound();
            }
            return View(fooditem);
        }
    }
}
