namespace BankingSystem
{
    class BankingProgram
    {
        static void Main(string[] args)
        {
            // Create a savings account
            SavingsAccount savingsAccount = new SavingsAccount("John Doe", 5000, 0.02);
            Console.WriteLine("Savings Account Details:");
            Console.WriteLine(savingsAccount);

            // Deposit into savings account
            savingsAccount.Deposit(1000);
            Console.WriteLine("After deposit:");
            Console.WriteLine(savingsAccount);

            // Withdraw from savings account
            savingsAccount.Withdraw(200);
            Console.WriteLine("After withdrawal:");
            Console.WriteLine(savingsAccount);

            // Create a checking account
            CheckingAccount checkingAccount = new CheckingAccount("Jane Smith", 3000, 500);
            Console.WriteLine("\nChecking Account Details:");
            Console.WriteLine(checkingAccount);

            // Withdraw from checking account
            checkingAccount.Withdraw(400);
            Console.WriteLine("After withdrawal:");
            Console.WriteLine(checkingAccount);

            // Try to withdraw more than the overdraft limit
            checkingAccount.Withdraw(3500);
            Console.WriteLine("After attempted overdraft:");
            Console.WriteLine(checkingAccount);

            Console.ReadKey();
        }
    }

    public abstract class BankAccount
    {
        public string AccountHolder { get; }
        public double Balance { get; protected set; }

        public BankAccount(string accountHolder, double initialBalance)
        {
            AccountHolder = accountHolder;
            Balance = initialBalance;
        }

        public abstract void Withdraw(double amount);
        public void Deposit(double amount)
        {
            if (amount > 0)
                Balance += amount;
        }

        public override string ToString()
        {
            return $"Account Holder: {AccountHolder}, Balance: {Balance:C}";
        }
    }

    public class SavingsAccount : BankAccount
    {
        public double InterestRate { get; }

        public SavingsAccount(string accountHolder, double initialBalance, double interestRate)
            : base(accountHolder, initialBalance)
        {
            InterestRate = interestRate;
        }

        public override void Withdraw(double amount)
        {
            if (amount > 0 && amount <= Balance)
            {
                Balance -= amount;
            }
        }

        public void ApplyInterest()
        {
            Balance *= (1 + InterestRate);
        }

        public override string ToString()
        {
            return $"Savings Account: {base.ToString()}, Interest Rate: {InterestRate:P}";
        }
    }

    public class CheckingAccount : BankAccount
    {
        public double OverdraftLimit { get; }

        public CheckingAccount(string accountHolder, double initialBalance, double overdraftLimit)
            : base(accountHolder, initialBalance)
        {
            OverdraftLimit = overdraftLimit;
        }

        public override void Withdraw(double amount)
        {
            if (amount > 0 && (Balance + OverdraftLimit) >= amount)
            {
                Balance -= amount;
            }
        }

        public override string ToString()
        {
            return $"Checking Account: {base.ToString()}, Overdraft Limit: {OverdraftLimit:C}";
        }
    }
}
