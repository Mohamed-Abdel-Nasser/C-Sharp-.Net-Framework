
namespace BankingSystem
{
    class BankingProgram
    {
        static void Main(string[] args)
        {
            // Create a new bank
            Bank myBank = new Bank("MyBank");

            // Create customer accounts
            Customer customer1 = new Customer("John Doe");
            Customer customer2 = new Customer("Jane Smith");

            // Open accounts for customers
            Account account1 = myBank.OpenAccount(customer1, AccountType.Checking);
            Account account2 = myBank.OpenAccount(customer2, AccountType.Savings);

            // Perform transactions
            account1.Deposit(1000);
            account2.Deposit(500);

            Console.WriteLine("Account Information:");
            Console.WriteLine(account1.GetAccountInfo());
            Console.WriteLine(account2.GetAccountInfo());

            account1.Withdraw(200);
            account2.Transfer(account1, 300);

            Console.WriteLine("\nUpdated Account Information:");
            Console.WriteLine(account1.GetAccountInfo());
            Console.WriteLine(account2.GetAccountInfo());

            Console.ReadKey();
        }
    }
    public enum AccountType
    {
        Checking,
        Savings,
        Investment
    }
    public class Bank
    {
        public string Name { get; private set; }
        private List<Account> accounts;

        public Bank(string name)
        {
            Name = name;
            accounts = new List<Account>();
        }

        public Account OpenAccount(Customer customer, AccountType accountType)
        {
            Account account = new Account(customer, accountType);
            accounts.Add(account);
            return account;
        }
    }
    public class Customer
    {
        public string Name { get; private set; }

        public Customer(string name)
        {
            Name = name;
        }
    }
    public class Account
    {
        public Customer Customer { get; private set; }
        public AccountType Type { get; private set; }
        public decimal Balance { get; private set; }

        public Account(Customer customer, AccountType type)
        {
            Customer = customer;
            Type = type;
            Balance = 0;
        }

        public void Deposit(decimal amount)
        {
            if (amount > 0)
                Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount > 0 && amount <= Balance)
                Balance -= amount;
            else
                Console.WriteLine("Invalid withdrawal amount or insufficient funds.");
        }

        public void Transfer(Account destinationAccount, decimal amount)
        {
            if (destinationAccount != null && amount > 0 && amount <= Balance)
            {
                Withdraw(amount);
                destinationAccount.Deposit(amount);
            }
            else
            {
                Console.WriteLine("Invalid transfer request.");
            }
        }

        public string GetAccountInfo()
        {
            return $"Account Type: {Type}, Customer: {Customer.Name}, Balance: {Balance:C}";
        }
    }
}
