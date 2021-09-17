using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swaad.Models
{
    public class FoodItem
    {
        public int FoodId { get; set; }
        public string FoodName { get; set; }
        public string FoodDescription { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsTodaySpecial { get; set; }
        public bool HasDiscount { get; set; }
        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
