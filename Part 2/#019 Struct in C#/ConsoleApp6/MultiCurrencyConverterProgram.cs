using System;
using System.Collections.Generic;

namespace MultiCurrencyConverterTool
{
    class MultiCurrencyConverterProgram
    {
        static void Main()
        {
            try
            {
                // Initialize a dictionary to store exchange rates for easy lookup
                Dictionary<string, Dictionary<string, decimal>> exchangeRates = new Dictionary<string, Dictionary<string, decimal>>
                {
                    // Exchange rates for Arab countries
                    { "AED", new Dictionary<string, decimal> { { "USD", 0.27m }, { "EUR", 0.23m }, { "EGP", 4.34m } } }, // United Arab Emirates Dirham
                    { "SAR", new Dictionary<string, decimal> { { "USD", 0.27m }, { "EUR", 0.23m }, { "EGP", 4.30m } } }, // Saudi Riyal
                    { "QAR", new Dictionary<string, decimal> { { "USD", 0.27m }, { "EUR", 0.23m }, { "EGP", 4.31m } } }, // Qatari Riyal

                    // Exchange rates for European countries
                    { "GBP", new Dictionary<string, decimal> { { "USD", 1.39m }, { "EUR", 1.18m }, { "CHF", 1.28m }, { "EGP", 23.75m } } }, // British Pound
                    { "EUR", new Dictionary<string, decimal> { { "USD", 1.18m }, { "GBP", 0.85m }, { "CHF", 1.08m }, { "EGP", 20.13m } } }, // Euro
                    { "CHF", new Dictionary<string, decimal> { { "USD", 1.10m }, { "EUR", 0.93m }, { "GBP", 0.78m }, { "EGP", 18.28m } } }, // Swiss Franc

                    // Egypt currency
                    { "EGP", new Dictionary<string, decimal> { { "USD", 0.042m }, { "EUR", 0.050m }, { "GBP", 0.042m }, { "CHF", 0.055m } } }, // Egyptian Pound

                    // USD (United States Dollar)
                    { "USD", new Dictionary<string, decimal> { { "EUR", 0.85m }, { "GBP", 0.72m }, { "CHF", 0.91m }, { "EGP", 23.75m } } },
                };

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Welcome to the Currency Converter!");
                Console.WriteLine("===================================");
                Console.ResetColor();

                // Create a CurrencyConverter instance
                CurrencyConverter converter = new CurrencyConverter(exchangeRates);

                // Display available currencies with index numbers
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Available Currencies:");
                List<string> currencyCodes = new List<string>(exchangeRates.Keys);
                for (int i = 0; i < currencyCodes.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {currencyCodes[i]}");
                }
                Console.WriteLine("===================================");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("How would you like to select currencies?");
                Console.WriteLine("1. By currency code (e.g., USD, EUR)");
                Console.WriteLine("2. By currency position number (e.g., 1, 2)");
                Console.ResetColor();
                Console.Write("Enter option (1 or 2): ");
                int option = int.Parse(Console.ReadLine());

                if (option != 1 && option != 2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid option. Please select 1 or 2.");
                    Console.ResetColor();
                    return;
                }

                Console.Write($"Enter {(option == 1 ? "source" : "source position")} currency: ");
                string sourceCurrencyInput = Console.ReadLine().ToUpper();

                string sourceCurrency = (option == 1) ? sourceCurrencyInput : currencyCodes[int.Parse(sourceCurrencyInput) - 1];

                Console.Write($"Enter {(option == 1 ? "target" : "target position")} currency: ");
                string targetCurrencyInput = Console.ReadLine().ToUpper();

                string targetCurrency = (option == 1) ? targetCurrencyInput : currencyCodes[int.Parse(targetCurrencyInput) - 1];

                Console.Write($"Enter amount in {sourceCurrency}: ");
                decimal amount = decimal.Parse(Console.ReadLine());

                // Use the CurrencyConverter to perform currency conversion
                converter.ConvertCurrency(sourceCurrency, targetCurrency, amount);
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input format. Please enter a valid number.");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                Console.ResetColor();
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }

    public struct CurrencyConverter
    {
        private readonly Dictionary<string, Dictionary<string, decimal>> _exchangeRates;

        public CurrencyConverter(Dictionary<string, Dictionary<string, decimal>> exchangeRates)
        {
            _exchangeRates = exchangeRates ?? throw new ArgumentNullException(nameof(exchangeRates));
        }

        public void ConvertCurrency(string sourceCurrency, string targetCurrency, decimal amount)
        {
            if (!_exchangeRates.ContainsKey(sourceCurrency))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Invalid source currency '{sourceCurrency}'.");
                Console.ResetColor();
                return;
            }

            if (!_exchangeRates[sourceCurrency].ContainsKey(targetCurrency))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Invalid target currency '{targetCurrency}'.");
                Console.ResetColor();
                return;
            }

            decimal rate = _exchangeRates[sourceCurrency][targetCurrency];
            decimal convertedAmount = amount * rate;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Result: {amount} {sourceCurrency} is equivalent to {convertedAmount} {targetCurrency}.");
            Console.ResetColor();
        }
    }
}
