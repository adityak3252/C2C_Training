using Microsoft.EntityFrameworkCore;
using Swaad.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swaad.Models
{
    public class FoodItemRepo : IFoodItemRepo
    {
        private readonly ApplicationDbContext _applicationDbContext;

        //DI
        public FoodItemRepo(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public IEnumerable<FoodItem> AllFoodItems
        {
            get { return _applicationDbContext.FoodItems.Include(c => c.Category); }
        }

        public IEnumerable<FoodItem> TodaySpecial
        {
            get { return _applicationDbContext.FoodItems.Include(c => c.Category).Where(c => c.IsTodaySpecial == true); }
        }

        //today special is remaining
        public FoodItem GetFoodItemById(int fooditemid)
        {
            return AllFoodItems.FirstOrDefault(item => item.FoodId == fooditemid);
        }
    }
}
