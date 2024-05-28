using System;

namespace FinancialPortfolioManagerSystem
{
    class FinancialPortfolioManagerProgram
    {
        static void Main()
        {
            try
            {
                // Create financial instruments
                IFinancialInstrument[] instruments =
                {
                    new Stock("AAPL", 150.50m),
                    new Bond("GOV1", 1000.00m),
                    new Stock("MSFT", 300.25m)
                };

                // Create a portfolio with initial instruments
                Portfolio portfolio = new Portfolio(instruments);

                // Calculate and display the total portfolio value
                decimal totalValue = portfolio.CalculateTotalValue();
                DisplayHeader("Initial Portfolio");
                DisplayPortfolio(portfolio);
                DisplayTotalValue(totalValue);

                // Add a new instrument to the portfolio
                IFinancialInstrument newInstrument = new Stock("GOOG", 2500.75m);
                portfolio = portfolio.AddInstrument(newInstrument);

                // Recalculate and display the updated total portfolio value
                totalValue = portfolio.CalculateTotalValue();
                DisplayHeader("Updated Portfolio");
                DisplayPortfolio(portfolio);
                DisplayTotalValue(totalValue);
            }
            catch (ArgumentNullException ex)
            {
                DisplayError($"Error: {ex.ParamName} is null.");
            }
            catch (Exception ex)
            {
                DisplayError($"An error occurred: {ex.Message}");
            }

            Console.ReadKey();
        }

        static void DisplayHeader(string header)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(new string('=', 30));
            Console.WriteLine(header);
            Console.WriteLine(new string('=', 30));
            Console.ResetColor();
        }

        static void DisplayPortfolio(Portfolio portfolio)
        {
            foreach (var instrument in portfolio.Instruments)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Instrument: {instrument.GetType().Name}");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"  Symbol: {instrument.Symbol}");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"  Price: ${instrument.Price:F2}");
                Console.ResetColor();
                Console.WriteLine();
            }
        }

        static void DisplayTotalValue(decimal totalValue)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Total Portfolio Value: ${totalValue:F2}");
            Console.ResetColor();
        }

        static void DisplayError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }

    // Define an interface for financial instruments
    public interface IFinancialInstrument
    {
        string Symbol { get; }
        decimal Price { get; }
    }

    // Define concrete implementations of financial instruments
    public class Stock : IFinancialInstrument
    {
        public string Symbol { get; }
        public decimal Price { get; }

        public Stock(string symbol, decimal price)
        {
            Symbol = symbol;
            Price = price;
        }
    }

    public class Bond : IFinancialInstrument
    {
        public string Symbol { get; }
        public decimal Price { get; }

        public Bond(string symbol, decimal price)
        {
            Symbol = symbol;
            Price = price;
        }
    }

    // Define the Portfolio struct to hold a collection of financial instruments
    public struct Portfolio
    {
        public IFinancialInstrument[] Instruments { get; }

        public Portfolio(IFinancialInstrument[] instruments)
        {
            Instruments = instruments ?? throw new ArgumentNullException(nameof(instruments), "Instruments array is null.");
        }

        public decimal CalculateTotalValue()
        {
            decimal totalValue = 0m;
            foreach (var instrument in Instruments)
            {
                totalValue += instrument.Price;
            }
            return totalValue;
        }

        public Portfolio AddInstrument(IFinancialInstrument instrument)
        {
            if (instrument == null)
                throw new ArgumentNullException(nameof(instrument), "Instrument is null.");

            // Create a new array with the added instrument
            var newInstruments = new IFinancialInstrument[Instruments.Length + 1];
            Array.Copy(Instruments, newInstruments, Instruments.Length);
            newInstruments[Instruments.Length] = instrument;

            return new Portfolio(newInstruments);
        }
    }
}
