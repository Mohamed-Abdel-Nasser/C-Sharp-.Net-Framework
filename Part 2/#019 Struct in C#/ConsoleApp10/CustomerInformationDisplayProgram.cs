using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace CustomerInformationDisplaySystem
{
    class CustomerInformationDisplayProgram
    {
        private static List<Customer> customers = new List<Customer>();

        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Welcome to Customer Details Display Screen");
            Console.ResetColor();
            Console.WriteLine();

            // Example usage with initial data
            AddInitialCustomers();

            bool exitRequested = false;
            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Select an option:");
                Console.WriteLine("====================");
                Console.ResetColor();
                Console.WriteLine("1. Display all customers");
                Console.WriteLine("2. Add a new customer");
                Console.WriteLine("3. Exit");
                Console.WriteLine("====================");
                Console.WriteLine("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        DisplayAllCustomers();
                        break;
                    case "2":
                        AddNewCustomer();
                        break;
                    case "3":
                        exitRequested = true;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        Console.ResetColor();
                        break;
                }

                Console.WriteLine();
            } while (!exitRequested);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nPress any key to exit...");
            Console.ResetColor();
            Console.ReadKey();
        }

        private static void AddInitialCustomers()
        {
            // Example initial data
            customers.Add(new Customer(2001, "Ali", "Khalid", "ali@example.com", DateTime.Today, "Cairo", "+20123456789", true));
            customers.Add(new Customer(2002, "Fatima", "Ahmed", "fatma@example.com", DateTime.Today, "Alexandria", "+20234567890", false));
        }

        private static void DisplayAllCustomers()
        {
            if (customers.Count == 0)
            {
                Console.WriteLine("No customers to display.");
                return;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=== All Customers ===");
            Console.ResetColor();
            foreach (var customer in customers)
            {
                DisplayCustomerDetails(customer);
                Console.WriteLine();
            }
        }

        private static void AddNewCustomer()
        {
            try
            {
                Console.WriteLine("Enter customer details:");

                Console.Write("Customer ID: ");
                int customerId = int.Parse(Console.ReadLine());

                Console.Write("First Name: ");
                string firstName = Console.ReadLine();

                Console.Write("Last Name: ");
                string lastName = Console.ReadLine();

                Console.Write("Email: ");
                string email = Console.ReadLine();

                if (!IsValidEmail(email))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid email format. Customer not added.");
                    Console.ResetColor();
                    return;
                }

                Console.Write("Address: ");
                string address = Console.ReadLine();

                Console.Write("Phone Number: ");
                string phoneNumber = Console.ReadLine();

                Console.Write("Is Member (true/false): ");
                bool isMember = bool.Parse(Console.ReadLine());

                Customer newCustomer = new Customer(customerId, firstName, lastName, email, DateTime.Today, address, phoneNumber, isMember);
                customers.Add(newCustomer);
                Console.WriteLine("Customer added successfully.");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error adding customer: {ex.Message}");
                Console.ResetColor();
            }
        }

        private static void DisplayCustomerDetails(Customer customer)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"=== Customer ID: {customer.CustomerId} ===");
            Console.ResetColor();
            customer.PrintCustomerDetails();
        }

        // Struct definition with additional attributes
        public struct Customer
        {
            public int CustomerId { get; }
            public string FirstName { get; }
            public string LastName { get; }
            public string Email { get; }
            public DateTime RegistrationDate { get; }
            public string Address { get; }
            public string PhoneNumber { get; }
            public bool IsMember { get; }

            public Customer(int customerId, string firstName, string lastName, string email, DateTime registrationDate, string address, string phoneNumber, bool isMember)
            {
                if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
                {
                    throw new ArgumentException("First name and last name must not be empty.");
                }

                if (!IsValidEmail(email))
                {
                    throw new ArgumentException("Invalid email format.");
                }

                CustomerId = customerId;
                FirstName = firstName;
                LastName = lastName;
                Email = email;
                RegistrationDate = registrationDate;
                Address = address;
                PhoneNumber = phoneNumber;
                IsMember = isMember;
            }

            // Method to display customer details with enhanced formatting
            public void PrintCustomerDetails()
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("".PadRight(60, '*'));
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"Customer ID: {CustomerId}");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Name: {FirstName} {LastName}");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Email: {Email}");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Registration Date: {RegistrationDate:dd/MM/yyyy}");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"Address: {Address}");
                Console.WriteLine($"Phone Number: {PhoneNumber}");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"Member Status: {(IsMember ? "Yes" : "No")}");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("".PadRight(60, '*'));
                Console.ResetColor();
            }
        }

        private static bool IsValidEmail(string email)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }
    }
}
