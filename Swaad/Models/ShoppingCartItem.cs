using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swaad.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemid { get; set; }
        public FoodItem FoodItem { get; set; }
        public int Quantity { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
