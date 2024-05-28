using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PlayersSkillAttributeAnalyzer
{
    class PlayersSkillAttributeAnalyzerProgram
    {
        static List<Player> players = new List<Player>(); // Define players list at class level

        static void Main(string[] args)
        {
            // Example players (can be inputted by the user later)
            players.Add(new Player
            {
                Name = "Lionel Messi",
                BallControl = 9,
                Dribbling = 18,
                Passing = 4,
                Speed = 85,
                Power = 990
            });

            players.Add(new Player
            {
                Name = "Christiano Ronaldo",
                BallControl = 9,
                Dribbling = 21,
                Passing = 4,
                Speed = 110,
                Power = 980
            });

            players.Add(new Player
            {
                Name = "Naymar Jr",
                BallControl = 11,
                Dribbling = 16,
                Passing = 4,
                Speed = 85,
                Power = 1000
            });

            DisplayMenu();
        }

        static void DisplayMenu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Players Skill Attribute Analyzer");
                Console.WriteLine("=============================================");
                Console.WriteLine("1. Display Current Players Information");
                Console.WriteLine("2. Add New Players");
                Console.WriteLine("3. Edit Player Settings");
                Console.WriteLine("4. Exit");
                Console.WriteLine("=============================================");

                Console.Write("Select an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        DisplayPlayers();
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.Clear();
                        AddNewPlayer();
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.Clear();
                        EditPlayerSettings();
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        break;
                    case "4":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        [Obsolete("Use DisplayPlayersV2 instead")]
        static void DisplayPlayers()
        {
            Console.WriteLine("Current Players Information:");
            foreach (var player in players)
            {
                Console.WriteLine($"{player.Name}:");
                Console.WriteLine($"- Ball Control: {player.BallControl}");
                Console.WriteLine($"- Dribbling: {player.Dribbling}");
                Console.WriteLine($"- Passing: {player.Passing}");
                Console.WriteLine($"- Speed: {player.Speed}");
                Console.WriteLine($"- Power: {player.Power}");
                Console.WriteLine();
            }
        }
        static void DisplayPlayersV2()
        {
            Console.WriteLine("Current Players Information:");
            foreach (var player in players)
            {
                Console.WriteLine($"{player.Name}:");
                Console.WriteLine($"- Ball Control: {player.BallControl}");
                Console.WriteLine($"- Dribbling: {player.Dribbling}");
                Console.WriteLine($"- Passing: {player.Passing}");
                Console.WriteLine($"- Speed: {player.Speed}");
                Console.WriteLine($"- Power: {player.Power}");
                Console.WriteLine();
            }
        }

        static void AddNewPlayer()
        {
            Console.WriteLine("Enter the new player details:");

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Ball Control (1-10): ");
            int ballControl = int.Parse(Console.ReadLine());

            Console.Write("Dribbling (1-20): ");
            int dribbling = int.Parse(Console.ReadLine());

            Console.Write("Passing (1-4): ");
            int passing = int.Parse(Console.ReadLine());

            Console.Write("Speed (1-100): ");
            int speed = int.Parse(Console.ReadLine());

            Console.Write("Power (1-1000): ");
            int power = int.Parse(Console.ReadLine());

            players.Add(new Player
            {
                Name = name,
                BallControl = ballControl,
                Dribbling = dribbling,
                Passing = passing,
                Speed = speed,
                Power = power
            });

            Console.WriteLine("Player added successfully!");
        }

        [Obsolete("Use EditPlayerSettingsV2 instead")]
        static void EditPlayerSettings()
        {
            Console.WriteLine("Select a player to edit:");

            for (int i = 0; i < players.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {players[i].Name}");
            }

            Console.Write("Enter player number: ");
            int playerIndex = int.Parse(Console.ReadLine()) - 1;

            if (playerIndex >= 0 && playerIndex < players.Count)
            {
                var player = players[playerIndex];

                Console.WriteLine($"Editing player: {player.Name}");
                Console.WriteLine("Enter new settings:");

                Console.Write("Ball Control (1-10): ");
                player.BallControl = int.Parse(Console.ReadLine());

                Console.Write("Dribbling (1-20): ");
                player.Dribbling = int.Parse(Console.ReadLine());

                Console.Write("Passing (1-4): ");
                player.Passing = int.Parse(Console.ReadLine());

                Console.Write("Speed (1-100): ");
                player.Speed = int.Parse(Console.ReadLine());

                Console.Write("Power (1-1000): ");
                player.Power = int.Parse(Console.ReadLine());

                Console.WriteLine("Player settings updated successfully!");
            }
            else
            {
                Console.WriteLine("Invalid player number.");
            }
        }

        static void EditPlayerSettingsV2()
        {
            Console.WriteLine("Select a player to edit:");

            for (int i = 0; i < players.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {players[i].Name}");
            }

            Console.Write("Enter player number: ");
            int playerIndex = int.Parse(Console.ReadLine()) - 1;

            if (playerIndex >= 0 && playerIndex < players.Count)
            {
                var player = players[playerIndex];

                Console.WriteLine($"Editing player: {player.Name}");
                Console.WriteLine("Enter new settings:");

                Console.Write("Ball Control (1-10): ");
                player.BallControl = int.Parse(Console.ReadLine());

                Console.Write("Dribbling (1-20): ");
                player.Dribbling = int.Parse(Console.ReadLine());

                Console.Write("Passing (1-4): ");
                player.Passing = int.Parse(Console.ReadLine());

                Console.Write("Speed (1-100): ");
                player.Speed = int.Parse(Console.ReadLine());

                Console.Write("Power (1-1000): ");
                player.Power = int.Parse(Console.ReadLine());

                Console.WriteLine("Player settings updated successfully!");
            }
            else
            {
                Console.WriteLine("Invalid player number.");
            }
        }
    }

    public class SkillAttribute : Attribute
    {
        public string Name { get; private set; }
        public int Minimum { get; private set; }
        public int Maximum { get; private set; }

        public SkillAttribute(string name, int minimum, int maximum)
        {
            Name = name;
            Minimum = minimum;
            Maximum = maximum;
        }

        public bool IsValid(int value)
        {
            return value >= Minimum && value <= Maximum;
        }
    }

    public class Player
    {
        public string Name { get; set; }

        [Skill(nameof(BallControl), 1, 10)]
        public int BallControl { get; set; }

        [Skill(nameof(Dribbling), 1, 20)]
        public int Dribbling { get; set; }

        [Skill(nameof(Power), 1, 1000)]
        public int Power { get; set; }

        [Skill(nameof(Speed), 1, 100)]
        public int Speed { get; set; }

        [Skill(nameof(Passing), 1, 4)]
        public int Passing { get; set; }
    }
}
