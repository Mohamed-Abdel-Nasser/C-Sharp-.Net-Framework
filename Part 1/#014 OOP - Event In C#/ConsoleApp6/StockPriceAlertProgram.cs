namespace StockPriceAlertSystem
{
    // Define a delegate for event handling
    public delegate void StockPriceChangedEventHandler(string stockName, decimal oldPrice, decimal newPrice);
    class StockPriceAlertProgram
    {
        static void Main(string[] args)
        {
            // Create instances of the publisher and subscriber
            Stock googleStock = new Stock("GOOG", 2500.00m);
            StockMonitor monitor = new StockMonitor();

            // Subscribe the HandlePriceChanged method to the PriceChanged event
            googleStock.PriceChanged += monitor.HandlePriceChanged;

            // Simulate price changes
            googleStock.Price = 2550.00m;
            googleStock.Price = 2600.50m;

            Console.ReadKey();
        }
    }

    // Publisher class that triggers events
    public class Stock
    {
        private string _name;
        private decimal _price;

        public event StockPriceChangedEventHandler PriceChanged; // Event declaration

        public Stock(string name, decimal initialPrice)
        {
            _name = name;
            _price = initialPrice;
        }

        public decimal Price
        {
            get { return _price; }
            set
            {
                if (_price != value)
                {
                    decimal oldPrice = _price;
                    _price = value;
                    OnPriceChanged(oldPrice, _price); // Trigger event when price changes
                }
            }
        }

        protected virtual void OnPriceChanged(decimal oldPrice, decimal newPrice)
        {
            // Raise the PriceChanged event
            PriceChanged?.Invoke(_name, oldPrice, newPrice);
        }
    }

    // Subscriber class that reacts to events
    public class StockMonitor
    {
        public void HandlePriceChanged(string stockName, decimal oldPrice, decimal newPrice)
        {
            Console.WriteLine($"Stock '{stockName}' price changed from {oldPrice:C2} to {newPrice:C2}");
        }
    }
}
