using System;
using System.Collections.Generic;

namespace FinTechPortfolioManagement
{
    class Program
    {
        static Dictionary<string, Portfolio> portfolios = new Dictionary<string, Portfolio>();

        static void Main(string[] args)
        {
            Console.Title = "FinTech Investment Portfolio Management System";
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("===== FinTech Investment Portfolio Management System =====");

            while (true)
            {
                DisplayMainMenu();

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    DisplayErrorMessage("Invalid input. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        CreatePortfolio();
                        break;
                    case 2:
                        ViewPortfolios();
                        break;
                    case 3:
                        BuyStock();
                        break;
                    case 4:
                        SellStock();
                        break;
                    case 5:
                        ViewPortfolioPerformance();
                        break;
                    case 6:
                        AddInvestmentAttribute();
                        break;
                    case 7:
                        RemoveInvestmentAttribute();
                        break;
                    case 8:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nExiting...");
                        Console.ResetColor();
                        Environment.Exit(0);
                        break;
                    default:
                        DisplayErrorMessage("Invalid choice. Please enter a number between 1 and 8.");
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        static void DisplayMainMenu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n → Main Menu");
            Console.WriteLine("============================");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("1. Create Portfolio");
            Console.WriteLine("2. View Portfolios");
            Console.WriteLine("3. Buy Stock");
            Console.WriteLine("4. Sell Stock");
            Console.WriteLine("5. View Portfolio Performance");
            Console.WriteLine("6. Add Investment Attribute");
            Console.WriteLine("7. Remove Investment Attribute");
            Console.WriteLine("8. Exit");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("============================");
            Console.Write("Enter your choice: ");
            Console.ResetColor();
        }

        static void CreatePortfolio()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n=====================================================");
            Console.WriteLine("               Create New Portfolio");
            Console.WriteLine("=====================================================");

            Console.Write("Enter Portfolio Name: ");
            string portfolioName = Console.ReadLine().Trim();

            if (portfolios.ContainsKey(portfolioName))
            {
                DisplayErrorMessage($"Portfolio '{portfolioName}' already exists.");
                return;
            }

            portfolios.Add(portfolioName, new Portfolio { PortfolioName = portfolioName });

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nPortfolio '{portfolioName}' created successfully.");
            Console.ResetColor();
        }

        static void ViewPortfolios()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n=====================================================");
            Console.WriteLine("                  List of Portfolios");
            Console.WriteLine("=====================================================");

            if (portfolios.Count == 0)
            {
                DisplayErrorMessage("No portfolios found.");
                return;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (var portfolio in portfolios.Values)
            {
                Console.WriteLine($"Portfolio Name: {portfolio.PortfolioName}");
                Console.WriteLine("Investments:");
                foreach (var investment in portfolio.Investments)
                {
                    Console.WriteLine($"- {investment}");
                }
                Console.WriteLine();
            }
            Console.ResetColor();

            Console.WriteLine($"\nTotal Portfolios: {portfolios.Count}");
        }

        static void BuyStock()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n=====================================================");
            Console.WriteLine("                    Buy Stock");
            Console.WriteLine("=====================================================");

            Console.Write("Enter Portfolio Name: ");
            string portfolioName = Console.ReadLine().Trim();

            if (!portfolios.ContainsKey(portfolioName))
            {
                DisplayErrorMessage($"Portfolio '{portfolioName}' not found.");
                return;
            }

            Console.Write("Enter Stock Symbol: ");
            string stockSymbol = Console.ReadLine().Trim().ToUpper();

            Console.Write("Enter Number of Shares to Buy: ");
            if (!int.TryParse(Console.ReadLine(), out int shares) || shares <= 0)
            {
                DisplayErrorMessage("Invalid input for number of shares. Please enter a valid positive integer.");
                return;
            }

            decimal pricePerShare;
            do
            {
                Console.Write("Enter Price per Share: ");
            } while (!decimal.TryParse(Console.ReadLine(), out pricePerShare) || pricePerShare <= 0);

            portfolios[portfolioName].Investments.Add(new Investment
            {
                StockSymbol = stockSymbol,
                Shares = shares,
                PricePerShare = pricePerShare,
                PurchaseDate = DateTime.Today, // Default purchase date
                Sector = "Technology", // Default sector
                RiskLevel = "Medium" // Default risk level
            });

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nStock '{stockSymbol}' purchased successfully for Portfolio '{portfolioName}'.");
            Console.ResetColor();
        }

        static void SellStock()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n=====================================================");
            Console.WriteLine("                    Sell Stock");
            Console.WriteLine("=====================================================");

            Console.Write("Enter Portfolio Name: ");
            string portfolioName = Console.ReadLine().Trim();

            if (!portfolios.ContainsKey(portfolioName))
            {
                DisplayErrorMessage($"Portfolio '{portfolioName}' not found.");
                return;
            }

            Console.Write("Enter Stock Symbol to Sell: ");
            string stockSymbol = Console.ReadLine().Trim().ToUpper();

            var portfolio = portfolios[portfolioName];
            var investmentToRemove = portfolio.Investments.Find(i => i.StockSymbol == stockSymbol);

            if (investmentToRemove == null)
            {
                DisplayErrorMessage($"Stock '{stockSymbol}' not found in Portfolio '{portfolioName}'.");
                return;
            }

            portfolio.Investments.Remove(investmentToRemove);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nStock '{stockSymbol}' sold successfully from Portfolio '{portfolioName}'.");
            Console.ResetColor();
        }

        static void ViewPortfolioPerformance()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n=====================================================");
            Console.WriteLine("           Portfolio Performance");
            Console.WriteLine("=====================================================");

            if (portfolios.Count == 0)
            {
                DisplayErrorMessage("No portfolios found.");
                return;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (var portfolio in portfolios.Values)
            {
                Console.WriteLine($"Portfolio Name: {portfolio.PortfolioName}");
                Console.WriteLine("Investments:");

                if (portfolio.Investments.Count == 0)
                {
                    Console.WriteLine("- No investments.");
                }
                else
                {
                    foreach (var investment in portfolio.Investments)
                    {
                        Console.WriteLine($"- {investment}");
                    }
                }

                Console.WriteLine();
            }
            Console.ResetColor();
        }

        static void AddInvestmentAttribute()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n=====================================================");
            Console.WriteLine("            Add Investment Attribute");
            Console.WriteLine("=====================================================");

            Console.Write("Enter Portfolio Name: ");
            string portfolioName = Console.ReadLine().Trim();

            if (!portfolios.ContainsKey(portfolioName))
            {
                DisplayErrorMessage($"Portfolio '{portfolioName}' not found.");
                return;
            }

            Console.Write("Enter Stock Symbol: ");
            string stockSymbol = Console.ReadLine().Trim().ToUpper();

            var portfolio = portfolios[portfolioName];
            var investmentToUpdate = portfolio.Investments.Find(i => i.StockSymbol == stockSymbol);

            if (investmentToUpdate == null)
            {
                DisplayErrorMessage($"Stock '{stockSymbol}' not found in Portfolio '{portfolioName}'.");
                return;
            }

            Console.WriteLine("Select Attribute to Add:");
            Console.WriteLine("1. Purchase Date");
            Console.WriteLine("2. Sector");
            Console.WriteLine("3. Risk Level");
            Console.Write("Enter your choice: ");

            if (!int.TryParse(Console.ReadLine(), out int attributeChoice))
            {
                DisplayErrorMessage("Invalid input. Please enter a number.");
                return;
            }

            switch (attributeChoice)
            {
                case 1:
                    Console.Write("Enter Purchase Date (YYYY-MM-DD): ");
                    if (!DateTime.TryParse(Console.ReadLine(), out DateTime purchaseDate))
                    {
                        DisplayErrorMessage("Invalid date format. Please enter a valid date (YYYY-MM-DD).");
                        return;
                    }
                    investmentToUpdate.PurchaseDate = purchaseDate;
                    break;
                case 2:
                    Console.Write("Enter Sector: ");
                    string sector = Console.ReadLine().Trim();
                    investmentToUpdate.Sector = sector;
                    break;
                case 3:
                    Console.Write("Enter Risk Level (Low, Medium, High): ");
                    string riskLevel = Console.ReadLine().Trim();
                    investmentToUpdate.RiskLevel = riskLevel;
                    break;
                default:
                    DisplayErrorMessage("Invalid choice. Please enter a number between 1 and 3.");
                    break;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nAttribute added successfully to Stock '{stockSymbol}' in Portfolio '{portfolioName}'.");
            Console.ResetColor();
        }

        static void RemoveInvestmentAttribute()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n=====================================================");
            Console.WriteLine("         Remove Investment Attribute");
            Console.WriteLine("=====================================================");

            Console.Write("Enter Portfolio Name: ");
            string portfolioName = Console.ReadLine().Trim();

            if (!portfolios.ContainsKey(portfolioName))
            {
                DisplayErrorMessage($"Portfolio '{portfolioName}' not found.");
                return;
            }

            Console.Write("Enter StockSymbol: ");
            string stockSymbol = Console.ReadLine().Trim().ToUpper();

            var portfolio = portfolios[portfolioName];
            var investmentToUpdate = portfolio.Investments.Find(i => i.StockSymbol == stockSymbol);

            if (investmentToUpdate == null)
            {
                DisplayErrorMessage($"Stock '{stockSymbol}' not found in Portfolio '{portfolioName}'.");
                return;
            }

            Console.WriteLine("Select Attribute to Remove:");
            Console.WriteLine("1. Purchase Date");
            Console.WriteLine("2. Sector");
            Console.WriteLine("3. Risk Level");
            Console.Write("Enter your choice: ");

            if (!int.TryParse(Console.ReadLine(), out int attributeChoice))
            {
                DisplayErrorMessage("Invalid input. Please enter a number.");
                return;
            }

            switch (attributeChoice)
            {
                case 1:
                    investmentToUpdate.PurchaseDate = default; // Reset to default value
                    break;
                case 2:
                    investmentToUpdate.Sector = ""; // Reset to default value
                    break;
                case 3:
                    investmentToUpdate.RiskLevel = ""; // Reset to default value
                    break;
                default:
                    DisplayErrorMessage("Invalid choice. Please enter a number between 1 and 3.");
                    break;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nAttribute removed successfully from Stock '{stockSymbol}' in Portfolio '{portfolioName}'.");
            Console.ResetColor();
        }

        static void DisplayErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }

    class Portfolio
    {
        public string PortfolioName { get; set; }
        public List<Investment> Investments { get; set; } = new List<Investment>();
    }

    class Investment
    {
        public string StockSymbol { get; set; }
        public int Shares { get; set; }
        public decimal PricePerShare { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string Sector { get; set; }
        public string RiskLevel { get; set; }

        public override string ToString()
        {
            return $"{Shares} shares of {StockSymbol} ({Sector}, {RiskLevel}) - Purchased on {PurchaseDate.ToShortDateString()}";
        }
    }
}

