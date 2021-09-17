using Microsoft.AspNetCore.Mvc;
using Swaad.Models;
using Swaad.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swaad.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IFoodItemRepo _foodItemRepo;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(IFoodItemRepo foodItemRepo, ShoppingCart shoppingCart)
        {
            _foodItemRepo = foodItemRepo;
            _shoppingCart = shoppingCart;
        }
        public IActionResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
               
            };

            return View(shoppingCartViewModel);

        }

        public RedirectToActionResult AddToShoppingCart(int fooditemid)
        {
            var selectedFoodItem = _foodItemRepo.AllFoodItems.FirstOrDefault(p => p.FoodId == fooditemid);
            if (selectedFoodItem != null)
            {
                _shoppingCart.AddToCart(selectedFoodItem, 1);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int fooditemid)
        {
            var selectedFoodItem = _foodItemRepo.AllFoodItems.FirstOrDefault(p => p.FoodId == fooditemid);
            if (selectedFoodItem != null)
            {
                _shoppingCart.RemoveFromCart(selectedFoodItem);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult ClearShoppingCart()
        {
            _shoppingCart.ClearCart();
            return RedirectToAction("Index");
        }
    }
}
