using Microsoft.EntityFrameworkCore;
using OrderManagement.Domain.Entities;
using OrderManagement.Domain.ValueObjects;

using OrderManagement.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Infrastructure.Data
{
    public static class DatabaseExtensions
    {
        public static async Task SeedProductsAsync(this AppDbContext context)
        {
            if (await context.Products.AnyAsync())
                return;

            var products = new[]
            {
            ("Beef Burger", 120, "Juicy beef patty"),
            ("Chicken Burger", 130, "Crispy chicken fillet"),
            ("Shawarma Sandwich", 65, "Middle Eastern style"),
            ("Margherita Pizza", 110, "Classic pizza"),
            ("French Fries", 30, "Crispy golden fries")
        };

            foreach (var (name, price, description) in products)
            {
                context.Products.Add(
                    new Product(name, new Money(price), description)
                );
            }

            await context.SaveChangesAsync();
        }
    }
}
