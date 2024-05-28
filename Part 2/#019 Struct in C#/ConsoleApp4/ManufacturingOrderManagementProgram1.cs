using System;
using System.Collections.Generic;

namespace ManufacturingOrderManagementSystem1
{
    class ManufacturingOrderManagementProgram1
    {
        static void Main()
        {
            try
            {
                // Create manufacturing orders
                ManufacturingOrder order1 = new ManufacturingOrder(1001, DateTime.Today, "Widget A", 500);
                ManufacturingOrder order2 = new ManufacturingOrder(1002, DateTime.Today, "Gadget B", 300);

                // Display initial order details
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("=== Initial Manufacturing Orders ===");
                Console.ResetColor();
                DisplayManufacturingOrderDetails(order1);
                DisplayManufacturingOrderDetails(order2);

                // Start production for orders
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n=== Starting Production ===");
                Console.ResetColor();
                order1.StartProduction();
                order2.StartProduction();

                // Complete production for order1
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n=== Completing Production for Order 1 ===");
                Console.ResetColor();
                order1.CompleteProduction();

                // Display updated order details
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n=== Updated Manufacturing Orders ===");
                Console.ResetColor();
                DisplayManufacturingOrderDetails(order1);
                DisplayManufacturingOrderDetails(order2);
            }
            catch (ArgumentException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error creating manufacturing order: {ex.Message}");
                Console.ResetColor();
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        static void DisplayManufacturingOrderDetails(ManufacturingOrder order)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"Order ID: {order.OrderId}");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Order Date: {order.OrderDate:d}");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Product Name: {order.ProductName}");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Quantity: {order.Quantity}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Status: {order.Status}");
            Console.ResetColor();
            Console.WriteLine();
        }
    }

    public enum ManufacturingStatus
    {
        Pending,
        InProgress,
        Completed,
        Cancelled
    }

    public struct ManufacturingOrder
    {
        public int OrderId { get; }
        public DateTime OrderDate { get; }
        public string ProductName { get; }
        public int Quantity { get; }
        public ManufacturingStatus Status { get; set; }

        public ManufacturingOrder(int orderId, DateTime orderDate, string productName, int quantity)
        {
            if (orderId <= 0)
                throw new ArgumentException("Order ID must be positive.", nameof(orderId));

            if (string.IsNullOrWhiteSpace(productName))
                throw new ArgumentException("Product name cannot be empty or null.", nameof(productName));

            if (quantity <= 0)
                throw new ArgumentException("Quantity must be positive.", nameof(quantity));

            OrderId = orderId;
            OrderDate = orderDate;
            ProductName = productName;
            Quantity = quantity;
            Status = ManufacturingStatus.Pending;
        }

        public void StartProduction()
        {
            Status = ManufacturingStatus.InProgress;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Manufacturing order {OrderId} for {ProductName} started.");
            Console.ResetColor();
        }

        public void CompleteProduction()
        {
            Status = ManufacturingStatus.Completed;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Manufacturing order {OrderId} for {ProductName} completed.");
            Console.ResetColor();
        }

        public override string ToString()
        {
            return $"Order ID: {OrderId}, Product: {ProductName}, Quantity: {Quantity}, Status: {Status}";
        }
    }
}
