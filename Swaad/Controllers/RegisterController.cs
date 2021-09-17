using Microsoft.AspNetCore.Mvc;
using Swaad.Models;
using Swaad.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swaad.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ShoppingCart _shoppingCart;
        public RegisterController(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Order order)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Checkout");
            }
            return View();
        }

        public ActionResult Checkout()
        {
            ViewBag.CheckoutMsg = "Thanks for you order. Tasty food on the way!";
            
            var checkoutViewModel = new CheckoutViewModel
            {
                shoppingCartItems = _shoppingCart.GetShoppingCartItems(),
                shoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            _shoppingCart.ClearCart();
            return View(checkoutViewModel);
        }
    }
}
