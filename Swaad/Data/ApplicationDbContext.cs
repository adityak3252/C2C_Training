using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Swaad.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Swaad.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Swaad.Models.FoodItem> FoodItems { get; set; }
        public DbSet<Swaad.Models.Category> Categories { get; set; }
        public DbSet<Swaad.Models.ShoppingCartItem> ShoppingCartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<FoodItem>().HasKey(m => m.FoodId);
            modelBuilder.Entity<Category>().HasKey(m => m.CategoryId);
            modelBuilder.Entity<FoodItem>().HasData(
                new FoodItem
                {
                    FoodId = 1,
                    FoodName = "Vadapav",
                    FoodDescription = "Mumbai Special",
                    Price = 20,
                    ImageUrl = "/Images/vadapav.png",
                    ImageThumbnailUrl = "/Images/vadapav.png",
                    IsAvailable = true,
                    IsTodaySpecial = true,
                    HasDiscount = false,
                    CategoryId = 1,
                });

            modelBuilder.Entity<FoodItem>().HasData(
                new FoodItem
                {
                    FoodId = 2,
                    FoodName = "Egg Omlet",
                    FoodDescription = "Egg Special",
                    Price = 25,
                    ImageUrl = "/Images/omlet.png",
                    ImageThumbnailUrl = "/Images/omlet.png",
                    IsAvailable = true,
                    IsTodaySpecial = true,
                    HasDiscount = false,
                    CategoryId = 2,
                });

            modelBuilder.Entity<FoodItem>().HasData(
                new FoodItem
                {
                    FoodId = 3,
                    FoodName = "Chicken Biryani",
                    FoodDescription = "Chicken Special",
                    Price = 200,
                    ImageUrl = "/Images/biryani.png",
                    ImageThumbnailUrl = "/Images/biryani.png",
                    IsAvailable = true,
                    IsTodaySpecial = true,
                    HasDiscount = false,
                    CategoryId = 3,
                });

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CategoryId=1,
                    CategoryName="Veg",
                    Description="Pure Veg"
                });

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 2,
                    CategoryName = "Egg",
                    Description = "Egg"
                });

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 3,
                    CategoryName = "NonVeg",
                    Description = "NonVeg"
                });

            //modelBuilder.Entity<ShoppingCartItem>().HasData(
            //    new ShoppingCartItem
            //    {
            //        ShoppingCartItemid = 1,
            //        FoodItem = {
            //            FoodId = 1,
            //        },
            //        Quantity = 1,
            //        ShoppingCartId = "1"
            //    });

        }
    }
}
