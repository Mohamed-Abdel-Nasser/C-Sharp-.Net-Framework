using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PurchaseOrderModel
{
    class PurchaseOrderModel
    {
        static void Main()
        {
            // Initialize the purchase order service
            var orderService = new PurchaseOrderService();

            // Subscribe to the PurchaseOrderAdded event
            orderService.PurchaseOrderAdded += (sender, e) =>
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"New Purchase Order added: Order ID {e.AddedOrder.OrderNumber}");
                Console.ResetColor();
            };

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

            Console.Write("Select Currency (EGP,USD, EUR, GBP, JPY, AUD): ");
            Enum.TryParse(Console.ReadLine(), out CurrencyType currency);

            Console.Write("Select Unit of Measure (Piece, Kg, Liter, Box, Set): ");
            Enum.TryParse(Console.ReadLine(), out UnitOfMeasure unitOfMeasure);

            Console.Write("Enter Order Deadline (dd/MM/yyyy): ");
            DateTime orderDeadline = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

            Console.Write("Enter Expected Arrival (dd/MM/yyyy): ");
            DateTime expectedArrival = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

            Console.Write("Enter Taxes (%): ");
            decimal taxes = decimal.Parse(Console.ReadLine());

            Console.Write("Enter Discount Percentage (%): ");
            decimal discountPercentage = decimal.Parse(Console.ReadLine());

            return new PurchaseOrder(orderNumber, productName,
                                     unitPrice, quantity, currency,
                                     orderDeadline, expectedArrival,
                                     taxes, unitOfMeasure, discountPercentage);
        }
    }
    public enum CurrencyType
    {
        EGP,
        USD,
        EUR,
        GBP,
        JPY,
        AUD
    }
    public enum UnitOfMeasure
    {
        Piece,
        Kg,
        Liter,
        Box,
        Set
    }
    public interface IPurchaseOrder
    {
        int OrderNumber { get; }
        int Quantity { get; }
        DateTime OrderDeadline { get; }
        DateTime ExpectedArrival { get; }
        decimal UnitPrice { get; }
        decimal Taxes { get; }
        decimal DiscountPercentage { get; }
        decimal TotalAmount { get; }
        string ProductName { get; }
        CurrencyType Currency { get; }
        UnitOfMeasure UnitOfMeasure { get; }
        string GetOrderDetails();
    }
    public struct PurchaseOrder : IPurchaseOrder
    {
        public int OrderNumber { get; }
        public string ProductName { get; }
        public decimal UnitPrice { get; }
        public int Quantity { get; }
        public CurrencyType Currency { get; }
        public DateTime OrderDeadline { get; }
        public DateTime ExpectedArrival { get; }
        public decimal Taxes { get; }
        public UnitOfMeasure UnitOfMeasure { get; }
        public decimal DiscountPercentage { get; }

        // Constants for tax and discount calculation
        private const decimal TaxPercentage = 5.0m;
        private const decimal MaxDiscountPercentage = 20.0m;

        // Constructor with field initialization
        public PurchaseOrder(int orderNumber, string productName, decimal unitPrice, int quantity,
                             CurrencyType currency, DateTime orderDeadline, DateTime expectedArrival,
                             decimal taxes, UnitOfMeasure unitOfMeasure, decimal discountPercentage)
        {
            if (orderNumber <= 0)
                throw new ArgumentOutOfRangeException(nameof(orderNumber), "Order ID must be positive.");

            if (unitPrice <= 0)
                throw new ArgumentOutOfRangeException(nameof(unitPrice), "Unit price must be positive.");

            if (quantity <= 0)
                throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be positive.");

            this.OrderNumber = orderNumber;
            this.ProductName = productName ?? throw new ArgumentNullException(nameof(productName));
            this.UnitPrice = unitPrice;
            this.Quantity = quantity;
            this.Currency = currency;
            this.OrderDeadline = orderDeadline;
            this.ExpectedArrival = expectedArrival;
            this.Taxes = taxes;
            this.UnitOfMeasure = unitOfMeasure;
            this.DiscountPercentage = discountPercentage;
        }

        // Method to calculate total amount including taxes and discounts
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

        // Method to get order details as formatted string
        //public string GetOrderDetails()
        //{
        //    return $"   → Order ID: {OrderNumber}\n" +
        //           $"   → Product Name: {ProductName}\n" +
        //           $"   → Unit Price: {UnitPrice:C}\n" +
        //           $"   → Quantity: {Quantity}\n" +
        //           $"   → Currency: {Currency}\n" +
        //           $"   → Order Deadline: {OrderDeadline:dd/MM/yyyy}\n" +
        //           $"   → Expected Arrival: {ExpectedArrival:dd/MM/yyyy}\n" +
        //           $"   → Taxes: {Taxes}%\n" +
        //           $"   → Unit of Measure: {UnitOfMeasure}\n" +
        //           $"   → Discount Percentage: {DiscountPercentage}%\n" +
        //           $"   → Total Amount: {TotalAmount:C}";
        //}

        public string GetOrderDetails()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("   ╔═════════════════════════════════════════════════════╗");
            sb.AppendLine($"   ║  {"Order Details",-30}");
            sb.AppendLine($"   ║  {"    → Order ID:",-30}{OrderNumber}");
            sb.AppendLine($"   ║  {"    → Product Name:",-30}{ProductName,-3}");
            sb.AppendLine($"   ║  {"    → Unit Price:",-30}{UnitPrice:C}");
            sb.AppendLine($"   ║  {"    → Quantity:",-30}{Quantity}");
            sb.AppendLine($"   ║  {"    → Currency:",-30}{Currency}");
            sb.AppendLine($"   ║  {"    → Order Deadline:",-30}{OrderDeadline:dd/MM/yyyy}");
            sb.AppendLine($"   ║  {"    → Expected Arrival:",-30}{ExpectedArrival:dd/MM/yyyy}");
            sb.AppendLine($"   ║  {"    → Taxes:",-30}{Taxes}%");
            sb.AppendLine($"   ║  {"    → Unit of Measure:",-30}{UnitOfMeasure}");
            sb.AppendLine($"   ║  {"    → Discount Percentage:",-30}{DiscountPercentage}%");
            sb.AppendLine($"   ║  {"    → Total Amount:",-30}{TotalAmount:C}");
            sb.AppendLine("   ╚═════════════════════════════════════════════════════╝");

            return sb.ToString();
        }
    }
    public class PurchaseOrderService
    {
        private List<PurchaseOrder> _purchaseOrders;
        private const string DataFilePath = "purchase_orders.txt";

        // Events for notifying when orders are added
        public event EventHandler<PurchaseOrderEventArgs> PurchaseOrderAdded;
        public PurchaseOrderService()
        {
            _purchaseOrders = new List<PurchaseOrder>();
            LoadPurchaseOrdersFromFile();
        }

        // Method to add a new purchase order
        public void AddPurchaseOrder(PurchaseOrder order)
        {
            _purchaseOrders.Add(order);
            SavePurchaseOrdersToFile();

            // Raise event for notifying order addition
            OnPurchaseOrderAdded(new PurchaseOrderEventArgs(order));
        }

        // Method to display all purchase orders
        public void DisplayPurchaseOrders()
        {
            if (_purchaseOrders.Count == 0)
            {
                Console.WriteLine("No purchase orders to display.");
                return;
            }

            foreach (var order in _purchaseOrders)
            {
                Console.WriteLine(order.GetOrderDetails());
                Console.WriteLine("============================================");
            }

            // Calculate and display total amount for all orders
            Console.ForegroundColor = ConsoleColor.Yellow;
            decimal totalAmount = _purchaseOrders.Sum(order => order.TotalAmount);
            Console.WriteLine($"Total Amount for all orders: {totalAmount:C}");
            Console.ResetColor();
        }

        // Method to save purchase orders to file
        private void SavePurchaseOrdersToFile()
        {
            using (StreamWriter writer = new StreamWriter(DataFilePath))
            {
                foreach (var order in _purchaseOrders)
                {
                    writer.WriteLine($"{order.OrderNumber},{order.ProductName},{order.UnitPrice},{order.Quantity}," +
                                     $"{order.Currency},{order.OrderDeadline},{order.ExpectedArrival}," +
                                     $"{order.UnitOfMeasure},{order.Taxes},{order.DiscountPercentage}");
                }
            }
        }

        // Method to load purchase orders from file
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
                            Enum.TryParse(parts[4], out CurrencyType currency) &&
                            DateTime.TryParseExact(parts[5], "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime orderDeadline) &&
                            DateTime.TryParseExact(parts[6], "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime expectedArrival) &&
                            decimal.TryParse(parts[8], out decimal taxes) &&
                            decimal.TryParse(parts[9], out decimal discountPercentage))
                        {
                            Enum.TryParse(parts[7], out UnitOfMeasure unitOfMeasure);
                            string productName = parts[1];
                            _purchaseOrders.Add(new PurchaseOrder(orderNumber, productName, unitPrice, quantity,
                                                                  currency, orderDeadline, expectedArrival,
                                                                  taxes, unitOfMeasure, discountPercentage));
                        }
                    }
                }
            }
        }

        // Method to handle event invocation
        protected virtual void OnPurchaseOrderAdded(PurchaseOrderEventArgs e)
        {
            PurchaseOrderAdded?.Invoke(this, e);
        }
    }
    public class PurchaseOrderEventArgs : EventArgs
    {
        public PurchaseOrder AddedOrder { get; }

        public PurchaseOrderEventArgs(PurchaseOrder order)
        {
            AddedOrder = order;
        }
    }

}

