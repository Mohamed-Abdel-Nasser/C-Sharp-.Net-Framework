namespace CurrencyManagerSystem
{
    internal class CurrencyManagerProgram
    {
        static void Main(string[] args)
        {
            Dollar dollar = new Dollar(1.99m);
            dollar.Amount = 1.99m;
            // Set the amount using a public method (setAmount) instead of directly accessing the property
            // dollar.setAmount(1.99m);

            Console.WriteLine(dollar.Amount); // get
            Console.ReadKey();
        }
    }
    public class Dollar
    {
        private decimal _amount;
        public decimal Amount
        {
            get
            {
                return this._amount;
            }
            set
            {
                this._amount = value;
            }
        }
        public Dollar(decimal amount)
        {
            this._amount = processValue(amount);
        }
        public void setAmount(decimal value)
        {
            this.Amount = value;
        }
        public decimal processValue(decimal value) => value <= 0 ? 0 : Math.Round(value);

    }

}
