namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class Money
    {
        private decimal _amount;

        public Money(decimal value)
        {
            this._amount = Math.Round(value, 2);

        }

        public decimal Amount => this._amount;

        public static Money operator +(Money money1, Money money2)
        {
            var value = money1.Amount + money2.Amount;
            return new Money(value);
        }

        public static Money operator -(Money money1, Money money2)
        {
            var value = money1.Amount - money2.Amount;
            return new Money(value);
        }

        public static bool operator >(Money money1, Money money2)
        {
            return money1.Amount > money2.Amount;

        }

        public static bool operator <(Money money1, Money money2)
        {
            return money1.Amount < money2.Amount;
        }
    }


}
