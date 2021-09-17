using Microsoft.AspNetCore.Mvc;
using Swaad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swaad.Components
{
    public class CategoryMenu : ViewComponent
    {
        private ICategoryRepo _categoryRepo;
        //DI
        public CategoryMenu(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }
        public IViewComponentResult Invoke()
        {
            var categories = _categoryRepo.AllCategories.OrderBy(c => c.CategoryName);
            return View(categories);
        }
    }
}
