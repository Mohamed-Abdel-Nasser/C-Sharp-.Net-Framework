using System;
using System.Collections.Generic;
using System.Linq;

namespace InventoryManagementSystem
{
    class InventoryManagementProgram
    {
        static void Main()
        {
            // Create inventory and add products
            ProductsManager.Inventory inventory = new ProductsManager.Inventory();
            inventory.AddProduct(new ProductsManager.Product("Laptop", "Electronics", 1200, 10));
            inventory.AddProduct(new ProductsManager.Product("T-shirt", "Apparel", 25, 50));

            // Display initial inventory
            Console.WriteLine("=== Initial Inventory ===");
            inventory.DisplayInventory();

            // Perform sales operations
            ProductsManager.Sales sales = new ProductsManager.Sales(inventory);
            sales.PerformSale("Laptop", 2);
            sales.PerformSale("T-shirt", 20);

            // Display updated inventory after sales
            Console.WriteLine("\n=== Updated Inventory After Sales ===");
            inventory.DisplayInventory();

            // Generate and display inventory and sales reports
            Console.WriteLine("\n=== Inventory Report ===");
            ProductsManager.Reporting reporting = new ProductsManager.Reporting(inventory);
            reporting.GenerateInventoryReport();

            Console.WriteLine("\n=== Sales Report ===");
            reporting.GenerateSalesReport();
            Console.ReadKey();
        }
    }

    public class ProductsManager
    {
        // Nested class representing a Product
        public class Product
        {
            public string Name { get; private set; }
            public string Category { get; private set; }
            public decimal Price { get; private set; }
            public int Quantity { get; set; }

            public Product(string name, string category, decimal price, int quantity)
            {
                Name = name;
                Category = category;
                Price = price;
                Quantity = quantity;
            }

            public void DisplayInfo()
            {
                Console.WriteLine($"Product: {Name}, Category: {Category}, Price: {Price:C}, Quantity: {Quantity}");
            }
        }

        // Nested class representing an Inventory
        public class Inventory
        {
            private List<Product> products;

            public Inventory()
            {
                products = new List<Product>();
            }

            public void AddProduct(Product product)
            {
                products.Add(product);
            }

            public void DisplayInventory()
            {
                if (products.Any())
                {
                    Console.WriteLine("Product Name    Category    Price       Quantity");
                    Console.WriteLine("--------------------------------------------------");
                    foreach (var product in products)
                    {
                        Console.WriteLine($"{product.Name,-15} {product.Category,-11} {product.Price,-11:C} {product.Quantity,-10}");
                    }
                }
                else
                {
                    Console.WriteLine("No products in inventory.");
                }
            }

            public bool SellProduct(string productName, int quantity)
            {
                Product product = products.FirstOrDefault(p => p.Name.Equals(productName, StringComparison.OrdinalIgnoreCase));
                if (product != null && product.Quantity >= quantity)
                {
                    product.Quantity -= quantity;
                    Console.WriteLine($"Sold {quantity} units of {product.Name} for {product.Price * quantity:C}");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Insufficient quantity of '{productName}' in inventory.");
                    return false;
                }
            }
        }

        // Nested class representing Sales
        public class Sales
        {
            private Inventory inventory;

            public Sales(Inventory inventory)
            {
                this.inventory = inventory;
            }

            public void PerformSale(string productName, int quantity)
            {
                inventory.SellProduct(productName, quantity);
            }
        }

        // Nested class representing Reporting functionalities
        public class Reporting
        {
            private Inventory inventory;

            public Reporting(Inventory inventory)
            {
                this.inventory = inventory;
            }

            public void GenerateInventoryReport()
            {
                inventory.DisplayInventory();
            }

            public void GenerateSalesReport()
            {
                // Placeholder for more advanced reporting (e.g., sales history, revenue analysis)
                Console.WriteLine("Sales report functionality to be implemented.");
            }
        }
    }
}
