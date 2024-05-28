using System;
using System.Collections.Generic;
namespace ProductManagementSystem
{
    class ProductManagementProgram
    {
        static void Main()
        {
            List<Product> products = new List<Product>();

            bool exit = false;
            while (!exit)
            {
                Console.Clear(); // Clear console for better readability
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("=== Product Management System ===");
                Console.ResetColor();
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. View Products");
                Console.WriteLine("3. Delete Product");
                Console.WriteLine("4. Exit");
                Console.WriteLine("==============================");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        AddProduct(products);
                        break;

                    case "2":
                        ViewProducts(products);
                        break;

                    case "3":
                        DeleteProduct(products);
                        break;

                    case "4":
                        exit = true;
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Exiting Product Management System.");
                        Console.ResetColor();
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Invalid option. Please try again.\n");
                        Console.ResetColor();
                        break;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey(true);
            }
        }

        static void AddProduct(List<Product> products)
        {
            Product newProduct = new Product();

            Console.Write("Name: ");
            newProduct.Name = Console.ReadLine();

            Console.Write("Description: ");
            newProduct.Description = Console.ReadLine();

            Console.Write("Internal Reference: ");
            newProduct.InternalReference = Console.ReadLine();

            Console.Write("Sale Price: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal salePrice))
                newProduct.SalePrice = salePrice;

            Console.Write("Cost Price: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal costPrice))
                newProduct.CostPrice = costPrice;

            Console.Write("Taxes: ");
            newProduct.Taxes = Console.ReadLine();

            Console.Write("Category: ");
            newProduct.Category = Console.ReadLine();

            Console.Write("Brand: ");
            newProduct.Brand = Console.ReadLine();

            Console.Write("On hand quantity: ");
            if (int.TryParse(Console.ReadLine(), out int onHandQuantity))
                newProduct.OnHandQuantity = onHandQuantity;

            Console.Write("Variants (e.g., size, color): ");
            newProduct.Variants = Console.ReadLine();

            Console.Write("Purchase Units of Measure: ");
            newProduct.PurchaseUnitsOfMeasure = Console.ReadLine();

            Console.Write("Sales Units of Measure: ");
            newProduct.SalesUnitsOfMeasure = Console.ReadLine();

            Console.Write("Product Type (Storable, Consumable, Service): ");
            newProduct.ProductType = Console.ReadLine();

            Console.Write("Invoicing Policy (Ordered Quantities, Delivered Quantities): ");
            newProduct.InvoicingPolicy = Console.ReadLine();

            products.Add(newProduct);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nProduct '{newProduct.Name}' added.\n");
            Console.ResetColor();
        }

        static void ViewProducts(List<Product> products)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("=== Products List ===\n");

            for (int i = 0; i < products.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Product {i + 1}: {products[i].Name}");
                Console.ResetColor();
                Console.WriteLine($"Description: {products[i].Description}");
                Console.WriteLine($"Internal Reference: {products[i].InternalReference}");
                Console.WriteLine($"Sale Price: {products[i].SalePrice:C}"); // Format as currency
                Console.WriteLine($"Cost Price: {products[i].CostPrice:C}"); // Format as currency
                Console.WriteLine($"Taxes: {products[i].Taxes}");
                Console.WriteLine($"Category: {products[i].Category}");
                Console.WriteLine($"Brand: {products[i].Brand}");
                Console.WriteLine($"On hand quantity: {products[i].OnHandQuantity}");
                Console.WriteLine($"Variants: {products[i].Variants}");
                Console.WriteLine($"Purchase Units of Measure: {products[i].PurchaseUnitsOfMeasure}");
                Console.WriteLine($"Sales Units of Measure: {products[i].SalesUnitsOfMeasure}");
                Console.WriteLine($"Product Type: {products[i].ProductType}");
                Console.WriteLine($"Invoicing Policy: {products[i].InvoicingPolicy}");
                Console.WriteLine(new string('-', 40)); // Separator between products
            }

            Console.ResetColor();
            Console.WriteLine();
        }

        static void DeleteProduct(List<Product> products)
        {
            ViewProducts(products); // Display products for selection

            Console.Write("Enter the number of the product to delete: ");
            if (int.TryParse(Console.ReadLine(), out int indexToDelete))
            {
                indexToDelete--; // Convert to zero-based index

                if (indexToDelete >= 0 && indexToDelete < products.Count)
                {
                    string deletedProductName = products[indexToDelete].Name;
                    products.RemoveAt(indexToDelete);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\nProduct '{deletedProductName}' deleted.\n");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Invalid product number.\n");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Invalid input. Please enter a valid product number.\n");
                Console.ResetColor();
            }
        }
    }
    class Product
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string InternalReference { get; set; }
        public decimal SalePrice { get; set; }
        public decimal CostPrice { get; set; }
        public string Taxes { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public int OnHandQuantity { get; set; }
        public string Variants { get; set; }
        public string PurchaseUnitsOfMeasure { get; set; }
        public string SalesUnitsOfMeasure { get; set; }
        public string ProductType { get; set; }
        public string InvoicingPolicy { get; set; }
    }


}
