using System;
using System.Collections.Generic;
using System.Linq;

namespace POSAppModel
{
    class POSAppProgram
    {
        static void Main(string[] args)
        {
            Inventory inventory = new Inventory();
            Cart cart = new Cart();

            // Add initial products to inventory
            inventory.AddProduct(new Product("Laptop", 999.99m, 5));
            inventory.AddProduct(new Product("Mouse", 29.99m, 10));
            inventory.AddProduct(new Product("Keyboard", 49.99m, 8));

            while (true)
            {
                Console.Clear(); // Clear console before displaying menu
                Console.WriteLine("Welcome to the Point of Sale (POS) System");
                Console.WriteLine("=======================================");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("1. Manage Products");
                Console.WriteLine("2. Process Sales");
                Console.WriteLine("3. Generate Reports");
                Console.WriteLine("4. Exit");
                Console.ResetColor();
                Console.WriteLine("======================");
                Console.Write("Enter option: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1": // Manage Products
                        Console.Clear();
                        ManageProducts(inventory);
                        break;

                    case "2": // Process Sales
                        Console.Clear();
                        ProcessSales(cart, inventory);
                        break;

                    case "3": // Generate Reports
                        Console.Clear();
                        Console.WriteLine("Generating Reports:");
                        // Placeholder logic for generating reports
                        break;

                    case "4": // Exit
                        Console.WriteLine("Exiting...");
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        static void ManageProducts(Inventory inventory)
        {
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. View Products");
            Console.WriteLine("3. Update Product");
            Console.WriteLine("4. Remove Product");
            Console.Write("Enter option: ");
            string manageProductOption = Console.ReadLine();
            switch (manageProductOption)
            {
                case "1": // Add Product
                    Console.Clear();
                    AddProductToInventory(inventory);
                    break;

                case "2": // View Products
                    Console.Clear();
                    DisplayInventory(inventory);
                    break;

                case "3": // Update Product
                    Console.Clear();
                    UpdateProductInInventory(inventory);
                    break;

                case "4": // Remove Product
                    Console.Clear();
                    RemoveProductFromInventory(inventory);
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }

        static void AddProductToInventory(Inventory inventory)
        {
            Console.Write("Enter product name: ");
            string productName = Console.ReadLine();
            Console.Write("Enter product price: ");
            decimal productPrice;
            while (!decimal.TryParse(Console.ReadLine(), out productPrice) || productPrice <= 0)
            {
                Console.WriteLine("Invalid price. Please enter a valid positive number.");
            }
            Console.Write("Enter product quantity: ");
            int productQuantity;
            while (!int.TryParse(Console.ReadLine(), out productQuantity) || productQuantity <= 0)
            {
                Console.WriteLine("Invalid quantity. Please enter a valid positive integer.");
            }
            inventory.AddProduct(new Product(productName, productPrice, productQuantity));
            Console.WriteLine("Product added successfully.");
        }

        static void UpdateProductInInventory(Inventory inventory)
        {
            Console.Write("Enter product name to update: ");
            string productToUpdate = Console.ReadLine();
            Console.Write("Enter new price: ");
            decimal newPrice;
            while (!decimal.TryParse(Console.ReadLine(), out newPrice) || newPrice <= 0)
            {
                Console.WriteLine("Invalid price. Please enter a valid positive number.");
            }
            Console.Write("Enter new quantity: ");
            int newQuantity;
            while (!int.TryParse(Console.ReadLine(), out newQuantity) || newQuantity <= 0)
            {
                Console.WriteLine("Invalid quantity. Please enter a valid positive integer.");
            }
            inventory.UpdateProduct(productToUpdate, newPrice, newQuantity);
            Console.WriteLine("Product updated successfully.");
        }

        static void RemoveProductFromInventory(Inventory inventory)
        {
            Console.Write("Enter product name to remove: ");
            string productToRemove = Console.ReadLine();
            inventory.RemoveProduct(productToRemove);
            Console.WriteLine("Product removed successfully.");
        }

        static void ProcessSales(Cart cart, Inventory inventory)
        {
            Console.WriteLine("1. Add Product to Cart");
            Console.WriteLine("2. View Cart");
            Console.WriteLine("3. Checkout");
            Console.Write("Enter option: ");
            string processSalesOption = Console.ReadLine();
            switch (processSalesOption)
            {
                case "1": // Add Product to Cart
                    Console.Clear();
                    AddProductToCart(cart, inventory);
                    break;

                case "2": // View Cart
                    Console.Clear();
                    cart.GenerateReceipt();
                    break;

                case "3": // Checkout
                    Console.Clear();
                    Checkout(cart);
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }

        static void AddProductToCart(Cart cart, Inventory inventory)
        {
            Console.Write("Enter product name to add to cart: ");
            string productToAddToCart = Console.ReadLine();
            Product product = inventory.FindProductByName(productToAddToCart);
            if (product != null)
            {
                cart.AddItem(product);
                Console.WriteLine("Product added to cart.");
            }
            else
            {
                Console.WriteLine("Product not found in inventory.");
            }
        }

        static void Checkout(Cart cart)
        {
            Console.WriteLine("Processing payment...");
            cart.GenerateReceipt();
            cart.ClearCart();
            Console.WriteLine("Payment processed successfully.");
        }

        static void DisplayInventory(Inventory inventory)
        {
            Console.WriteLine("Current Inventory:");
            if (inventory.Products.Any())
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("{0,-20} {1,-10} {2,-10}", "Name", "Price ($)", "Quantity");
                Console.ResetColor();
                foreach (var product in inventory.Products)
                {
                    Console.WriteLine("{0,-20} {1,-10:C} {2,-10}", product.Name, product.Price, product.Quantity);
                }
            }
            else
            {
                Console.WriteLine("Inventory is empty.");
            }
        }
    }

    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public Product(string name, decimal price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }
    }

    public class Inventory
    {
        public List<Product> Products { get; private set; }

        public Inventory()
        {
            Products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
            Console.WriteLine($"Product '{product.Name}' added to inventory.");
        }

        public void UpdateProduct(string productName, decimal newPrice, int newQuantity)
        {
            Product productToUpdate = FindProductByName(productName);
            if (productToUpdate != null)
            {
                productToUpdate.Price = newPrice;
                productToUpdate.Quantity = newQuantity;
                Console.WriteLine($"Product '{productName}' updated successfully.");
            }
            else
            {
                Console.WriteLine($"Product '{productName}' not found in inventory.");
            }
        }

        public void RemoveProduct(string productName)
        {
            Product productToRemove = FindProductByName(productName);
            if (productToRemove != null)
            {
                Products.Remove(productToRemove);
                Console.WriteLine($"Product '{productName}' removed from inventory.");
            }
            else
            {
                Console.WriteLine($"Product '{productName}' not found in inventory.");
            }
        }

        public Product FindProductByName(string productName)
        {
            return Products.FirstOrDefault(p => string.Equals(p.Name, productName, StringComparison.OrdinalIgnoreCase));
        }
    }

    public class Cart
    {
        private List<Product> items;

        public Cart()
        {
            items = new List<Product>();
        }

        public void AddItem(Product product)
        {
            items.Add(product);
            Console.WriteLine($"Product '{product.Name}' added to cart.");
        }

        public void GenerateReceipt()
        {
            Console.WriteLine("----- Receipt -----");
            if (items.Any())
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("{0,-20} {1,-10} {2,-10}", "Name", "Price ($)", "Quantity");
                foreach (var item in items)
                {
                    Console.WriteLine("{0,-20} {1,-10:C} {2,-10}", item.Name, item.Price, 1);
                }
                Console.WriteLine("-------------------");
                Console.WriteLine($"Total: {CalculateTotal():C}");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("Cart is empty. No receipt generated.");
            }
        }

        public decimal CalculateTotal()
        {
            return items.Sum(item => item.Price);
        }

        public void ClearCart()
        {
            items.Clear();
            Console.WriteLine("Cart cleared.");
        }
    }

}
