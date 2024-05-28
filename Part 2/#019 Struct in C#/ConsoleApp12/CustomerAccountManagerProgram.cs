using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomerAccountManagerSystem
{
    class CustomerAccountManagerProgram
    {
        static void Main()
        {
            try
            {
                // Example usage
                CustomerAccount account1 = new CustomerAccount(1001, "Alice Johnson", 1500.75m);
                CustomerAccount account2 = new CustomerAccount(1002, "Bob Smith", 2500.50m);

                Console.WriteLine("=== Initial Customer Account Details ===");
                DisplayAccountDetails(account1);
                DisplayAccountDetails(account2);

                // Perform transactions
                Console.WriteLine("\n=== Performing Transactions ===");
                ProcessTransaction(account1, TransactionType.DEPOSIT, 500m, "Salary Deposit");
                ProcessTransaction(account2, TransactionType.WITHDRAWAL, 1000m, "Monthly Rent");

                Console.WriteLine("\n=== Updated Customer Account Details ===");
                DisplayAccountDetails(account1);
                DisplayAccountDetails(account2);

                // Display transaction history
                Console.WriteLine("\n=== Transaction History ===");
                DisplayTransactionHistory(account1);
                DisplayTransactionHistory(account2);

                // Display account summary
                Console.WriteLine("\n=== Account Summary ===");
                DisplayAccountSummary(account1);
                DisplayAccountSummary(account2);
            }
            catch (ArgumentException ex)
            {
                HandleError($"Invalid argument: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                HandleError($"Invalid operation: {ex.Message}");
            }
            catch (Exception ex)
            {
                HandleError($"An unexpected error occurred: {ex.Message}");
            }

            Console.ReadKey();
        }

        private static void DisplayAccountDetails(CustomerAccount account)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Account Number: {account.AccountNumber}");
            Console.ResetColor();
            Console.WriteLine($"Customer: {account.CustomerName}");
            Console.WriteLine($"Balance: {account.Balance:C}");
            Console.WriteLine();
        }

        private static void ProcessTransaction(CustomerAccount account, TransactionType type, decimal amount, string description)
        {
            try
            {
                switch (type)
                {
                    case TransactionType.DEPOSIT:
                        account.Deposit(amount, description);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Deposited {amount:C} into Account Number {account.AccountNumber} ({description})");
                        break;
                    case TransactionType.WITHDRAWAL:
                        if (account.Withdraw(amount, description))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Withdrawn {amount:C} from Account Number {account.AccountNumber} ({description})");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine($"Withdrawal of {amount:C} from Account Number {account.AccountNumber} ({description}) failed due to insufficient funds.");
                        }
                        break;
                    default:
                        throw new ArgumentException("Invalid transaction type.");
                }
            }
            catch (ArgumentException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Transaction Error: {ex.Message}");
            }
            finally
            {
                Console.ResetColor();
            }
        }

        private static void DisplayTransactionHistory(CustomerAccount account)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Transaction History for Account Number {account.AccountNumber}:");
            Console.ResetColor();
            Console.WriteLine("Date       | Type      | Description           | Amount");
            Console.WriteLine("-----------+-----------+-----------------------+--------------");
            foreach (var transaction in account.TransactionHistory)
            {
                Console.WriteLine($"{transaction.Date.ToShortDateString()} | {transaction.Type,-9} | {transaction.Description,-22} | {transaction.Amount,12:C}");
            }
            Console.WriteLine();
        }

        private static void DisplayAccountSummary(CustomerAccount account)
        {
            var deposits = account.TransactionHistory.Where(t => t.Type == TransactionType.DEPOSIT).Sum(t => t.Amount);
            var withdrawals = account.TransactionHistory.Where(t => t.Type == TransactionType.WITHDRAWAL).Sum(t => t.Amount);
            var netChange = deposits - withdrawals;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Account Summary for Account Number {account.AccountNumber}:");
            Console.ResetColor();
            Console.WriteLine($"Total Deposits   : {deposits:C}");
            Console.WriteLine($"Total Withdrawals: {withdrawals:C}");
            Console.WriteLine($"Net Balance Change: {netChange:C}");
            Console.WriteLine();
        }

        private static void HandleError(string errorMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error: {errorMessage}");
            Console.ResetColor();
        }
    }

    public enum TransactionType
    {

        DEPOSIT,
        WITHDRAWAL

    }

    public struct FinancialTransaction
    {
        public int TransactionId { get; }
        public DateTime Date { get; }
        public string Description { get; }
        public decimal Amount { get; }
        public TransactionType Type { get; }

        private static int nextTransactionId = 1;

        public FinancialTransaction(DateTime date, string description, decimal amount, TransactionType type)
        {
            TransactionId = nextTransactionId++;
            Date = date;
            Description = description;
            Amount = amount;
            Type = type;
        }
    }

    public class CustomerAccount
    {
        public int AccountNumber { get; }
        public string CustomerName { get; }
        public decimal Balance { get; private set; }
        public List<FinancialTransaction> TransactionHistory { get; }

        public CustomerAccount(int accountNumber, string customerName, decimal balance)
        {
            if (accountNumber <= 0)
                throw new ArgumentException("Account number must be a positive integer.", nameof(accountNumber));

            if (string.IsNullOrWhiteSpace(customerName))
                throw new ArgumentException("Customer name cannot be empty or null.", nameof(customerName));

            AccountNumber = accountNumber;
            CustomerName = customerName;
            Balance = balance;
            TransactionHistory = new List<FinancialTransaction>();
        }

        public void Deposit(decimal amount, string description)
        {
            if (amount <= 0)
                throw new ArgumentException("Deposit amount must be positive.", nameof(amount));

            Balance += amount;
            RecordTransaction(description, amount, TransactionType.DEPOSIT);
        }

        public bool Withdraw(decimal amount, string description)
        {
            if (amount <= 0)
                throw new ArgumentException("Withdrawal amount must be positive.", nameof(amount));

            if (Balance >= amount)
            {
                Balance -= amount;
                RecordTransaction(description, -amount, TransactionType.WITHDRAWAL);
                return true;
            }

            return false;
        }

        private void RecordTransaction(string description, decimal amount, TransactionType type)
        {
            TransactionHistory.Add(new FinancialTransaction(DateTime.Today, description, amount, type));
        }
    }
}
