using System;
namespace ConfigurationManagerSystem
{
    class ConfigurationManagerProgram
    {
        static void Main()
        {
            ConfigurationManager configManager = new ConfigurationManager();

            // Retrieve and use network settings
            ConfigurationManager.NetworkSettings networkSettings = configManager.GetNetworkSettings();
            Console.WriteLine($"IP Address: {networkSettings.IPAddress}, Port: {networkSettings.Port}");

            // Retrieve and use database settings
            ConfigurationManager.DatabaseSettings dbSettings = configManager.GetDatabaseSettings();
            Console.WriteLine($"Connection String: {dbSettings.ConnectionString}, Logging Enabled: {dbSettings.IsLoggingEnabled}");
            Console.ReadKey();
        }
    }
    public class ConfigurationManager
    {
        // Nested class for network settings
        public class NetworkSettings
        {
            public string IPAddress { get; set; }
            public int Port { get; set; }
        }

        // Nested class for database settings
        public class DatabaseSettings
        {
            public string ConnectionString { get; set; }
            public bool IsLoggingEnabled { get; set; }
        }

        // Method to retrieve network settings
        public NetworkSettings GetNetworkSettings()
        {
            return new NetworkSettings
            {
                IPAddress = "192.168.1.100",
                Port = 8080
            };
        }

        // Method to retrieve database settings
        public DatabaseSettings GetDatabaseSettings()
        {
            return new DatabaseSettings
            {
                ConnectionString = "Server=myServerAddress;Database=myDataBase;User=myUsername;Password=myPassword;",
                IsLoggingEnabled = true
            };
        }
    }


}
