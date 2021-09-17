using Swaad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swaad.ViewModels
{
    public class CheckoutViewModel
    {
        public List<ShoppingCartItem> shoppingCartItems;
        public decimal shoppingCartTotal { get; set; }
    }
}
