using System;
using System.Collections.Generic;
namespace BankingCSQueueManagementApp
{
    class BankingCSQueueManagementProgram
    {
        static void Main()
        {
            Queue<Customer> customerQueue = new Queue<Customer>();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Bank Queue Management System");
                Console.WriteLine("=============================================");
                Console.WriteLine("1. Enqueue a customer");
                Console.WriteLine("2. Serve the next customer");
                Console.WriteLine("3. View the current queue");
                Console.WriteLine("4. Exit");
                Console.WriteLine("=============================================");
                Console.Write("Enter your choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter a number.");
                    Console.ResetColor();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        EnqueueCustomer(customerQueue);
                        break;
                    case 2:
                        ServeCustomer(customerQueue);
                        break;
                    case 3:
                        ViewQueue(customerQueue);
                        break;
                    case 4:
                        Console.WriteLine("Exiting the program.");
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                        Console.ResetColor();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                }

                Console.WriteLine();
            }
        }

        static void EnqueueCustomer(Queue<Customer> queue)
        {
            Console.Clear();
            Console.WriteLine("Enqueue a Customer");
            Console.WriteLine("------------------");
            Console.Write("Enter customer name: ");
            string name = Console.ReadLine();
            Console.Write("Enter customer age: ");
            int age;
            while (!int.TryParse(Console.ReadLine(), out age) || age <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid age. Please enter a valid age.");
                Console.ResetColor();
                Console.Write("Enter customer age: ");
            }
            Console.Write("Enter customer account number: ");
            string accountNumber = Console.ReadLine();
            Console.Write("Enter reason for visit: ");
            string reason = Console.ReadLine();
            Customer customer = new Customer(name, age, accountNumber, reason);
            queue.Enqueue(customer);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Customer '{customer.Name}' (Account: {customer.AccountNumber}) added to the queue for {customer.ReasonForVisit}.");
            Console.ResetColor();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static void ServeCustomer(Queue<Customer> queue)
        {
            Console.Clear();
            Console.WriteLine("Serve the Next Customer");
            Console.WriteLine("-----------------------");
            if (queue.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Queue is empty. No customers to serve.");
                Console.ResetColor();
            }
            else
            {
                Customer nextCustomer = queue.Dequeue();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Serving customer '{nextCustomer.Name}' (Account: {nextCustomer.AccountNumber}). Reason: {nextCustomer.ReasonForVisit}");
                Console.ResetColor();
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static void ViewQueue(Queue<Customer> queue)
        {
            Console.Clear();
            Console.WriteLine("View Current Queue");
            Console.WriteLine("------------------");
            Console.WriteLine("Current queue:");
            foreach (var customer in queue)
            {
                Console.WriteLine($"Name: {customer.Name}, Account: {customer.AccountNumber}, Reason: {customer.ReasonForVisit}");
            }
            Console.WriteLine($"Total customers in queue: {queue.Count}");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }

    class Customer
    {
        public string Name { get; }
        public int Age { get; }
        public string AccountNumber { get; }
        public string ReasonForVisit { get; }

        public Customer(string name, int age, string accountNumber, string reason)
        {
            Name = name;
            Age = age;
            AccountNumber = accountNumber;
            ReasonForVisit = reason;
        }
    }

}
