using System;
using System.Collections.Generic;

namespace CountryManagementSystem
{
    class Program
    {
        static List<Country> countries = new List<Country>();

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("===== Country Management System ===== ");

            // Initial countries
            countries.Add(new Country { ISOCode = "EGY", Name = "Egypt" });
            countries.Add(new Country { ISOCode = "JOR", Name = "Jordan" });
            countries.Add(new Country { ISOCode = "IRQ", Name = "Iraq" });

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
                        AddCountry();
                        break;
                    case 2:
                        ViewCountries();
                        break;
                    case 3:
                        RemoveCountry();
                        break;
                    case 4:
                        ExitProgram();
                        break;
                    default:
                        DisplayErrorMessage("Invalid choice. Please enter a number between 1 and 4.");
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
            Console.WriteLine("\n=====================================");
            Console.WriteLine("           Main Menu");
            Console.WriteLine("=====================================");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("1. Add Country");
            Console.WriteLine("2. View Countries");
            Console.WriteLine("3. Remove Country");
            Console.WriteLine("4. Exit");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=====================================");
            Console.Write("Enter your choice: ");
            Console.ResetColor();
        }

        static void AddCountry()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n=====================================");
            Console.WriteLine("          Add New Country");
            Console.WriteLine("=====================================");

            Console.Write("Enter Country ISO Code: ");
            string isoCode = Console.ReadLine().ToUpper();

            if (countries.Exists(c => c.ISOCode == isoCode))
            {
                DisplayErrorMessage($"Country with ISO Code '{isoCode}' already exists.");
                return;
            }

            Console.Write("Enter Country Name: ");
            string name = Console.ReadLine();

            countries.Add(new Country { ISOCode = isoCode, Name = name });

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nCountry '{name}' ({isoCode}) added successfully.");
            Console.ResetColor();
        }

        static void ViewCountries()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n=====================================");
            Console.WriteLine("         List of Countries");
            Console.WriteLine("=====================================");

            if (countries.Count == 0)
            {
                DisplayErrorMessage("No countries found.");
                return;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (var country in countries)
            {
                Console.WriteLine(country.ToString());
            }
            Console.ResetColor();

            Console.WriteLine($"\nTotal Countries: {countries.Count}");
        }

        static void RemoveCountry()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n=====================================");
            Console.WriteLine("          Remove Country");
            Console.WriteLine("=====================================");

            Console.Write("Enter Country ISO Code to remove: ");
            string isoCode = Console.ReadLine().ToUpper();

            Country countryToRemove = countries.Find(c => c.ISOCode == isoCode);
            if (countryToRemove == null)
            {
                DisplayErrorMessage($"Country with ISO Code '{isoCode}' not found.");
                return;
            }

            countries.Remove(countryToRemove);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nCountry '{countryToRemove.Name}' ({isoCode}) removed successfully.");
            Console.ResetColor();
        }

        static void ExitProgram()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nExiting...");
            Console.ResetColor();
            Environment.Exit(0);
        }

        static void DisplayErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }

    class Country
    {
        public string ISOCode { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Name} ({ISOCode})";
        }
    }
}
