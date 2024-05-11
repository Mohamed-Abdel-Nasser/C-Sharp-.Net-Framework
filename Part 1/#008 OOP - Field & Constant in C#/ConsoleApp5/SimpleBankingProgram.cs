namespace SimpleBankingSystem
{
    class SimpleBankingProgram
    {
        static void Main(string[] args)
        {
            // Create an instance of a bank account
            BankAccount myAccount = new BankAccount("Mohamed Nasser", 1000.00);

            // Display account information
            Console.WriteLine($"Account Holder: {myAccount.AccountHolder}");
            Console.WriteLine($"Balance: ${myAccount.Balance:F2}");

            // Perform transactions
            myAccount.Deposit(500.00);
            Console.WriteLine($"Deposited $500.00. New Balance: ${myAccount.Balance:F2}");

            myAccount.Withdraw(300.00);
            Console.WriteLine($"Withdrawn $300.00. New Balance: ${myAccount.Balance:F2}");

            Console.ReadKey();
        }
    }

    public class BankAccount
    {
        private string accountHolder;
        private double balance;

        public const double WithdrawalFee = 1.00;

        public BankAccount(string accountHolder, double initialBalance)
        {
            this.accountHolder = accountHolder;
            this.balance = initialBalance;
        }

        public string AccountHolder
        {
            get { return accountHolder; }
        }

        public double Balance
        {
            get { return balance; }
        }

        public void Deposit(double amount)
        {
            if (amount > 0)
                balance += amount;
        }

        public void Withdraw(double amount)
        {
            if (amount > 0 && amount <= balance)
            {
                balance -= amount;
                balance -= WithdrawalFee; // Apply withdrawal fee
            }
            else
            {
                Console.WriteLine("Invalid withdrawal amount or insufficient funds.");
            }
        }
    }
}
