using System;
using System.Collections.Generic;
namespace CustomerServiceQueueSystem
{
    class CustomerServiceQueueProgram
    {
        static void Main(string[] args)
        {
            Queue<Customer> customerQueue = new Queue<Customer>();

            // Simulate customers arriving and queuing for service with Egyptian-inspired English names
            EnqueueCustomers(customerQueue);

            Console.WriteLine($"Bank is open. {customerQueue.Count} customers in line.");
            Console.WriteLine("=================================");

            // Process customers through teller windows
            ProcessCustomers(customerQueue);
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine($"All customers have been served. Bank is closing.");
            Console.ReadKey();
        }

        static void EnqueueCustomers(Queue<Customer> queue)
        {
            // Simulate customers arriving and queuing for service with Egyptian-inspired English names
            queue.Enqueue(new Customer(1, "Amira", TransactionType.Deposit));
            queue.Enqueue(new Customer(2, "Khaled", TransactionType.Withdrawal));
            queue.Enqueue(new Customer(3, "Layla", TransactionType.CheckBalance));
            queue.Enqueue(new Customer(4, "Tarek", TransactionType.Deposit));
            queue.Enqueue(new Customer(5, "Sara", TransactionType.Withdrawal));
        }

        static void ProcessCustomers(Queue<Customer> queue)
        {
            int tellerId = 1;
            while (queue.Count > 0)
            {
                var customer = queue.Dequeue();
                Console.WriteLine($"Customer {customer.CustomerName} is at Teller {tellerId}");

                // Simulate processing time based on transaction type
                switch (customer.TransactionType)
                {
                    case TransactionType.Deposit:
                        ProcessDeposit(customer);
                        break;
                    case TransactionType.Withdrawal:
                        ProcessWithdrawal(customer);
                        break;
                    case TransactionType.CheckBalance:
                        ProcessCheckBalance(customer);
                        break;
                    default:
                        break;
                }

                Console.WriteLine($"Transaction completed for {customer.CustomerName}. Next customer...");
                tellerId++;
            }
        }

        static void ProcessDeposit(Customer customer)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($" - Processing deposit for {customer.CustomerName}...");
            SimulateProcessing();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Deposit successful for {customer.CustomerName}");
            Console.ResetColor(); // Reset color after displaying result
        }

        static void ProcessWithdrawal(Customer customer)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($" - Processing withdrawal for {customer.CustomerName}...");
            SimulateProcessing();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Withdrawal completed for {customer.CustomerName}");
            Console.ResetColor(); // Reset color after displaying result
        }

        static void ProcessCheckBalance(Customer customer)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($" - Checking balance for {customer.CustomerName}...");
            SimulateProcessing();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Balance checked for {customer.CustomerName}");
            Console.ResetColor(); // Reset color after displaying result
        }

        static void SimulateProcessing()
        {
            // Simulate processing time
            System.Threading.Thread.Sleep(2000); // Simulate 2 seconds processing time
        }
    }
    public enum TransactionType
    {
        Deposit,
        Withdrawal,
        CheckBalance
    }
    public class Customer
    {
       
        public int CustomerId { get; }
        public string CustomerName { get; }
        public TransactionType TransactionType { get; }

        public Customer(int customerId, string customerName, TransactionType transactionType)
        {
            this.CustomerId = customerId;
            this.CustomerName = customerName;
            this.TransactionType = transactionType;
        }

        public override string ToString()
        {
            return $"Customer ID: {CustomerId}, Name: {CustomerName}, Transaction: {TransactionType}";
        }
    }
}
