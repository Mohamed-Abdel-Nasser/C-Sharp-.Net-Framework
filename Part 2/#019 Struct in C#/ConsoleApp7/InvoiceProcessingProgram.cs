using System;
using System.Collections.Generic;
namespace InvoiceProcessingSystem
{
    class InvoiceProcessingProgram
    {
        static void Main()
        {
            try
            {
                // Initialize a list to store line items
                var lineItems = new List<InvoiceLineItem>();

                // Prompt user to enter invoice details
                Console.WriteLine("Enter invoice details:");

                Console.Write("Invoice Number: ");
                int invoiceNumber = int.Parse(Console.ReadLine());

                Console.Write("Invoice Date (yyyy-MM-dd): ");
                DateTime invoiceDate = DateTime.Parse(Console.ReadLine());

                Console.Write("Customer Name: ");
                string customerName = Console.ReadLine();

                while (true)
                {
                    Console.WriteLine("\nEnter line item details (press Enter to finish adding):");

                    Console.Write("Product: ");
                    string product = Console.ReadLine().Trim();
                    if (string.IsNullOrWhiteSpace(product))
                        break;

                    Console.Write("Label: ");
                    string label = Console.ReadLine().Trim();

                    Console.Write("Analytic Distribution: ");
                    string analyticDistribution = Console.ReadLine().Trim();

                    Console.Write("Account: ");
                    string account = Console.ReadLine().Trim();

                    Console.Write("Currency: ");
                    string productCountry = Console.ReadLine().Trim();

                    Console.Write("Quantity: ");
                    int quantity = int.Parse(Console.ReadLine());

                    Console.Write("Unit of Measure (UoM): ");
                    string uom = Console.ReadLine().Trim();

                    Console.Write("Discount Percentage (%): ");
                    decimal discountPercentage = decimal.Parse(Console.ReadLine());

                    Console.Write("Taxes: ");
                    string taxes = Console.ReadLine().Trim();

                    Console.Write("Unit Price: ");
                    decimal unitPrice = decimal.Parse(Console.ReadLine());

                    var lineItem = new InvoiceLineItem(product, label, analyticDistribution, account, productCountry,
                                                       quantity, uom, discountPercentage, taxes, unitPrice);
                    lineItems.Add(lineItem);
                }

                // Create an invoice with the collected data
                var invoice = new Invoice(invoiceNumber, invoiceDate, customerName, lineItems);

                // Print detailed invoice
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n   =========  INVOICE DETAILS  =========");
                invoice.PrintDetailedInvoice();
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format. Please enter a valid number.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }

    public struct Invoice
    {
        public int InvoiceNumber { get; }
        public DateTime InvoiceDate { get; }
        public string CustomerName { get; }
        public List<InvoiceLineItem> LineItems { get; }

        public Invoice(int invoiceNumber, DateTime invoiceDate, string customerName, List<InvoiceLineItem> lineItems)
        {
            if (invoiceNumber <= 0)
                throw new ArgumentException("Invoice number must be a positive integer.", nameof(invoiceNumber));

            if (string.IsNullOrWhiteSpace(customerName))
                throw new ArgumentException("Customer name cannot be null or empty.", nameof(customerName));

            if (lineItems == null || lineItems.Count == 0)
                throw new ArgumentException("Invoice must contain at least one line item.", nameof(lineItems));

            InvoiceNumber = invoiceNumber;
            InvoiceDate = invoiceDate;
            CustomerName = customerName;
            LineItems = lineItems;
        }

        // Method to calculate the total amount from line items
        public decimal CalculateTotalAmount()
        {
            decimal total = 0;
            foreach (var item in LineItems)
            {
                total += item.Quantity * item.UnitPrice;
            }
            return total;
        }

        // Method to display detailed invoice including line items in list view with colors
        public void PrintDetailedInvoice()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("===========================================");
            Console.WriteLine($"Invoice Number: {InvoiceNumber}");
            Console.WriteLine($"Date: {InvoiceDate:d}");
            Console.WriteLine($"Customer: {CustomerName}");
            Console.WriteLine("===========================================");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Line Items:");
            foreach (var item in LineItems)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine($"    →Product:                   ||{item.Product}");
                Console.WriteLine($"    →Label:                     ||{item.Label}");
                Console.WriteLine($"    →Analytic Distribution:     ||{item.AnalyticDistribution}");
                Console.WriteLine($"    →Account:                   ||{item.Account}");
                Console.WriteLine($"    →Currency:                  ||{item.ProductCountry}");
                Console.WriteLine($"    →Quantity:                  ||{item.Quantity}");
                Console.WriteLine($"    →Unit of Measure (UoM):     ||{item.UoM}");
                Console.WriteLine($"    →Discount Percentage (%):   ||{item.DiscountPercentage}");
                Console.WriteLine($"    →Taxes:                     ||{item.Taxes}");
                Console.WriteLine($"    →Unit Price:                ||{item.UnitPrice:C}");
                Console.WriteLine($"    →Total:                     ||{item.Quantity * item.UnitPrice:C}");
                Console.WriteLine("--------------------------------------------------");

            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("===========================================");
            Console.WriteLine($"Total Amount: {CalculateTotalAmount():C}");
            Console.WriteLine("===========================================");

            // Reset console color
            Console.ResetColor();
        }
    }

    public class InvoiceLineItem
    {
        public string Product { get; }
        public string Label { get; }
        public string AnalyticDistribution { get; }
        public string Account { get; }
        public string ProductCountry { get; }
        public int Quantity { get; }
        public string UoM { get; }
        public decimal DiscountPercentage { get; }
        public string Taxes { get; }
        public decimal UnitPrice { get; }

        public InvoiceLineItem(string product, string label, string analyticDistribution, string account, string productCountry,
            int quantity, string uom, decimal discountPercentage, string taxes, decimal unitPrice)
        {
            if (string.IsNullOrWhiteSpace(product))
                throw new ArgumentException("Product name cannot be null or empty.", nameof(product));

            Product = product;
            Label = label;
            AnalyticDistribution = analyticDistribution;
            Account = account;
            ProductCountry = productCountry;
            Quantity = quantity;
            UoM = uom;
            DiscountPercentage = discountPercentage;
            Taxes = taxes;
            UnitPrice = unitPrice;
        }
    }
}
