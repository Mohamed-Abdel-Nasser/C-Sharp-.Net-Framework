using System;
using System.Collections.Generic;

namespace ManufacturingOrderModel
{
    class ManufacturingOrdProgram
    {
        private static List<Product> _products = new List<Product>();
        private static List<ManufacturingOrder> _manufacturingOrders = new List<ManufacturingOrder>();

        static void Main(string[] args)
        {
            Console.WriteLine("=== Manufacturing Order System ===");

            InitializeProducts();
            MainMenu();
        }

        static void InitializeProducts()
        {
            _products.Add(new Product(1, "Chair", "Comfortable chair", "piece"));
            _products.Add(new Product(2, "Table", "Sturdy table", "piece"));
        }

        static void MainMenu()
        {
            while (true)
            {
                Console.WriteLine("\nMain Menu:");
                Console.WriteLine("1. Create Manufacturing Order");
                Console.WriteLine("2. View Manufacturing Orders");
                Console.WriteLine("3. Exit");
                Console.Write("Select an option: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        CreateManufacturingOrder();
                        break;
                    case "2":
                        ViewManufacturingOrders();
                        break;
                    case "3":
                        Console.WriteLine("Exiting the program. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void CreateManufacturingOrder()
        {
            Console.WriteLine("\n=== Create Manufacturing Order ===");

            Console.WriteLine("Available Products:");
            foreach (var product in _products)
            {
                Console.WriteLine($"ID: {product.ProductId}, Name: {product.Name}");
            }

            Console.Write("Enter Product ID: ");
            if (!int.TryParse(Console.ReadLine(), out int productId))
            {
                Console.WriteLine("Invalid Product ID.");
                return;
            }

            Product selectedProduct = null;
            foreach (var product in _products)
            {
                if (product.ProductId == productId)
                {
                    selectedProduct = product;
                    break;
                }
            }

            if (selectedProduct == null)
            {
                Console.WriteLine("Product not found.");
                return;
            }

            Console.Write("Enter Scheduled Date (yyyy-MM-dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime scheduledDate))
            {
                Console.WriteLine("Invalid date format.");
                return;
            }

            Console.Write("Enter Quantity: ");
            if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity <= 0)
            {
                Console.WriteLine("Invalid quantity.");
                return;
            }

            Console.Write("Enter Responsible Person: ");
            string responsiblePerson = Console.ReadLine();

            var manufacturingOrder = new ManufacturingOrder(selectedProduct, scheduledDate, quantity, responsiblePerson);
            _manufacturingOrders.Add(manufacturingOrder);

            Console.WriteLine("Manufacturing Order Created Successfully.");
        }

        static void ViewManufacturingOrders()
        {
            Console.WriteLine("\n=== Manufacturing Orders ===");

            if (_manufacturingOrders.Count == 0)
            {
                Console.WriteLine("No manufacturing orders available.");
                return;
            }

            Console.WriteLine("{0,-10} {1,-20} {2,-15} {3,-10} {4,-20}",
                              "MO Number", "Product Name", "Scheduled Date", "Quantity", "Responsible Person");
            Console.WriteLine("==============================================================================");

            foreach (var mo in _manufacturingOrders)
            {
                Console.WriteLine("{0,-10} {1,-20} {2,-15:yyyy-MM-dd} {3,-10} {4,-20}",
                                  mo.MoNumber, mo.Product.Name, mo.ScheduledDate, mo.Quantity, mo.ResponsiblePerson);
            }
        }
    }

    // Product class representing a manufactured item
    public class Product
    {
        public int ProductId { get; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UnitOfMeasure { get; set; }

        public Product(int productId, string name, string description, string unitOfMeasure)
        {
            ProductId = productId;
            Name = name;
            Description = description;
            UnitOfMeasure = unitOfMeasure;
        }
    }

    // Manufacturing Order class representing a production order
    public class ManufacturingOrder
    {
        private static int _nextMoNumber = 1;

        public int MoNumber { get; }
        public Product Product { get; }
        public DateTime ScheduledDate { get; }
        public int Quantity { get; }
        public string ResponsiblePerson { get; }

        public ManufacturingOrder(Product product, DateTime scheduledDate, int quantity, string responsiblePerson)
        {
            MoNumber = _nextMoNumber++;
            Product = product;
            ScheduledDate = scheduledDate;
            Quantity = quantity;
            ResponsiblePerson = responsiblePerson;
        }
    }

}
