using Microsoft.EntityFrameworkCore;
using RetailInventory.Data;
using RetailInventory.Models;

namespace RetailInventory
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using var context = new AppDbContext();

            // Insert data only if the database is empty
            if (!await context.Categories.AnyAsync())
            {
                // Create Categories
                var electronics = new Category
                {
                    Name = "Electronics"
                };

                var groceries = new Category
                {
                    Name = "Groceries"
                };

                await context.Categories.AddRangeAsync(electronics, groceries);

                // Create Products
                var product1 = new Product
                {
                    Name = "Smartphone",
                    Price = 45000,
                    Category = electronics
                };

                var product2 = new Product
                {
                    Name = "Wireless Headphones",
                    Price = 3500,
                    Category = electronics
                };

                var product3 = new Product
                {
                    Name = "Cooking Oil (5L)",
                    Price = 900,
                    Category = groceries
                };

                var product4 = new Product
                {
                    Name = "Basmati Rice (10kg)",
                    Price = 1500,
                    Category = groceries
                };

                await context.Products.AddRangeAsync(
                    product1,
                    product2,
                    product3,
                    product4);

                await context.SaveChangesAsync();

                Console.WriteLine("Data inserted successfully!\n");
            }

            // Retrieve all products
            Console.WriteLine("===== All Products =====");

            var products = await context.Products.ToListAsync();

            foreach (var p in products)
            {
                Console.WriteLine($"ID       : {p.Id}");
                Console.WriteLine($"Name     : {p.Name}");
                Console.WriteLine($"Price    : ₹{p.Price:N0}");
                Console.WriteLine();
            }

            // Find product by ID
            Console.WriteLine("===== Find Product (ID = 1) =====");

            var product = await context.Products.FindAsync(1);

            if (product != null)
            {
                Console.WriteLine($"Found Product : {product.Name}");
                Console.WriteLine($"Price         : ₹{product.Price:N0}");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }

            Console.WriteLine();

            // Find first expensive product
            Console.WriteLine("===== First Product with Price > ₹40000 =====");

            var expensive = await context.Products
                                         .FirstOrDefaultAsync(p => p.Price > 40000);

            if (expensive != null)
            {
                Console.WriteLine($"Product : {expensive.Name}");
                Console.WriteLine($"Price   : ₹{expensive.Price:N0}");
            }
            else
            {
                Console.WriteLine("No expensive product found.");
            }

            Console.WriteLine("\nProgram completed successfully.");
            Console.ReadKey();
        }
    }
}