using System;
using System.Collections.Generic;
using System.Diagnostics;
namespace LibraryManagementSystem
{
    class LibraryManagementProgram
    {
        // A nested dictionary to store library books information
        static Dictionary<string, Dictionary<string, object>> libraryDb = new Dictionary<string, Dictionary<string, object>>()
    {
        { "978-0132350884", new Dictionary<string, object> { { "title", "Clean Code" }, { "author", "Robert C. Martin" }, { "copies", 5 } } },
        { "978-0201485677", new Dictionary<string, object> { { "title", "Refactoring" }, { "author", "Martin Fowler" }, { "copies", 3 } } },
        { "978-0131103627", new Dictionary<string, object> { { "title", "The C Programming Language" }, { "author", "Brian W. Kernighan, Dennis M. Ritchie" }, { "copies", 2 } } }
    };

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("=================================");
                Console.WriteLine("       Library Management        ");
                Console.WriteLine("=================================");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("1. Access Book");
                Console.WriteLine("2. Change Number of Copies");
                Console.WriteLine("3. Add Book");
                Console.WriteLine("4. Remove Book");
                Console.WriteLine("5. View Book Titles");
                Console.WriteLine("6. Print All Books");
                Console.WriteLine("7. Copy Library Database");
                Console.WriteLine("8. Dictionary Methods Example");
                Console.WriteLine("9. Exit");
                Console.WriteLine("=================================");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("Enter your choice: ");
                Console.ResetColor();

                string choice = Console.ReadLine().Trim(); // Trim to remove any extra whitespace

                int numericChoice;
                if (int.TryParse(choice, out numericChoice))
                {
                    switch (numericChoice)
                    {
                        case 1:
                            AccessBook();
                            break;
                        case 2:
                            ChangeCopies();
                            break;
                        case 3:
                            AddBook();
                            break;
                        case 4:
                            RemoveBook();
                            break;
                        case 5:
                            ViewBookTitles();
                            break;
                        case 6:
                            PrintAllBooks();
                            break;
                        case 7:
                            CopyLibraryDb();
                            break;
                        case 8:
                            DictionaryMethodsExample();
                            break;
                        case 9:
                            return;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid choice, please try again.");
                            Console.ResetColor();
                            break;
                    }
                }
                else
                {
                    switch (choice.ToLower())
                    {
                        case "1":
                        case "access book":
                            AccessBook();
                            break;
                        case "2":
                        case "change number of copies":
                            ChangeCopies();
                            break;
                        case "3":
                        case "add book":
                            AddBook();
                            break;
                        case "4":
                        case "remove book":
                            RemoveBook();
                            break;
                        case "5":
                        case "view book titles":
                            ViewBookTitles();
                            break;
                        case "6":
                        case "print all books":
                            PrintAllBooks();
                            break;
                        case "7":
                        case "copy library database":
                            CopyLibraryDb();
                            break;
                        case "8":
                        case "dictionary methods example":
                            DictionaryMethodsExample();
                            break;
                        case "9":
                        case "exit":
                            return;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid choice, please try again.");
                            Console.ResetColor();
                            break;
                    }
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nPress any key to continue...");
                Console.ResetColor();
                Console.ReadKey();
            }
        }

        static void AccessBook()
        {
            Console.Write("Enter ISBN: ");
            string isbn = Console.ReadLine();
            if (libraryDb.TryGetValue(isbn, out Dictionary<string, object> book))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{"ISBN:",-15}{isbn}");
                Console.WriteLine($"{"Title:",-15}{book["title"]}");
                Console.WriteLine($"{"Author:",-15}{book["author"]}");
                Console.WriteLine($"{"Copies:",-15}{book["copies"]}");
                Console.WriteLine($"Book '{book["title"]}' selected.");
                Console.ResetColor();

                // Open a new window with the name of the option chosen
                OpenNewWindow("Access Book");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Book not found");
                Console.ResetColor();
            }
        }

        static void ChangeCopies()
        {
            Console.Write("Enter ISBN: ");
            string isbn = Console.ReadLine();
            Console.Write("Enter new number of copies: ");
            if (int.TryParse(Console.ReadLine(), out int newCopies))
            {
                if (libraryDb.ContainsKey(isbn))
                {
                    libraryDb[isbn]["copies"] = newCopies;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Number of copies updated successfully.");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Book not found");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid number of copies");
            }
            Console.ResetColor();
        }

        static void AddBook()
        {
            Console.Write("Enter ISBN: ");
            string isbn = Console.ReadLine();
            Console.Write("Enter book title: ");
            string title = Console.ReadLine();
            Console.Write("Enter author: ");
            string author = Console.ReadLine();
            Console.Write("Enter number of copies: ");
            if (int.TryParse(Console.ReadLine(), out int copies))
            {
                libraryDb[isbn] = new Dictionary<string, object> { { "title", title }, { "author", author }, { "copies", copies } };
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Book added successfully.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid number of copies");
            }
            Console.ResetColor();
        }

        static void RemoveBook()
        {
            Console.Write("Enter ISBN: ");
            string isbn = Console.ReadLine();
            if (libraryDb.Remove(isbn))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Book removed");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Book not found");
            }
            Console.ResetColor();
        }

        static void ViewBookTitles()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nBook Titles:");
            Console.WriteLine("=================================");
            foreach (var book in libraryDb)
            {
                Console.WriteLine($"{book.Key}: {book.Value["title"]}");
            }
            Console.WriteLine("=================================");
            Console.ResetColor();
        }

        static void PrintAllBooks()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nAll Books:");
            Console.WriteLine("=================================");
            foreach (var book in libraryDb)
            {
                Console.WriteLine($"ISBN: {book.Key}");
                Console.WriteLine($"  Title: {book.Value["title"]}");
                Console.WriteLine($"  Author: {book.Value["author"]}");
                Console.WriteLine($"  Copies: {book.Value["copies"]}");
                Console.WriteLine("---------------------------------");
            }
            Console.WriteLine("=================================");
            Console.ResetColor();
        }

        static void CopyLibraryDb()
        {
            var newDb = new Dictionary<string, Dictionary<string, object>>(libraryDb);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nCopied DB:");
            Console.WriteLine("=================================");
            foreach (var book in newDb)
            {
                Console.WriteLine($"ISBN: {book.Key}");
                Console.WriteLine($"  Title: {book.Value["title"]}");
                Console.WriteLine($"  Author: {book.Value["author"]}");
                Console.WriteLine($"  Copies: {book.Value["copies"]}");
                Console.WriteLine("---------------------------------");
            }
            Console.WriteLine("=================================");
            Console.ResetColor();
        }

        static void DictionaryMethodsExample()
        {
            var keys = libraryDb.Keys;
            var values = libraryDb.Values;
            var items = libraryDb;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nKeys:");
            Console.WriteLine("=================================");
            foreach (var key in keys)
            {
                Console.WriteLine(key);
            }

            Console.WriteLine("\nValues:");
            Console.WriteLine("=================================");
            foreach (var value in values)
            {
                foreach (var info in value)
                {
                    Console.WriteLine($"  {info.Key}: {info.Value}");
                }
            }

            Console.WriteLine("\nItems:");
            Console.WriteLine("=================================");
            foreach (var item in items)
            {
                Console.WriteLine($"ISBN: {item.Key}");
                foreach (var info in item.Value)
                {
                    Console.WriteLine($"  {info.Key}: {info.Value}");
                }
            }
            Console.WriteLine("=================================");
            Console.ResetColor();
        }

        // Method to open a new window with the specified name
        static void OpenNewWindow(string windowName)
        {
            try
            {
                // Use Process.Start to open a new process (window) with the specified name
                Process.Start(windowName);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error opening {windowName}: {ex.Message}");
            }
        }
    }

}
