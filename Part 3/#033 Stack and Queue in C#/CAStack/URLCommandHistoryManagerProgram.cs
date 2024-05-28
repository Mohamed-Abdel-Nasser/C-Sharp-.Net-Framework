using System;
using System.Collections.Generic;
namespace URLCommandHistoryManagerSystem
{
    class URLCommandHistoryManagerProgram
    {
        static Stack<Command> undo = new Stack<Command>();
        static Stack<Command> redo = new Stack<Command>();
        static bool isFirstEntry = true;

        static void Main(string[] args)
        {
            string line;

            while (true)
            {
                DisplayMenu();

                line = Console.ReadLine().ToLower();
                Console.Clear();

                switch (line)
                {
                    case "1":
                        Console.Write("Enter URL: ");
                        string url = Console.ReadLine().ToLower();
                        Navigate(url);
                        break;

                    case "2":
                        if (undo.Count > 0)
                        {
                            var item = undo.Pop();
                            redo.Push(item);
                            LogAction("Undo", item);
                        }
                        break;

                    case "3":
                        if (redo.Count > 0)
                        {
                            var item = redo.Pop();
                            undo.Push(item);
                            LogAction("Redo", item);
                        }
                        break;

                    case "4":
                        DisplayCommandHistory();
                        break;

                    case "5":
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }

                Print("Back", undo);
                Print("Forward", redo);
            }
        }

        static void DisplayMenu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("URL Command History Manager");
            Console.WriteLine("=====================================");
            Console.WriteLine("1.     Enter a URL to navigate");
            Console.WriteLine("2.    'back' to go back");
            Console.WriteLine("3.' → 'forward' to go forward");
            Console.WriteLine("4.    'history' to view command history");
            Console.WriteLine("5.    'exit' to quit");
            Console.WriteLine("=====================================");
            Console.ResetColor();
            Console.Write("Enter your choice Number: ");
        }

        static void Print(string name, Stack<Command> commands)
        {
            Console.WriteLine($"{name} history:");
            Console.BackgroundColor = name.ToLower() == "back" ? ConsoleColor.DarkGreen : ConsoleColor.DarkBlue;
            foreach (var u in commands)
            {
                Console.WriteLine($"\t{u}");
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ResetColor();
        }

        static void DisplayCommandHistory()
        {
            Console.Clear();
            Console.WriteLine("Command History:");
            foreach (var command in CommandLog.Log)
            {
                switch (command.Action)
                {
                    case "Navigate":
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case "Undo":
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case "Redo":
                        Console.ForegroundColor = ConsoleColor.Blue;
                        break;
                }
                Console.WriteLine($"{command.Timestamp}: {command.Action} - {command.Url}");
                Console.ResetColor();
            }
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
            Console.Clear();
        }

        static void LogAction(string action, Command command)
        {
            CommandLog.Log.Add(new CommandLogEntry
            {
                Action = action,
                Url = command.Url,
                Timestamp = DateTime.Now
            });
        }

        static void Navigate(string url)
        {
            var command = new Command(url);
            undo.Push(command);
            LogAction("Navigate", command);
            isFirstEntry = false;
        }
    }

    class Command
    {
        private readonly DateTime _createdAt;
        public readonly string Url;

        public Command(string url)
        {
            _createdAt = DateTime.Now;
            Url = url;
        }

        public override string ToString()
        {
            return $"[{_createdAt:yyyy-MM-dd hh:mm}] {Url}";
        }
    }

    class CommandLogEntry
    {
        public string Action { get; set; }
        public string Url { get; set; }
        public DateTime Timestamp { get; set; }
    }

    static class CommandLog
    {
        public static List<CommandLogEntry> Log { get; } = new List<CommandLogEntry>();
    }
}
