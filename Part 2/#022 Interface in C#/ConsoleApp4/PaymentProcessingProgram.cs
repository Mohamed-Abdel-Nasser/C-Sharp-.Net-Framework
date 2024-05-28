namespace PaymentProcessingSystem
{
    internal class PaymentProcessingProgram
    {
        static void Main(string[] args)
        {


            Cashier Cashier1 = new Cashier(new Cash());
            Cashier1.Checkout(99999.99m);

            Cashier Cashier2 = new Cashier(new Mastercard());
            Cashier2.Checkout(99999.99m);

            Cashier Cashier3 = new Cashier(new Visa());
            Cashier3.Checkout(10000);

            Cashier Cashier4 = new Cashier(new Debit());
            Cashier4.Checkout(20000);

            Console.ReadKey();

        }
    }
    class Cashier
    {
        private IPayment _payment;
        public Cashier(IPayment payment)
        {
            this._payment = payment;
        }
        public void Checkout(decimal amount)
        {
            this._payment.Pay(amount);
        }
    }
    class Cash : IPayment
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Cash Payment: ${Math.Round(amount, 2)}"); //$99,999.99
        }
    }
    class Visa : IPayment
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Visa Payment: ${Math.Round(amount, 2)}"); //$99,999.99
        }
    }

    class Mastercard : IPayment
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Mastercard Payment: ${Math.Round(amount, 2)}"); //$99,999.99
        }
    }
    class Debit : IPayment
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Debit Payment: ${Math.Round(amount, 2)}"); //$99,999.99
        }
    }
    interface IPayment
    {
        void Pay(decimal amount);
    }

}