using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PurchaseOrderModel
{
    class PurchaseOrderModel
    {
        static void Main()
        {
            // Initialize the purchase order service
            var orderService = new PurchaseOrderService();

            // Display menu for user interaction
            while (true)
            {
                Console.Clear(); // Clear the console for a clean interface
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("===== Purchase Order Management System =====");
                Console.ResetColor();
                Console.WriteLine("1. Add a New Purchase Order");
                Console.WriteLine("2. Display All Purchase Orders");
                Console.WriteLine("3. Exit");
                Console.WriteLine("=================================");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("Enter your choice: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("===== Add a New Purchase Order =====");
                            Console.ResetColor();
                            try
                            {
                                var newOrder = ReadNewOrderDetails();
                                orderService.AddPurchaseOrder(newOrder);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Purchase Order added successfully!");
                            }
                            catch (Exception ex)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            finally
                            {
                                Console.ResetColor();
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                            }
                            break;
                        case 2:
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("===== All Purchase Orders =====");
                            Console.ResetColor();
                            orderService.DisplayPurchaseOrders();
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            break;
                        case 3:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Exiting...");
                            Console.ResetColor();
                            Environment.Exit(0);
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid choice. Please try again.");
                            Console.ResetColor();
                            break;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter a valid choice.");
                    Console.ResetColor();
                }

                Console.WriteLine(); // Add spacing for readability
            }
        }

        // Method to read new purchase order details from user input
        private static PurchaseOrder ReadNewOrderDetails()
        {
            Console.Write("Enter Order ID: ");
            int orderNumber = int.Parse(Console.ReadLine());
            Console.Write("Enter Product Name: ");
            string productName = Console.ReadLine();
            Console.Write("Enter Unit Price: ");
            decimal unitPrice = decimal.Parse(Console.ReadLine());
            Console.Write("Enter Quantity: ");
            int quantity = int.Parse(Console.ReadLine());
            Console.Write("Enter Currency: ");
            string currency = Console.ReadLine();
            Console.Write("Enter Order Deadline (dd/MM/yyyy): ");
            DateTime orderDeadline = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
            Console.Write("Enter Expected Arrival (dd/MM/yyyy): ");
            DateTime expectedArrival = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
            Console.Write("Enter Taxes (%): ");
            decimal taxes = decimal.Parse(Console.ReadLine());
            Console.Write("Enter Unit of Measure: ");
            string unitOfMeasure = Console.ReadLine();
            Console.Write("Enter Discount Percentage (%): ");
            decimal discountPercentage = decimal.Parse(Console.ReadLine());

            return new PurchaseOrder(orderNumber, productName, unitPrice, quantity, currency,
                                     orderDeadline, expectedArrival, taxes, unitOfMeasure, discountPercentage);
        }
    }

    // Interface defining the contract for a purchase order
    public interface IPurchaseOrder
    {
        int OrderNumber { get; }
        string ProductName { get; }
        decimal UnitPrice { get; }
        int Quantity { get; }
        string Currency { get; }
        DateTime OrderDeadline { get; }
        DateTime ExpectedArrival { get; }
        decimal Taxes { get; }
        string UnitOfMeasure { get; }
        decimal DiscountPercentage { get; }
        decimal TotalAmount { get; }
        string GetOrderDetails();
    }

    // Struct representing a purchase order
    public struct PurchaseOrder : IPurchaseOrder
    {
        public int OrderNumber { get; }
        public string ProductName { get; }
        public decimal UnitPrice { get; }
        public int Quantity { get; }
        public string Currency { get; }
        public DateTime OrderDeadline { get; }
        public DateTime ExpectedArrival { get; }
        public decimal Taxes { get; }
        public string UnitOfMeasure { get; }
        public decimal DiscountPercentage { get; }

        public PurchaseOrder(int orderNumber, string productName, decimal unitPrice, int quantity,
                             string currency, DateTime orderDeadline, DateTime expectedArrival,
                             decimal taxes, string unitOfMeasure, decimal discountPercentage)
        {
            if (orderNumber <= 0)
                throw new ArgumentOutOfRangeException(nameof(orderNumber), "Order ID must be positive.");

            if (unitPrice <= 0)
                throw new ArgumentOutOfRangeException(nameof(unitPrice), "Unit price must be positive.");

            if (quantity <= 0)
                throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be positive.");

            OrderNumber = orderNumber;
            ProductName = productName ?? throw new ArgumentNullException(nameof(productName));
            UnitPrice = unitPrice;
            Quantity = quantity;
            Currency = currency ?? throw new ArgumentNullException(nameof(currency));
            OrderDeadline = orderDeadline;
            ExpectedArrival = expectedArrival;
            Taxes = taxes;
            UnitOfMeasure = unitOfMeasure ?? throw new ArgumentNullException(nameof(unitOfMeasure));
            DiscountPercentage = discountPercentage;
        }

        public decimal TotalAmount
        {
            get
            {
                decimal totalPrice = UnitPrice * Quantity;
                decimal totalPriceWithTaxes = totalPrice + (totalPrice * Taxes / 100);
                decimal discountedPrice = totalPriceWithTaxes - (totalPriceWithTaxes * DiscountPercentage / 100);
                return discountedPrice;
            }
        }

        public string GetOrderDetails()
        {
            return $"   → Order ID: {OrderNumber}\n" +
                   $"   → Product Name: {ProductName}\n" +
                   $"   → Unit Price: {UnitPrice:C}\n" +
                   $"   → Quantity: {Quantity}\n" +
                   $"   → Currency: {Currency}\n" +
                   $"   → Order Deadline: {OrderDeadline:dd/MM/yyyy}\n" +
                   $"   → Expected Arrival: {ExpectedArrival:dd/MM/yyyy}\n" +
                   $"   → Taxes: {Taxes}%\n" +
                   $"   → Unit of Measure: {UnitOfMeasure}\n" +
                   $"   → Discount Percentage: {DiscountPercentage}%\n" +
                   $"   → Total Amount: {TotalAmount:C}";
        }
    }

    // Service for managing purchase orders
    public class PurchaseOrderService
    {
        private List<PurchaseOrder> _purchaseOrders;
        private const string DataFilePath = "purchase_orders.txt";

        public PurchaseOrderService()
        {
            _purchaseOrders = new List<PurchaseOrder>();
            LoadPurchaseOrdersFromFile();
        }

        // Add a new purchase order
        public void AddPurchaseOrder(PurchaseOrder order)
        {
            _purchaseOrders.Add(order);
            SavePurchaseOrdersToFile();
        }

        // Display all purchase orders
        public void DisplayPurchaseOrders()
        {
            if (_purchaseOrders.Count == 0)
            {
                Console.WriteLine("No purchase orders to display.");
                return;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var order in _purchaseOrders)
            {
                Console.WriteLine(order.GetOrderDetails());
                Console.WriteLine("----------------");
            }

            // Calculate and display total amount for all orders
            decimal totalAmount = _purchaseOrders.Sum(order => order.TotalAmount);
            Console.WriteLine($"Total Amount for all orders: {totalAmount:C}");
            Console.ResetColor();
        }

        // Save purchase orders to file
        private void SavePurchaseOrdersToFile()
        {
            using (StreamWriter writer = new StreamWriter(DataFilePath))
            {
                foreach (var order in _purchaseOrders)
                {
                    writer.WriteLine($"{order.OrderNumber},{order.ProductName},{order.UnitPrice},{order.Quantity}," +
                                     $"{order.Currency},{order.OrderDeadline},{order.ExpectedArrival}," +
                                     $"{order.Taxes},{order.UnitOfMeasure},{order.DiscountPercentage}");
                }
            }
        }

        // Load purchase orders from file
        private void LoadPurchaseOrdersFromFile()
        {
            if (File.Exists(DataFilePath))
            {
                _purchaseOrders.Clear();

                using (StreamReader reader = new StreamReader(DataFilePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length == 10 &&
                            int.TryParse(parts[0], out int orderNumber) &&
                            decimal.TryParse(parts[2], out decimal unitPrice) &&
                            int.TryParse(parts[3], out int quantity) &&
                            DateTime.TryParseExact(parts[5], "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime orderDeadline) &&
                            DateTime.TryParseExact(parts[6], "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime expectedArrival) &&
                            decimal.TryParse(parts[8], out decimal taxes) &&
                            decimal.TryParse(parts[9], out decimal discountPercentage))
                        {
                            string productName = parts[1];
                            string currency = parts[4];
                            string unitOfMeasure = parts[7];
                            _purchaseOrders.Add(new PurchaseOrder(orderNumber, productName, unitPrice, quantity,
                                                                  currency, orderDeadline, expectedArrival,
                                                                  taxes, unitOfMeasure, discountPercentage));
                        }
                    }
                }
            }
        }
    }
}
