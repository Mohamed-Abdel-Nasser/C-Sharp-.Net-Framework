using System;
using System.Threading.Tasks;

namespace CompanySoftwareUpdater
{
    internal class CompanySoftwareUpdaterProgram
    {
        static async Task Main(string[] args)
        {
            // Simulating scheduled software updates for a company's internal system
            var updates = new Update[]
            {
                new Update(1, "Security patch"),
                new Update(2, "User interface enhancements"),
                new Update(3, "Bug fixes"),
                new Update(4, "Performance improvements"),
            };

            // Schedule updates for specific times
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Scheduling updates...");
            await Task.Delay(1000); // Simulate scheduling delay
            Console.WriteLine("Updates scheduled successfully.");
            Console.ResetColor();

            Console.WriteLine("========================================\n");

            // Download and install updates
            await UpdateProcessor.DownloadAndInstallAsync(updates);
        }
    }

    [Serializable]
    class Update
    {
        public int Number { get; }
        public string Title { get; }

        public Update(int number, string title)
        {
            Number = number;
            Title = title;
        }

        public override string ToString()
        {
            return $"Update {Number}: {Title}";
        }
    }

    class UpdateProcessor
    {
        public static async Task DownloadAndInstallAsync(Update[] updates)
        {
            foreach (var update in updates)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Downloading {update}...");
                await Task.Delay(750); // Simulate asynchronous delay

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Installing {update}...");
                await Task.Delay(750); // Simulate asynchronous delay

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"{update.Title} has been downloaded and installed successfully.");
                Console.WriteLine("------------------------------------------------------------------\n");
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("==============================================================");
            Console.WriteLine("All updates have been successfully downloaded and installed.");
            Console.WriteLine("==============================================================");
            Console.ResetColor();
        }

        [Obsolete("This method is deprecated. Use DownloadAndInstallAsync for a more efficient process.")]
        public static void Download(Update[] updates)
        {
            foreach (var update in updates)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Downloading {update}");
                System.Threading.Thread.Sleep(750); // Simulate delay
                Console.WriteLine("========================================");
                Console.ResetColor();
            }
        }

        [Obsolete("This method is deprecated. Use DownloadAndInstallAsync for a more efficient process.")]
        public static void Install(Update[] updates)
        {
            foreach (var update in updates)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Installing {update}");
                System.Threading.Thread.Sleep(750); // Simulate delay
                Console.WriteLine("========================================");
                Console.ResetColor();
            }
        }
    }
}
