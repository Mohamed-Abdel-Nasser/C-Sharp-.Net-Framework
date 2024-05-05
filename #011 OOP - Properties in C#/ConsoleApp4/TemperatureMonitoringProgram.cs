namespace TemperatureMonitoringSystem
{
    public class TemperatureMonitoringProgram
    {
        public static void Main()
        {
            try
            {
                TemperatureSensor sensor = new TemperatureSensor(25.5);
                Console.WriteLine($"Current Temperature: {sensor.Temperature}");

                // Increase temperature (valid)
                sensor.Temperature += 10.0;
                Console.WriteLine($"Updated Temperature: {sensor.Temperature}");

                // Attempt to set invalid temperature (below absolute zero)
                // sensor.Temperature = -300.0; // Throws an exception

                Console.WriteLine($"Is Critical Temperature: {sensor.IsCritical}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    public class TemperatureSensor
    {
        private double temperature;

        public double Temperature
        {
            get => temperature;
            set
            {
                if (value < -273.15)
                    throw new ArgumentOutOfRangeException("Temperature cannot be below absolute zero.");
                temperature = value;
            }
        }

        public bool IsCritical => Temperature > 100.0;

        public TemperatureSensor(double initialTemperature)
        {
            Temperature = initialTemperature;
        }
    }
}
