using System;
using System.Collections.Generic;
using System.Linq;
namespace FinancialOpsManager
{
    class FinancialOpsManagerProgram
    {
        static List<Customer> customers = new List<Customer>();
        static List<Vendor> vendors = new List<Vendor>();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Accounting Module Console App!\n");

            while (true)
            {
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Manage Customers");
                Console.WriteLine("2. Manage Vendors");
                Console.WriteLine("3. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ManageCustomers();
                        break;
                    case "2":
                        ManageVendors();
                        break;
                    case "3":
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void ManageCustomers()
        {
            Console.WriteLine("\nCustomer Management:");

            Console.WriteLine("1. Add New Customer");
            Console.WriteLine("2. View All Customers");
            Console.WriteLine("3. Create Invoice");
            Console.WriteLine("4. Create Credit Note");
            Console.WriteLine("5. Create Customer Payment");
            Console.WriteLine("6. Create Batch Payment");
            Console.WriteLine("7. View Customer Products");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddNewCustomer();
                    break;
                case "2":
                    ViewAllCustomers();
                    break;
                case "3":
                    CreateInvoice();
                    break;
                case "4":
                    CreateCreditNote();
                    break;
                case "5":
                    CreateCustomerPayment();
                    break;
                case "6":
                    CreateBatchPayment();
                    break;
                case "7":
                    ViewCustomerProducts();
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }

        static void AddNewCustomer()
        {
            Console.WriteLine("\nEnter Customer Details:");

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Address: ");
            string address = Console.ReadLine();

            Console.Write("Contact Info: ");
            string contactInfo = Console.ReadLine();

            var newCustomer = new Customer
            {
                Name = name,
                Address = address,
                ContactInfo = contactInfo
            };

            customers.Add(newCustomer);

            Console.WriteLine($"Customer '{name}' added successfully!");
        }

        static void ViewAllCustomers()
        {
            Console.WriteLine("\nAll Customers:");

            if (customers.Any())
            {
                foreach (var customer in customers)
                {
                    Console.WriteLine($"Name: {customer.Name}");
                    Console.WriteLine($"Address: {customer.Address}");
                    Console.WriteLine($"Contact Info: {customer.ContactInfo}");
                    Console.WriteLine("--------------------------------------");
                }
            }
            else
            {
                Console.WriteLine("No customers found.");
            }
        }

        static void CreateInvoice()
        {
            Console.WriteLine("\nEnter Invoice Details:");

            // Implement invoice creation logic here...
        }

        static void CreateCreditNote()
        {
            Console.WriteLine("\nEnter Credit Note Details:");

            // Implement credit note creation logic here...
        }

        static void CreateCustomerPayment()
        {
            Console.WriteLine("\nEnter Customer Payment Details:");

            // Implement customer payment creation logic here...
        }

        static void CreateBatchPayment()
        {
            Console.WriteLine("\nEnter Batch Payment Details:");

            // Implement batch payment creation logic here...
        }

        static void ViewCustomerProducts()
        {
            Console.WriteLine("\nEnter Customer Name:");

            string customerName = Console.ReadLine();
            var customer = customers.FirstOrDefault(c => c.Name.Equals(customerName, StringComparison.OrdinalIgnoreCase));

            if (customer != null)
            {
                Console.WriteLine($"\nProducts for Customer '{customerName}':");

                if (customer.Products.Any())
                {
                    foreach (var product in customer.Products)
                    {
                        Console.WriteLine($"Product Name: {product.Name}");
                        Console.WriteLine($"Price: {product.Price:C}");
                        Console.WriteLine($"Stock: {product.Stock}");
                        Console.WriteLine("--------------------------------------");
                    }
                }
                else
                {
                    Console.WriteLine("No products found for this customer.");
                }
            }
            else
            {
                Console.WriteLine($"Customer '{customerName}' not found.");
            }
        }

        static void ManageVendors()
        {
            Console.WriteLine("\nVendor Management:");

            Console.WriteLine("1. Add New Vendor");
            Console.WriteLine("2. View All Vendors");
            Console.WriteLine("3. Create Bill");
            Console.WriteLine("4. Create Refund");
            Console.WriteLine("5. Create Vendor Payment");
            Console.WriteLine("6. Create Batch Payment");
            Console.WriteLine("7. View Vendor Products");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddNewVendor();
                    break;
                case "2":
                    ViewAllVendors();
                    break;
                case "3":
                    CreateBill();
                    break;
                case "4":
                    CreateRefund();
                    break;
                case "5":
                    CreateVendorPayment();
                    break;
                case "6":
                    CreateBatchPayment();
                    break;
                case "7":
                    ViewVendorProducts();
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }

        static void AddNewVendor()
        {
            Console.WriteLine("\nEnter Vendor Details:");

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Address: ");
            string address = Console.ReadLine();

            Console.Write("Contact Info: ");
            string contactInfo = Console.ReadLine();

            var newVendor = new Vendor
            {
                Name = name,
                Address = address,
                ContactInfo = contactInfo
            };

            vendors.Add(newVendor);

            Console.WriteLine($"Vendor '{name}' added successfully!");
        }

        static void ViewAllVendors()
        {
            Console.WriteLine("\nAll Vendors:");

            if (vendors.Any())
            {
                foreach (var vendor in vendors)
                {
                    Console.WriteLine($"Name: {vendor.Name}");
                    Console.WriteLine($"Address: {vendor.Address}");
                    Console.WriteLine($"Contact Info: {vendor.ContactInfo}");
                    Console.WriteLine("--------------------------------------");
                }
            }
            else
            {
                Console.WriteLine("No vendors found.");
            }
        }

        static void CreateBill()
        {
            Console.WriteLine("\nEnter Bill Details:");

            // Implement bill creation logic here...
        }

        static void CreateRefund()
        {
            Console.WriteLine("\nEnter Refund Details:");

            // Implement refund creation logic here...
        }

        static void CreateVendorPayment()
        {
            Console.WriteLine("\nEnter Vendor Payment Details:");

            // Implement vendor payment creation logic here...
        }

        static void ViewVendorProducts()
        {
            Console.WriteLine("\nEnter Vendor Name:");

            string vendorName = Console.ReadLine();
            var vendor = vendors.FirstOrDefault(v => v.Name.Equals(vendorName, StringComparison.OrdinalIgnoreCase));

            if (vendor != null)
            {
                Console.WriteLine($"\nProducts for Vendor '{vendorName}':");

                if (vendor.Products.Any())
                {
                    foreach (var product in vendor.Products)
                    {
                        Console.WriteLine($"Product Name: {product.Name}");
                        Console.WriteLine($"Price: {product.Price:C}");
                        Console.WriteLine($"Stock: {product.Stock}");
                        Console.WriteLine("--------------------------------------");
                    }
                }
                else
                {
                    Console.WriteLine("No products found for this vendor.");
                }
            }
            else
            {
                Console.WriteLine($"Vendor '{vendorName}' not found.");
            }
        }
    }

    public class Customer
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactInfo { get; set; }
        public List<Invoice> Invoices { get; set; } = new List<Invoice>();
        public List<CreditNote> CreditNotes { get; set; } = new List<CreditNote>();
        public decimal AmountToSettle { get; set; }
        public List<Payment> Payments { get; set; } = new List<Payment>();
        public List<BatchPayment> BatchPayments { get; set; } = new List<BatchPayment>();
        public List<FollowUpReport> FollowUpReports { get; set; } = new List<FollowUpReport>();
        public List<DirectDebitMandate> DirectDebitMandates { get; set; } = new List<DirectDebitMandate>();
        public List<Product> Products { get; set; } = new List<Product>();
    }

    public class Vendor
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactInfo { get; set; }
        public List<Bill> Bills { get; set; } = new List<Bill>();
        public List<Refund> Refunds { get; set; } = new List<Refund>();
        public decimal AmountToSettlePayments { get; set; }
        public List<BatchPayment> BatchPayments { get; set; } = new List<BatchPayment>();
        public List<EmployeeExpense> EmployeeExpenses { get; set; } = new List<EmployeeExpense>();
        public List<BankAccount> BankAccounts { get; set; } = new List<BankAccount>();
        public List<Product> Products { get; set; } = new List<Product>();
    }

    public class Invoice
    {
        public int InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal TotalAmount { get; set; }
    }

    public class CreditNote
    {
        public int CreditNoteNumber { get; set; }
        public DateTime CreditNoteDate { get; set; }
        public decimal Amount { get; set; }
    }

    public class Payment
    {
        public int PaymentNumber { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
    }

    public class BatchPayment
    {
        public int BatchPaymentNumber { get; set; }
        public DateTime BatchPaymentDate { get; set; }
        public List<Payment> Payments { get; set; } = new List<Payment>();
    }

    public class FollowUpReport
    {
        public int ReportNumber { get; set; }
        public DateTime ReportDate { get; set; }
        public string Details { get; set; }
    }

    public class DirectDebitMandate
    {
        public int MandateNumber { get; set; }
        public DateTime MandateDate { get; set; }
        public string BankDetails { get; set; }
    }

    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }

    public class Bill
    {
        public int BillNumber { get; set; }
        public DateTime BillDate { get; set; }
        public decimal TotalAmount { get; set; }
    }

    public class Refund
    {
        public int RefundNumber { get; set; }
        public DateTime RefundDate { get; set; }
        public decimal Amount { get; set; }
    }

    public class EmployeeExpense
    {
        public int ExpenseNumber { get; set; }
        public DateTime ExpenseDate { get; set; }
        public decimal Amount { get; set; }
    }

    public class BankAccount
    {
        public string AccountNumber { get; set; }
        public string BankName { get; set; }
    }


}
