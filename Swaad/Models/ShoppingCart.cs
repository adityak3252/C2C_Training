using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Swaad.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swaad.Models
{
    public class ShoppingCart
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public string ShoppingCartId { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public ShoppingCart(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        //GetCart/AddtoCart/RemoveFromcart/GetShoppingitems/clear cart/gettotal

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<ApplicationDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);
            return new ShoppingCart(context) { ShoppingCartId = cartId };

        }

        public void AddToCart(FoodItem fooditem, int quantity)
        {
            var shoppingCartItem =
                _applicationDbContext.ShoppingCartItems.SingleOrDefault(
                    s => s.FoodItem.FoodId == fooditem.FoodId && s.ShoppingCartId == ShoppingCartId);
            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    FoodItem = fooditem,
                    Quantity = 1
                };
                _applicationDbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Quantity++;
            }
            _applicationDbContext.SaveChanges();
        }


        public int RemoveFromCart(FoodItem fooditem)
        {

            var shoppingCartItem =
                _applicationDbContext.ShoppingCartItems.SingleOrDefault(
                    s => s.FoodItem.FoodId == fooditem.FoodId && s.ShoppingCartId == ShoppingCartId);
            var localamount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Quantity > 1)
                {
                    shoppingCartItem.Quantity--;
                    localamount = shoppingCartItem.Quantity;
                }
                else
                {
                    _applicationDbContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }
            _applicationDbContext.SaveChanges();

            return localamount;
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??=
                _applicationDbContext.ShoppingCartItems.Where(c => ShoppingCartId == ShoppingCartId)
                .Include(s => s.FoodItem)
                .ToList();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = _applicationDbContext.ShoppingCartItems.Where(c => ShoppingCartId == ShoppingCartId)
                .Select(c => c.FoodItem.Price * c.Quantity).Sum();
            return total;
        }

        public void ClearCart()
        {
            var rows = from o in _applicationDbContext.ShoppingCartItems select o;
            foreach (var row in rows)
            {
                _applicationDbContext.ShoppingCartItems.Remove(row);
            }
            _applicationDbContext.SaveChanges();
        }
    }
}
