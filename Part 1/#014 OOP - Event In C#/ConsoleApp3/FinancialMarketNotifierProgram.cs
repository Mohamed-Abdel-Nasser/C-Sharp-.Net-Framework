
namespace StockPriceNotifierSystem
{
    class FinancialMarketNotifierProgram
    {
        static void Main(string[] args)
        {
            var appleStock = new Stock("Apple");
            appleStock.Price = 150;

            var microsoftStock = new Stock("Microsoft");
            microsoftStock.Price = 200;

            // Subscribe to price changes for Apple stock
            appleStock.OnPriceChanged += (stock, oldPrice) =>
            {
                Console.ForegroundColor = GetColor(stock.Price, oldPrice);
                Console.WriteLine($"{stock.Name}: ${stock.Price} - {GetChangeIndicator(stock.Price, oldPrice)}");
            };

            // Subscribe to price changes for Microsoft stock
            microsoftStock.OnPriceChanged += (stock, oldPrice) =>
            {
                Console.ForegroundColor = GetColor(stock.Price, oldPrice);
                Console.WriteLine($"{stock.Name}: ${stock.Price} - {GetChangeIndicator(stock.Price, oldPrice)}");
            };

            // Simulate price changes
            appleStock.ChangeStockPriceBy(0.03m); // Increase Apple stock price
            microsoftStock.ChangeStockPriceBy(-0.05m); // Decrease Microsoft stock price

            Console.ReadKey();
        }

        private static string GetChangeIndicator(decimal currentPrice, decimal oldPrice)
        {
            if (currentPrice > oldPrice)
                return "up";
            else if (currentPrice < oldPrice)
                return "down";
            else
                return "unchanged";
        }

        private static ConsoleColor GetColor(decimal currentPrice, decimal oldPrice)
        {
            if (currentPrice > oldPrice)
                return ConsoleColor.Green;
            else if (currentPrice < oldPrice)
                return ConsoleColor.Red;
            else
                return ConsoleColor.Gray;
        }

    }

    public delegate void StockPriceChangeHandler(Stock stock, decimal oldPrice);

    public class Stock
    {
        private string name;
        private decimal price;

        public event StockPriceChangeHandler OnPriceChanged;

        public string Name => this.name;
        public decimal Price { get => this.price; set => this.price = value; }

        public Stock(string stockName)
        {
            this.name = stockName;
        }

        public void ChangeStockPriceBy(decimal percent)
        {
            decimal oldPrice = this.price;
            this.price += Math.Round(this.price * percent, 2);
            OnPriceChanged?.Invoke(this, oldPrice);
        }
    }
}
