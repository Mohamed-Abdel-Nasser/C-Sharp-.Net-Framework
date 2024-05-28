using System;
using System.Collections.Generic;
using System.Linq;

namespace PurchaseOrderDetailsSystem
{
    class PurchaseOrderDetailsProgram
    {
        static void Main()
        {
            Console.WriteLine("Welcome to Purchase Order Details");
            Console.WriteLine();

            try
            {
                // Create a purchase order
                PurchaseOrder purchaseOrder = new PurchaseOrder(1001, DateTime.Today);

                // Add items to the purchase order
                purchaseOrder.AddItem(new PurchaseOrderItem(101, "Office Chairs", 120.00m, 10, "Office Supplies Inc.", DateTime.Today, DateTime.Today.AddDays(7), "Warehouse A", "Pending"));
                purchaseOrder.AddItem(new PurchaseOrderItem(102, "Laptops", 1000.00m, 5, "Tech Solutions Ltd.", DateTime.Today, DateTime.Today.AddDays(14), "Warehouse B", "In Progress"));
                purchaseOrder.AddItem(new PurchaseOrderItem(103, "Desk Lamp", 30.50m, 20, "Lighting Warehouse", DateTime.Today, DateTime.Today.AddDays(3), "Warehouse C", "Delivered"));
                purchaseOrder.AddItem(new PurchaseOrderItem(104, "Computer Monitor", 300.00m, 3, "Tech Solutions Ltd.", DateTime.Today, DateTime.Today.AddDays(10), "Warehouse B", "In Progress"));
                purchaseOrder.AddItem(new PurchaseOrderItem(105, "Printer", 250.00m, 2, "Tech Solutions Ltd.", DateTime.Today, DateTime.Today.AddDays(7), "Warehouse B", "Pending"));

                // Display purchase order details
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Purchase Order ID: {purchaseOrder.OrderId}");
                Console.WriteLine($"Order Date: {purchaseOrder.OrderDate:d}");
                Console.ResetColor();
                Console.WriteLine();

                purchaseOrder.PrintOrderDetails();

            
                // Display summary statistics
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"Summary Statistics for Purchase Order ID: {purchaseOrder.OrderId}");
                purchaseOrder.PrintSummaryStatistics();
            }
            catch (ArgumentException ex)
            {
                HandleError($"Invalid input: {ex.Message}");
            }
            catch (Exception ex)
            {
                HandleError($"An unexpected error occurred: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        private static void HandleError(string errorMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error: {errorMessage}");
            Console.ResetColor();
        }
    }

    public struct PurchaseOrderItem
    {
        public int ItemId { get; }
        public string Description { get; }
        public decimal UnitPrice { get; }
        public int Quantity { get; }
        public string Supplier { get; }
        public DateTime OrderDate { get; }
        public DateTime DeliveryDate { get; }
        public string Location { get; }
        public string Status { get; }
        public decimal TotalCost => UnitPrice * Quantity; // Calculate total cost using expression-bodied property

        public PurchaseOrderItem(int itemId, string description, decimal unitPrice, int quantity,
                                 string supplier, DateTime orderDate, DateTime deliveryDate,
                                 string location, string status)
        {
            ValidateInput(itemId, description, unitPrice, quantity);

            ItemId = itemId;
            Description = description;
            UnitPrice = unitPrice;
            Quantity = quantity;
            Supplier = supplier;
            OrderDate = orderDate;
            DeliveryDate = deliveryDate;
            Location = location;
            Status = status;
        }

        private static void ValidateInput(int itemId, string description, decimal unitPrice, int quantity)
        {
            if (itemId <= 0)
            {
                throw new ArgumentException("Item ID must be a positive integer.", nameof(itemId));
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException("Description cannot be empty or null.", nameof(description));
            }

            if (unitPrice <= 0)
            {
                throw new ArgumentException("Unit price must be greater than zero.", nameof(unitPrice));
            }

            if (quantity <= 0)
            {
                throw new ArgumentException("Quantity must be a positive integer.", nameof(quantity));
            }
        }

        public void PrintItemDetails()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"   →Item ID: {ItemId}");
            Console.ResetColor();
            Console.WriteLine($"   →Description: {Description}");
            Console.WriteLine($"   →Unit Price: {UnitPrice:C}"); // Format unit price as currency
            Console.WriteLine($"   →Quantity: {Quantity}");
            Console.WriteLine($"   →Total Cost: {TotalCost:C}"); // Format total cost as currency
            Console.WriteLine($"   →Supplier: {Supplier}");
            Console.WriteLine($"   →Order Date: {OrderDate:d}"); // Short date format
            Console.WriteLine($"   →Delivery Date: {DeliveryDate:d}"); // Short date format
            Console.WriteLine($"   →Location: {Location}");
            Console.WriteLine($"   →Status: {Status}");
            Console.WriteLine("".PadRight(30, '='));
            
        }
    }

    public class PurchaseOrder
    {
        public int OrderId { get; }
        public DateTime OrderDate { get; }
        public List<PurchaseOrderItem> Items { get; }

        public PurchaseOrder(int orderId, DateTime orderDate)
        {
            OrderId = orderId;
            OrderDate = orderDate;
            Items = new List<PurchaseOrderItem>();
        }

        public void AddItem(PurchaseOrderItem item)
        {
            Items.Add(item);
        }

        public void PrintOrderDetails()
        {
            foreach (var item in Items)
            {
                item.PrintItemDetails();
            }
        }

        public void PrintItemsByStatus(string status)
        {
            var filteredItems = Items.Where(item => item.Status.Equals(status, StringComparison.OrdinalIgnoreCase)).ToList();

            foreach (var item in filteredItems)
            {
                item.PrintItemDetails();
            }
        }

        public void PrintSummaryStatistics()
        {
            Console.WriteLine($"    →Total Items: {Items.Count}");
            Console.WriteLine($"    →Total Cost: {Items.Sum(item => item.TotalCost):C}");
            Console.WriteLine($"    →Order Deadline : {Items.Min(item => item.OrderDate):d}");
            Console.WriteLine($"    →Order Delivery Date: {Items.Max(item => item.DeliveryDate):d}");
        }
    }
}
