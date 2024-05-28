using System.Reflection;

namespace ConsoleApp2
{
    internal class Program
    {

        static void Main(string[] args)
        {
            BankAccount account = new BankAccount("A132", "Mohamed Nasser", 1000);
            account.OnNegativeBalance += Account_OnNegativeBalance;
            account.Withdraw(500);
            account.Withdraw(500);
            account.Withdraw(200);
            Console.WriteLine(account);

            Console.WriteLine("\n==================================================\n");

            var account2 = new BankAccount("A123", " Mohamed NAsser ", 0);
            Type type = typeof(BankAccount);
            Type[] parametersType = { typeof(decimal) };
            MethodInfo method = type.GetMethod("Deposit");
            method.Invoke(account2, new object[] { 500m });
            Console.WriteLine(account2);
            Console.ReadKey();

            Console.WriteLine("\n==================================================\n");

            //Console.WriteLine("MemberInfo");
            //MemberInfo[] members = typeof(BankAccount).GetMembers(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            //foreach (var member in members)
            //{
            //    Console.WriteLine(member);
            //}
            //Console.ReadKey();


            //Console.WriteLine("\n================================================================\n");

            //Console.WriteLine("FieldInfo");
            //FieldInfo[] fields = typeof(BankAccount).GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            //foreach (var field in fields)
            //{
            //    Console.WriteLine(field);
            //}


            //Console.WriteLine("PropertyInfo");
            //PropertyInfo[] Properties = typeof(BankAccount).GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            //foreach (var Property in Properties)
            //{
            //    Console.WriteLine(Property.GetGetMethod());
            //    Console.WriteLine(Property);
            //}


            //Console.WriteLine("EventInfo");
            //EventInfo[] Events = typeof(BankAccount).GetEvents(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            //foreach (var Event in Events)
            //{
            //    Console.WriteLine(Event);
            //}


            //Console.WriteLine("ConstructorInfo");
            //ConstructorInfo[] Constructors = typeof(BankAccount).GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            //foreach (var Constructor in Constructors)
            //{
            //    Console.WriteLine(Constructor);
            //}

            //Console.ReadKey();



        }

        private static void Account_OnNegativeBalance(object? sender, EventArgs e)
        {
            var bankAccount = (BankAccount)sender;
            Console.WriteLine("NEGATIVE BALANCE !!!");
        }
    }

    public class BankAccount
    {
        private string accountNo;
        private string holder;
        private decimal balance;

        public string AccountNo => accountNo;
        public string Holder => holder;
        public decimal Balance => balance;

        public event EventHandler OnNegativeBalance;
        public BankAccount(string accountNo, string holder, decimal balance)
        {
            this.accountNo = accountNo;
            this.holder = holder;
            this.balance = balance;
        }

        public void Deposit(decimal amount)
        {
            this.balance += amount;
        }
        public void Withdraw(decimal amount)
        {
            this.balance -= amount;
            if (this.balance < 0)

                this.OnNegativeBalance.Invoke(this, null);
        }


        public override string ToString()
        {
            return $"{{ Account No.: {accountNo}, Holder: {holder}, Balance: ${balance}}}";

        }
    }
}