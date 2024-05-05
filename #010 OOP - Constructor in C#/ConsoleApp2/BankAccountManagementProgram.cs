namespace BankAccountManagementSystem
{
    class BankAccountManagementProgram
    {
        static void Main()
        {
            BankAccount account1 = new BankAccount();
            Console.WriteLine(account1);

            BankAccount account2 = new BankAccount("John Doe", 5000m);
            Console.WriteLine(account2);

            account1.Deposit(1000m);
            account1.Withdraw(500m);
            Console.WriteLine(account1);
        }
    }
    public class BankAccount
    {
        public string AccountNumber { get; }
        public string AccountHolder { get; }
        public decimal Balance { get; private set; }

        // Default constructor
        public BankAccount()
        {
            AccountNumber = GenerateAccountNumber();
            AccountHolder = "Unknown";
            Balance = 0;
        }

        // Parameterized constructor for known account holder
        public BankAccount(string accountHolder, decimal initialBalance)
        {
            AccountNumber = GenerateAccountNumber();
            AccountHolder = accountHolder;
            Balance = initialBalance;
        }

        // Private method to generate a random account number
        private string GenerateAccountNumber()
        {
            Random random = new Random();
            return $"{random.Next(100000, 999999)}-{random.Next(1000, 9999)}";
        }

        // Method to deposit funds into the account
        public void Deposit(decimal amount)
        {
            if (amount > 0)
                Balance += amount;
        }

        // Method to withdraw funds from the account
        public void Withdraw(decimal amount)
        {
            if (amount > 0 && amount <= Balance)
                Balance -= amount;
        }

        public override string ToString()
        {
            return $"Account Number: {AccountNumber}, Holder: {AccountHolder}, Balance: {Balance:C}";
        }
    }

}
