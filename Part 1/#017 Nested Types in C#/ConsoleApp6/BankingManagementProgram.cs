using System;
using System.Collections.Generic;
namespace BankingManagementSysrem
{
    class BankingManagementProgram
    {
        static void Main()
        {

            // Create and configure banks
            BankManager.Bank bank1 = SetupBank("Commercial International Bank 'CIB'");
            BankManager.Bank bank2 = SetupBank("National Bank Of Egypt 'NBE'");
            BankManager.Bank bank3 = SetupBank("Emirates National Bank of Dubai Egypt 'NBDE'");

            // Perform ATM transactions and operations
            PerformBankOperations(bank1);
            PerformBankOperations(bank2);
            PerformBankOperations(bank3);

            Console.ReadKey();
        }

        // Helper method to create and configure a bank
        static BankManager.Bank SetupBank(string bankName)
        {
            BankManager.Bank bank = new BankManager.Bank(bankName);
            bank.AddAccount(new BankManager.Account(1001, "Mohamed Nasser", 150000));
            bank.AddAccount(new BankManager.Account(1002, "Ahmed Nasser", 200000));
            return bank;
        }

        // Helper method to perform operations on a bank
        static void PerformBankOperations(BankManager.Bank bank)
        {
            Console.WriteLine($"Welcome to {bank.Name}");
            Console.WriteLine("Performing ATM Transactions...\n");

            // Create ATM for the bank
            BankManager.Bank.ATM atm = new BankManager.Bank.ATM(bank);

            // Display initial account details
            Console.WriteLine($"Initial Account Details for {bank.Name}:");
            bank.DisplayAccounts();
            Console.WriteLine();

            // Attempt withdrawals and deposit
            AttemptTransaction(atm, 1001, 2000);
            AttemptTransaction(atm, 1002, 4000);
            DepositToAccount(bank, 1002, 1500);
            AttemptTransaction(atm, 9999, 1000); // Attempt to withdraw from non-existent account

            // Display updated account details after operations
            Console.WriteLine($"Updated Account Details for {bank.Name}:");
            bank.DisplayAccounts();

            Console.WriteLine("\n****************************************************************\n");
        }

        // Helper method to attempt a withdrawal from an account via ATM
        static void AttemptTransaction(BankManager.Bank.ATM atm, int accountNumber, decimal amount)
        {
            Console.WriteLine($"Attempting to withdraw {amount:C} from Account {accountNumber}:");
            atm.WithdrawFromAccount(accountNumber, amount);
            Console.WriteLine();
        }

        // Helper method to deposit to an account
        static void DepositToAccount(BankManager.Bank bank, int accountNumber, decimal amount)
        {
            Console.WriteLine($"Depositing {amount:C} into Account {accountNumber}:");
            var account = bank.GetAccount(accountNumber);
            if (account != null)
            {
                account.Deposit(amount);
            }
            else
            {
                Console.WriteLine($"Account {accountNumber} not found.");
            }
            Console.WriteLine();
        }
    }
    public class BankManager
    {
        // Nested class representing a Bank Account 
        public class Account
        {
            public int AccountNumber { get; private set; }
            public string AccountHolder { get; private set; }
            public decimal Balance { get; private set; }

            public Account(int accountNumber, string accountHolder, decimal initialBalance)
            {
                AccountNumber = accountNumber;
                AccountHolder = accountHolder;
                Balance = initialBalance;
            }

            public void Deposit(decimal amount)
            {
                Balance += amount;
                Console.WriteLine($"Deposit of {amount:C} successful. New balance: {Balance:C}");
            }

            public bool Withdraw(decimal amount)
            {
                if (amount > Balance)
                {
                    Console.WriteLine("Insufficient funds!");
                    return false;
                }

                Balance -= amount;
                Console.WriteLine($"Withdrawal of {amount:C} successful. New balance: {Balance:C}");
                return true;
            }
        }

        // Nested class representing a Bank
        public class Bank
        {
            public string Name { get; private set; }
            private List<Account> accounts;

            public Bank(string name)
            {
                Name = name;
                accounts = new List<Account>();
            }

            public void AddAccount(Account account)
            {
                accounts.Add(account);
            }

            public void DisplayAccounts()
            {
                Console.WriteLine($"Accounts in {Name} Bank:");
                foreach (var account in accounts)
                {
                    Console.WriteLine($"Account Number: {account.AccountNumber}, Holder: {account.AccountHolder}, Balance: {account.Balance:C}");
                }
            }

            // Method to retrieve an account based on account number
            public Account GetAccount(int accountNumber)
            {
                return accounts.Find(a => a.AccountNumber == accountNumber);
            }

            // Nested class representing an ATM
            public class ATM
            {
                private Bank bank;

                public ATM(Bank bank)
                {
                    this.bank = bank;
                }

                public bool WithdrawFromAccount(int accountNumber, decimal amount)
                {
                    Account account = bank.GetAccount(accountNumber);
                    if (account != null)
                    {
                        return account.Withdraw(amount);
                    }
                    else
                    {
                        Console.WriteLine($"Account {accountNumber} not found.");
                        return false;
                    }
                }
            }
        }
    }

}
