using System;
using System.Collections.Generic;
using System.Diagnostics;
namespace NationalBankOfEgyptATMSystem
{
    public class ATMProgram
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Welcome to National Bank Of Egypt ATM System!");
            Console.WriteLine("==============================================");
            Console.ResetColor();

            var accounts = new List<BankAccount>
            {
                new BankAccount("1923456789", 1000, AccountType.CURRENT, 50),
                new BankAccount("2987654321", 1500, AccountType.SAVINGS, 100),
                new BankAccount("3987654322", 2000, AccountType.FOREIGNCURRENCY, 150),
                new BankAccount("4987654323", 2500, AccountType.YOUTHSAVINGS, 200),
                new BankAccount("5987654324", 3000, AccountType.BUSINESS, 250),
                new BankAccount("6987654325", 3500, AccountType.CORPORATE, 300),
                new BankAccount("7987654326", 4000, AccountType.INVESTMENT, 350),
                new BankAccount("8987654327", 4500, AccountType.STUDENT, 400),
                new BankAccount("987654328", 5000, AccountType.EBANKING, 500),

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

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Welcome to National Bank Of Egypt ATM System!");
            Console.WriteLine("==============================================");
            Console.ResetColor();

            Console.WriteLine("1. Open Account");
            Console.WriteLine("2. Insert Card");
            Console.WriteLine("3. Exit");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("==============================================");
            Console.Write("Enter option: ");
            Console.ResetColor();


            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please try again.");
                Console.Write("Press any key to continue...");
                Console.ReadKey();
                return;
            }

            switch (choice)
            {
                case 1:
                    ShowAccountOpeningNotes();
                    OpenAccount();
                    break;
                case 2:
                    InsertCard();
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Exiting ATM. Goodbye!");
                    Console.ResetColor();
                    ShouldExit = true;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid option. Please select a valid option.");
                    Console.Write("Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }


        private void ShowAccountOpeningNotes()
        {
            Console.Clear();

            // Title
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Opening Account Documents at the National Bank of Egypt (NBE):");
            Console.WriteLine("================================================================");
            Console.ResetColor();

            // Notes
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nNotes:");
            Console.ResetColor();
            Console.WriteLine("  → In order for the account opening process to be completed correctly," +
                "\n    please enter the required documents into the Document reader slot to scan them.\n");

            // Basic Documents
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Basic Documents:");
            Console.ResetColor();
            Console.WriteLine("  → Copy of a valid ID card or passport.");
            Console.WriteLine("  → Proof of address (recent electricity or water bill).");
            Console.WriteLine("  → Recent passport-sized photo.");
            Console.WriteLine("  → Account opening application form (available from the bank branch).\n");

            // Additional Documents by Account Type
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Additional Documents by Account Type:");
            Console.ResetColor();
            Console.WriteLine("  → Current Account: No additional documents required.");
            Console.WriteLine("  → Savings Account: No additional documents required.");
            Console.WriteLine("  → Fixed Deposit Account: Proof of income (bank statement or tax return).");
            Console.WriteLine("  → Foreign Currency Account: Proof of the source of the foreign currency.");
            Console.WriteLine("  → Youth Savings Account: Birth certificate or student ID card.");
            Console.WriteLine("  → Current Account for Businesses: Business documents (commercial registration certificate or trade license).");
            Console.WriteLine("  → Corporate Current Account: Business documents (commercial registration certificate or trade license)," +
                                 "\n    and documents proving the company's qualifications.");
            Console.WriteLine("  → Investment Account: Proof of income (bank statement or tax return) and documents indicating the type of investments.");
            Console.WriteLine("  → Student Account: Birth certificate or student ID card.");
            Console.WriteLine("  → E-Banking Account: Proof of ownership of a mobile phone or email address.\n");

            // Prompt to continue
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Press any key to continue...");
            Console.ResetColor();
            Console.ReadKey();

            OpenAccount();
        }
        private void OpenAccount()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Open Account");
            Console.WriteLine("============");
            Console.ResetColor();

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

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("========================");
            Console.Write("Enter an option: ");
            Console.ResetColor();

            if (!int.TryParse(Console.ReadLine(), out int accountTypeChoice))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please try again.");
                Console.Write("Press any key to continue...");
                Console.ReadKey();
                return;
            }

            if (accountTypeChoice < 1 || accountTypeChoice > 11)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid account type option. Please select a valid option.");
                Console.Write("Press any key to continue...");
                Console.ReadKey();
                return;
            }

            if (accountTypeChoice == 11)
            {
                return; // Back to main menu

            }

            AccountType selectedAccountType = (AccountType)(accountTypeChoice - 1);

            Console.Write("Enter initial deposit amount: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal initialDeposit) || initialDeposit < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid deposit amount. Account creation failed.");
                Console.Write("Press any key to continue...");
                Console.ReadKey();
                return;
            }

            string newAccountNumber = GenerateAccountNumber();
            BankAccount newAccount = new BankAccount(newAccountNumber, initialDeposit, selectedAccountType);
            accounts.Add(newAccount);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Account created successfully. Account Number: {newAccountNumber}");
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }

        private string GenerateAccountNumber()
        {
            Random random = new Random();
            return random.Next(10000000, 99999999).ToString();
        }

        private void InsertCard()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Insert Card");
            Console.WriteLine("=============");
            Console.ResetColor();

            Console.WriteLine("Insert ATM card into the card reader slot.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            EnterPIN();
        }

        private void EnterPIN()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Enter PIN");
            Console.WriteLine("==========");
            Console.ResetColor();

            Console.Write("Enter your personal identification number (PIN) using the keypad: ");
            string pin = Console.ReadLine();

            if (ValidatePIN(pin))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("PIN accepted. Access granted.");
                Console.Write("Press any key to continue...");
                Console.ResetColor();
                Console.ReadKey();

                // Show main menu after successful PIN entry
                ShowMainMenu();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
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
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Main Menu");
                Console.WriteLine("=========");
                Console.ResetColor();

                Console.WriteLine("1. New Transaction");
                Console.WriteLine("2. Reporting");
                Console.WriteLine("3. Settings");
                Console.WriteLine("4. Exit");

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("==============================================");
                Console.Write("Enter option: ");
                Console.ResetColor();

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please try again.");
                    Console.Write("Press any key to continue...");
                    Console.ReadKey();
                    continue;
                }

                switch (choice)
                {

                    case 1:
                        NewTransactionMenu();
                        break;
                    case 2:
                        ReportingMenu();
                        break;
                    case 3:
                        SettingMenu();
                        break;
                    case 4:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Exiting ATM. Goodbye!");
                        Console.ResetColor();
                        ShouldExit = true;
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid option. Please select a valid option.");
                        Console.Write("Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }


        private void NewTransactionMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("New Transaction");
            Console.WriteLine("================");
            Console.ResetColor();

            Console.WriteLine("1. Deposit into an Account");
            Console.WriteLine("2. Withdraw from an Account");
            Console.WriteLine("3. Transfer Funds Between Accounts");
            Console.WriteLine("4. Back");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("=====================================");
            Console.Write("Enter transaction type option: ");
            Console.ResetColor();

            if (!int.TryParse(Console.ReadLine(), out int transactionChoice))
            {
                Console.ForegroundColor = ConsoleColor.Red;
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
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid transaction type. Please select a valid option.");
                    Console.Write("Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }

        private void ReportingMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Reporting");
            Console.WriteLine("=========");
            Console.ResetColor();

            Console.WriteLine("1. Balance Inquiry");
            Console.WriteLine("2. Mini Statement");
            Console.WriteLine("3. Back");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("=========================");
            Console.Write("Enter reporting option: ");
            Console.ResetColor();

            if (!int.TryParse(Console.ReadLine(), out int reportChoice))
            {
                Console.ForegroundColor = ConsoleColor.Red;
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
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid reporting option. Please select a valid option.");
                    Console.Write("Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }

        private void SettingMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Settings");
            Console.WriteLine("========");
            Console.ResetColor();

            Console.WriteLine("1. Update Account Information");
            Console.WriteLine("2. Close Account");
            Console.WriteLine("3. Language Selection");
            Console.WriteLine("4. Change PIN");
            Console.WriteLine("5. Back");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("====================");
            Console.Write("Enter setting option: ");
            Console.ResetColor();

            if (!int.TryParse(Console.ReadLine(), out int settingChoice))
            {
                Console.ForegroundColor = ConsoleColor.Red;
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
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid setting option. Please select a valid option.");
                    Console.Write("Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }


        private void DoDeposit()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Deposit into an Account");
            Console.WriteLine("=======================");
            Console.ResetColor();
            Console.Write("Enter account number: ");
            string accountNumber = Console.ReadLine();

            BankAccount account = FindAccount(accountNumber);
            if (account == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Account not found.");
                Console.Write("Press any key to continue...");
                Console.ReadKey();
                return;
            }

            Console.Write("Enter deposit amount: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                account.Deposit(amount);
                Console.Write("Press any key to continue...");
                Console.ReadKey();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid amount.");
                Console.Write("Press any key to continue...");
                Console.ReadKey();
            }
        }

        private void DoWithdraw()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Withdraw from an Account");
            Console.WriteLine("========================");
            Console.ResetColor();

            Console.Write("Enter account number: ");
            string accountNumber = Console.ReadLine();

            BankAccount account = FindAccount(accountNumber);
            if (account == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Account not found.");
                Console.Write("Press any key to continue...");
                Console.ReadKey();
                return;
            }

            Console.Write("Enter withdrawal amount: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                account.Withdraw(amount);
                Console.Write("Press any key to continue...");
                Console.ReadKey();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid amount.");
                Console.Write("Press any key to continue...");
                Console.ReadKey();
            }
        }

        private void TransferFunds()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Transfer Funds Between Accounts");
            Console.WriteLine("===============================");
            Console.ResetColor();

            Console.Write("Enter source account number: ");
            string sourceAccountNumber = Console.ReadLine();

            BankAccount sourceAccount = FindAccount(sourceAccountNumber);
            if (sourceAccount == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
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
                Console.ForegroundColor = ConsoleColor.Red;
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
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Transfer successful. {amount:C} transferred from {sourceAccountNumber} to {destAccountNumber}.");
                Console.Write("Press any key to continue...");
                Console.ReadKey();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid amount.");
                Console.Write("Press any key to continue...");
                Console.ReadKey();
            }
        }

        private void DoBalanceInquiry()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Balance Inquiry");
            Console.WriteLine("===============");
            Console.ResetColor();

            Console.Write("Enter account number: ");
            string accountNumber = Console.ReadLine();

            BankAccount account = FindAccount(accountNumber);
            if (account == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
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
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Mini Statement");
            Console.WriteLine("==============");
            Console.ResetColor();

            Console.Write("Enter account number: ");
            string accountNumber = Console.ReadLine();

            BankAccount account = FindAccount(accountNumber);
            if (account == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
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
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Update Account Information");
            Console.WriteLine("==========================");
            Console.ResetColor();

            Console.Write("Enter account number: ");
            string accountNumber = Console.ReadLine();

            BankAccount account = FindAccount(accountNumber);
            if (account == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
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
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Change PIN");
            Console.WriteLine("==========");

            Console.Write("Enter current PIN: ");
            string currentPIN = Console.ReadLine();

            bool isCurrentPINValid = ValidatePIN(currentPIN);
            if (!isCurrentPINValid)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid PIN.");
                Console.ResetColor();
                Console.Write("Press any key to continue...");
                Console.ReadKey();
                return;
            }

            Console.Write("Enter new PIN: ");
            string newPIN = Console.ReadLine();

            Console.Write("Confirm new PIN: ");
            string confirmPIN = Console.ReadLine();

            if (newPIN != confirmPIN)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("PINs do not match. PIN change failed.");
                Console.ResetColor();
                Console.Write("Press any key to continue...");
                Console.ReadKey();
                return;
            }

            // Update PIN here (simulated)
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("PIN Changed Successfully");
            Console.ResetColor();
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }

        private void CloseAccount()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Close Account");
            Console.WriteLine("=============");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Enter account number to close: ");
            Console.ResetColor();
            string accountNumber = Console.ReadLine();

            BankAccount account = FindAccount(accountNumber);
            if (account == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Account not found.");
                Console.Write("Press any key to continue...");
                Console.ReadKey();
                return;
            }

            accounts.Remove(account);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Account {accountNumber} closed successfully.");
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }

        private void LanguageSelection()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Language Selection");
            Console.WriteLine("==================");
            Console.ResetColor();

            Console.WriteLine("Select your preferred language:");
            Console.WriteLine("1. English");
            Console.WriteLine("2. Arabic");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("===================");
            Console.Write("Enter option: ");
            Console.ResetColor();

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please try again.");
                Console.Write("Press any key to continue...");
                Console.ReadKey();
                return;
            }

            switch (choice)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Language set to English.");
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Language set to Arabic.");
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid option. Language remains unchanged.");
                    break;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Press any key to continue...");
            Console.ReadKey();
            Console.ResetColor();
        }

        private BankAccount FindAccount(string accountNumber)
        {
            return accounts.Find(acc => acc.AccountNumber == accountNumber);
        }

        private static bool ValidatePIN(string pin)
        {
            // Simulated PIN validation logic (compare against valid PINs)
            return pin == "123"; // Validate PIN 
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
            this.AccountNumber = accountNumber;
            this.Balance = initialBalance;
            this.Type = type;
            this.MinBalance = minBalance;
            this.transactionHistory = new List<string>();
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Withdrawal amount must be positive.");
                return;
            }

            if (Balance - amount < MinBalance)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Withdrawal will leave account below minimum balance.");
                return;
            }

            Balance -= amount;
            LogTransaction($"Withdrawn {amount:C}. New balance: {Balance:C}");
        }

        public void LogTransaction(string transaction)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            transactionHistory.Add($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {transaction}");
        }

        public IEnumerable<string> GetTransactionHistory()
        {
            return transactionHistory;
        }
    }

    public enum AccountType
    {
        CURRENT,
        SAVINGS,
        FIXEDDEPOSIT,
        FOREIGNCURRENCY,
        YOUTHSAVINGS,
        BUSINESS,
        CORPORATE,
        INVESTMENT,
        STUDENT,
        EBANKING
    }

}
