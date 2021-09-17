using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swaad.Models
{
    public class Category
    {
        //Breakfast, Lunch, Snacks and Dinner
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public List<FoodItem> FoodItems { get; set; }
    }
}
