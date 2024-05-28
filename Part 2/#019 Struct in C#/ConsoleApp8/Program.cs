using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            // Example usage
            FinancialTransaction transaction1 = new FinancialTransaction(1001, DateTime.Today, "Withdrawal", -500.00m, "ATM Withdrawal", "Expense", "123456789");
            FinancialTransaction transaction2 = new FinancialTransaction(1002, DateTime.Today, "Deposit", 1000.00m, "Salary", "Income", "987654321");

            Console.WriteLine("Transaction 1:");
            transaction1.PrintTransactionDetails();
            Console.WriteLine($"Categorized Type: {transaction1.GetTransactionCategory()}");
            Console.WriteLine($"Value Status: {transaction1.GetValueStatus()}");

            Console.WriteLine("\nTransaction 2:");
            transaction2.PrintTransactionDetails();
            Console.WriteLine($"Categorized Type: {transaction2.GetTransactionCategory()}");
            Console.WriteLine($"Value Status: {transaction2.GetValueStatus()}");

            // Additional operations
            Console.WriteLine("\nApplying a 10% Discount to Transaction 1...");
            transaction1.ApplyDiscount(0.1m);
            Console.WriteLine("Updated Transaction 1:");
            transaction1.PrintTransactionDetails();

            Console.ReadKey();
        }
    }

    public struct FinancialTransaction
    {
        public int TransactionId { get; }
        public DateTime TransactionDate { get; }
        public string Description { get; }
        public decimal Amount { get; }
        public string TransactionType { get; }
        public string Category { get; }
        public string AccountId { get; }

        public FinancialTransaction(int transactionId, DateTime transactionDate, string description, decimal amount,
                                     string transactionType, string category, string accountId)
        {
            if (transactionId <= 0)
            {
                throw new ArgumentException("Transaction ID must be a positive integer.", nameof(transactionId));
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException("Description cannot be empty or null.", nameof(description));
            }

            TransactionId = transactionId;
            TransactionDate = transactionDate;
            Description = description;
            Amount = amount;
            TransactionType = transactionType;
            Category = category;
            AccountId = accountId;
        }

        // Method to print transaction details
        public void PrintTransactionDetails()
        {
            Console.WriteLine("".PadRight(50, '*'));
            Console.WriteLine($"Transaction ID: {TransactionId}");
            Console.WriteLine($"Date: {TransactionDate.ToShortDateString()}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Amount: {Amount:C}");
            Console.WriteLine($"Type: {TransactionType}");
            Console.WriteLine($"Category: {Category}");
            Console.WriteLine($"Account ID: {AccountId}");
            Console.WriteLine("".PadRight(50, '*'));
        }

        // Method to categorize transaction type based on amount
        public string GetTransactionCategory()
        {
            return Amount < 0 ? "Expense" : "Income";
        }

        // Method to determine value status of transaction
        public string GetValueStatus()
        {
            return Math.Abs(Amount) > 500 ? "High Value" : "Low Value";
        }

        // Method to apply a discount to the transaction amount
        public void ApplyDiscount(decimal discountPercentage)
        {
            if (Amount < 0)
            {
                // Only apply discount to expense transactions
                Amount += Amount * discountPercentage;
            }
            else
            {
                throw new InvalidOperationException("Discount can only be applied to expense transactions.");
            }
        }
    }
}
