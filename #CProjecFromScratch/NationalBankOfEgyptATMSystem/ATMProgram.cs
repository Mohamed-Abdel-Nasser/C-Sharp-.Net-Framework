using System;
using System.Collections.Generic;

namespace NationalBankOfEgyptATMSystem
{
    public class ATMProgram
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to National Bank Of Egypt ATM System!");
            Console.WriteLine("==============================================");

            var accounts = new List<BankAccount>
            {
                new BankAccount("123456789", 1000, AccountType.Current, 100),
                new BankAccount("987654321", 500, AccountType.Savings, 50)
            };

            var atm = new ATM(accounts);

            while (true)
            {
                atm.DisplayMainMenu();

                if (atm.ShouldExit)
                {
                    break; // Exit the ATM system
                }
            }
        }
    }

    public class ATM
    {
        private List<BankAccount> accounts;
        public bool ShouldExit { get; private set; }

        public ATM(List<BankAccount> accounts)
        {
            this.accounts = accounts;
            ShouldExit = false;
        }

        public void DisplayMainMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to National Bank Of Egypt ATM System!");
            Console.WriteLine("==============================================");
            Console.WriteLine("1. Insert Card");
            Console.WriteLine("2. Exit");
            Console.WriteLine("==============================================");

            Console.Write("Enter option: ");
            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid input. Please try again.");
                Console.Write("Press any key to continue...");
                Console.ReadKey();
                return;
            }

            switch (choice)
            {
                case 1:
                    InsertCard();
                    break;
                case 2:
                    Console.WriteLine("Exiting ATM. Goodbye!");
                    ShouldExit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please select a valid option.");
                    Console.Write("Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }

        private void InsertCard()
        {
            Console.Clear();
            Console.WriteLine("Insert Card");
            Console.WriteLine("=============");
            Console.WriteLine("Insert ATM debit/Credit card into the card reader slot.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            EnterPIN();
        }

        private void EnterPIN()
        {
            Console.Clear();
            Console.WriteLine("Enter PIN");
            Console.WriteLine("==========");

            Console.Write("Enter your personal identification number (PIN) using the keypad: ");
            string pin = Console.ReadLine();

            if (ValidatePIN(pin))
            {
                Console.WriteLine("PIN accepted. Access granted.");
                Console.Write("Press any key to continue...");
                Console.ReadKey();

                // Show main menu after successful PIN entry
                ShowMainMenu();
            }
            else
            {
                Console.WriteLine("Invalid PIN. Access denied.");
                Console.Write("Press any key to continue...");
                Console.ReadKey();
            }
        }

        private void ShowMainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Main Menu");
                Console.WriteLine("=========");
                Console.WriteLine("1. Open Account");
                Console.WriteLine("2. New Transaction");
                Console.WriteLine("3. Reporting");
                Console.WriteLine("4. Settings");
                Console.WriteLine("5. Exit");
                Console.WriteLine("==============================================");

                Console.Write("Enter option: ");
                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    Console.Write("Press any key to continue...");
                    Console.ReadKey();
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        OpenAccount();
                        break;
                    case 2:
                        NewTransactionMenu();
                        break;
                    case 3:
                        ReportingMenu();
                        break;
                    case 4:
                        SettingMenu();
                        break;
                    case 5:
                        Console.WriteLine("Exiting ATM. Goodbye!");
                        ShouldExit = true;
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please select a valid option.");
                        Console.Write("Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void OpenAccount()
        {
            Console.Clear();
            Console.WriteLine("Open Account");
            Console.WriteLine("============");

            Console.WriteLine("1. Current Account");
            Console.WriteLine("2. Savings Account");
            Console.WriteLine("3. Fixed Deposit Account");
            Console.WriteLine("4. Foreign Currency Account");
            Console.WriteLine("5. Youth Savings Account");
            Console.WriteLine("6. Business Account");
            Console.WriteLine("7. Corporate Account");
            Console.WriteLine("8. Investment Account");
            Console.WriteLine("9. Student Account");
            Console.WriteLine("10. E-Banking Account");
            Console.WriteLine("11. Back");

            Console.Write("Enter account type option: ");
            if (!int.TryParse(Console.ReadLine(), out int accountTypeChoice))
            {
                Console.WriteLine("Invalid input. Please try again.");
                Console.Write("Press any key to continue...");
                Console.ReadKey();
                return;
            }

            if (accountTypeChoice < 1 || accountTypeChoice > 11)
            {
                Console.WriteLine("Invalid account type option. Please select a valid option.");
                Console.Write("Press any key to continue...");
                Console.ReadKey();
                return;
            }

            if (accountTypeChoice == 11)
                return; // Back to main menu

            AccountType selectedAccountType = (AccountType)(accountTypeChoice - 1);

            Console.Write("Enter initial deposit amount: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal initialDeposit) || initialDeposit < 0)
            {
                Console.WriteLine("Invalid deposit amount. Account creation failed.");
                Console.Write("Press any key to continue...");
                Console.ReadKey();
                return;
            }

            string newAccountNumber = GenerateAccountNumber();
            BankAccount newAccount = new BankAccount(newAccountNumber, initialDeposit, selectedAccountType);
            accounts.Add(newAccount);

            Console.WriteLine($"Account created successfully. Account Number: {newAccountNumber}");
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }

        private string GenerateAccountNumber()
        {
            Random random = new Random();
            return random.Next(10000000, 99999999).ToString();
        }

        private void NewTransactionMenu()
        {
            Console.Clear();
            Console.WriteLine("New Transaction");
            Console.WriteLine("================");
            Console.WriteLine("1. Deposit into an Account");
            Console.WriteLine("2. Withdraw from an Account");
            Console.WriteLine("3. Transfer Funds Between Accounts");
            Console.WriteLine("4. Back");

            Console.Write("Enter transaction type option: ");
            if (!int.TryParse(Console.ReadLine(), out int transactionChoice))
            {
                Console.WriteLine("Invalid input. Please try again.");
                Console.Write("Press any key to continue...");
                Console.ReadKey();
                return;
            }

            switch (transactionChoice)
            {
                case 1:
                    DoDeposit();
                    break;
                case 2:
                    DoWithdraw();
                    break;
                case 3:
                    TransferFunds();
                    break;
                case 4:
                    return; // Back to main menu
                default:
                    Console.WriteLine("Invalid transaction type. Please select a valid option.");
                    Console.Write("Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }

        private void ReportingMenu()
        {
            Console.Clear();
            Console.WriteLine("Reporting");
            Console.WriteLine("=========");
            Console.WriteLine("1. Balance Inquiry");
            Console.WriteLine("2. Mini Statement");
            Console.WriteLine("3. Back");

            Console.Write("Enter reporting option: ");
            if (!int.TryParse(Console.ReadLine(), out int reportChoice))
            {
                Console.WriteLine("Invalid input. Please try again.");
                Console.Write("Press any key to continue...");
                Console.ReadKey();
                return;
            }

            switch (reportChoice)
            {
                case 1:
                    DoBalanceInquiry();
                    break;
                case 2:
                    DoMiniStatement();
                    break;
                case 3:
                    return; // Back to main menu
                default:
                    Console.WriteLine("Invalid reporting option. Please select a valid option.");
                    Console.Write("Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }

        private void SettingMenu()
        {
            Console.Clear();
            Console.WriteLine("Settings");
            Console.WriteLine("========");

            Console.WriteLine("1. Update Account Information");
            Console.WriteLine("2. Close Account");
            Console.WriteLine("3. Language Selection");
            Console.WriteLine("4. Change PIN");
            Console.WriteLine("5. Back");

            Console.Write("Enter setting option: ");
            if (!int.TryParse(Console.ReadLine(), out int settingChoice))
            {
                Console.WriteLine("Invalid input. Please try again.");
                Console.Write("Press any key to continue...");
                Console.ReadKey();
                return;
            }

            switch (settingChoice)
            {
                case 1:
                    UpdateAccountInformation();
                    break;
                case 2:
                    CloseAccount();
                    break;
                case 3:
                    LanguageSelection();
                    break;
                case 4:
                    ChangePIN();
                    break;
                case 5:
                    return; // Back to main menu
                default:
                    Console.WriteLine("Invalid setting option. Please select a valid option.");
                    Console.Write("Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }

        private void DoDeposit()
        {
            Console.Clear();
            Console.WriteLine("Deposit into an Account");
            Console.WriteLine("=======================");

            Console.Write("Enter account number: ");
            string accountNumber = Console.ReadLine();

            BankAccount account = FindAccount(accountNumber);
            if (account == null)
            {
                Console.WriteLine("Account not found.");
                Console.Write("Press any key to continue...");
                Console.ReadKey();
                return;
            }

            Console.Write("Enter deposit amount: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                account.Deposit(amount);
                Console.Write("Press any key to continue...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Invalid amount.");
                Console.Write("Press any key to continue...");
                Console.ReadKey();
            }
        }

        private void DoWithdraw()
        {
            Console.Clear();
            Console.WriteLine("Withdraw from an Account");
            Console.WriteLine("========================");

            Console.Write("Enter account number: ");
            string accountNumber = Console.ReadLine();

            BankAccount account = FindAccount(accountNumber);
            if (account == null)
            {
                Console.WriteLine("Account not found.");
                Console.Write("Press any key to continue...");
                Console.ReadKey();
                return;
            }

            Console.Write("Enter withdrawal amount: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                account.Withdraw(amount);
                Console.Write("Press any key to continue...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Invalid amount.");
                Console.Write("Press any key to continue...");
                Console.ReadKey();
            }
        }

        private void TransferFunds()
        {
            Console.Clear();
            Console.WriteLine("Transfer Funds Between Accounts");
            Console.WriteLine("===============================");

            Console.Write("Enter source account number: ");
            string sourceAccountNumber = Console.ReadLine();

            BankAccount sourceAccount = FindAccount(sourceAccountNumber);
            if (sourceAccount == null)
            {
                Console.WriteLine("Source account not found.");
                Console.Write("Press any key to continue...");
                Console.ReadKey();
                return;
            }

            Console.Write("Enter destination account number: ");
            string destAccountNumber = Console.ReadLine();

            BankAccount destAccount = FindAccount(destAccountNumber);
            if (destAccount == null)
            {
                Console.WriteLine("Destination account not found.");
                Console.Write("Press any key to continue...");
                Console.ReadKey();
                return;
            }

            Console.Write("Enter transfer amount: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                sourceAccount.Withdraw(amount);
                destAccount.Deposit(amount);
                Console.WriteLine($"Transfer successful. {amount:C} transferred from {sourceAccountNumber} to {destAccountNumber}.");
                Console.Write("Press any key to continue...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Invalid amount.");
                Console.Write("Press any key to continue...");
                Console.ReadKey();
            }
        }

        private void DoBalanceInquiry()
        {
            Console.Clear();
            Console.WriteLine("Balance Inquiry");
            Console.WriteLine("===============");

            Console.Write("Enter account number: ");
            string accountNumber = Console.ReadLine();

            BankAccount account = FindAccount(accountNumber);
            if (account == null)
            {
                Console.WriteLine("Account not found.");
                Console.Write("Press any key to continue...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"Account Balance for {accountNumber}: {account.Balance:C}");
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }

        private void DoMiniStatement()
        {
            Console.Clear();
            Console.WriteLine("Mini Statement");
            Console.WriteLine("==============");

            Console.Write("Enter account number: ");
            string accountNumber = Console.ReadLine();

            BankAccount account = FindAccount(accountNumber);
            if (account == null)
            {
                Console.WriteLine("Account not found.");
                Console.Write("Press any key to continue...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"Transaction History for Account {accountNumber}:");
            foreach (var transaction in account.GetTransactionHistory())
            {
                Console.WriteLine(transaction);
            }
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }

        private void UpdateAccountInformation()
        {
            Console.Clear();
            Console.WriteLine("Update Account Information");
            Console.WriteLine("==========================");

            Console.Write("Enter account number: ");
            string accountNumber = Console.ReadLine();

            BankAccount account = FindAccount(accountNumber);
            if (account == null)
            {
                Console.WriteLine("Account not found.");
                Console.Write("Press any key to continue...");
                Console.ReadKey();
                return;
            }

            // Simulated account information update process
            Console.WriteLine("Simulated update process...");
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }

        private void ChangePIN()
        {
            Console.Clear();
            Console.WriteLine("Change PIN");
            Console.WriteLine("==========");

            Console.Write("Enter current PIN: ");
            string currentPIN = Console.ReadLine();

            bool isCurrentPINValid = ValidatePIN(currentPIN);
            if (!isCurrentPINValid)
            {
                Console.WriteLine("Invalid PIN.");
                Console.Write("Press any key to continue...");
                Console.ReadKey();
                return;
            }

            // Simulated PIN change process
            Console.WriteLine("Simulated PIN change process...");
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }

        private void CloseAccount()
        {
            Console.Clear();
            Console.WriteLine("Close Account");
            Console.WriteLine("=============");

            Console.Write("Enter account number to close: ");
            string accountNumber = Console.ReadLine();

            BankAccount account = FindAccount(accountNumber);
            if (account == null)
            {
                Console.WriteLine("Account not found.");
                Console.Write("Press any key to continue...");
                Console.ReadKey();
                return;
            }

            accounts.Remove(account);
            Console.WriteLine($"Account {accountNumber} closed successfully.");
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }

        private void LanguageSelection()
        {
            Console.Clear();
            Console.WriteLine("Language Selection");
            Console.WriteLine("==================");

            Console.WriteLine("Select your preferred language:");
            Console.WriteLine("1. English");
            Console.WriteLine("2. Arabic");
            Console.Write("Enter option: ");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid input. Please try again.");
                Console.Write("Press any key to continue...");
                Console.ReadKey();
                return;
            }

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Language set to English.");
                    break;
                case 2:
                    Console.WriteLine("Language set to Arabic.");
                    break;
                default:
                    Console.WriteLine("Invalid option. Language remains unchanged.");
                    break;
            }

            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }

        private BankAccount FindAccount(string accountNumber)
        {
            return accounts.Find(acc => acc.AccountNumber == accountNumber);
        }

        private static bool ValidatePIN(string pin)
        {
            // Simulated PIN validation logic (compare against valid PINs)
            return pin == "1234" || pin == "123"; // Accept both "1234" and "123"
        }
    }

    public class BankAccount
    {
        public string AccountNumber { get; }
        public decimal Balance { get; private set; }
        public AccountType Type { get; }
        private decimal MinBalance;

        private List<string> transactionHistory;

        public BankAccount(string accountNumber, decimal initialBalance, AccountType type, decimal minBalance = 0)
        {
            AccountNumber = accountNumber;
            Balance = initialBalance;
            Type = type;
            MinBalance = minBalance;

            transactionHistory = new List<string>();
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Deposit amount must be positive.");
                return;
            }

            Balance += amount;
            LogTransaction($"Deposited {amount:C}. New balance: {Balance:C}");
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Withdrawal amount must be positive.");
                return;
            }

            if (Balance - amount < MinBalance)
            {
                Console.WriteLine("Withdrawal will leave account below minimum balance.");
                return;
            }

            Balance -= amount;
            LogTransaction($"Withdrawn {amount:C}. New balance: {Balance:C}");
        }

        public void LogTransaction(string transaction)
        {
            transactionHistory.Add($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {transaction}");
        }

        public IEnumerable<string> GetTransactionHistory()
        {
            return transactionHistory;
        }
    }

    public enum AccountType
    {
        Current,
        Savings,
        FixedDeposit,
        ForeignCurrency,
        YouthSavings,
        Business,
        Corporate,
        Investment,
        Student,
        EBanking
    }

}
