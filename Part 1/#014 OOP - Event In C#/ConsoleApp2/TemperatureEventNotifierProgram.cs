namespace TemperatureEventNotifierSystem
{
    class TemperatureEventNotifierProgram
    {
        static void Main(string[] args)
        {
            var temperatureSensor = new TemperatureSensor();

            // Subscribe to the TemperatureChanged event
            temperatureSensor.TemperatureChanged += DisplayTemperatureChange;

            // Simulate temperature changes
            temperatureSensor.SetTemperature(25); // Normal temperature
            temperatureSensor.SetTemperature(30); // Temperature increase
            temperatureSensor.SetTemperature(20); // Temperature decrease

            Console.ReadKey();
        }

        private static void DisplayTemperatureChange(object sender, TemperatureChangedEventArgs e)
        {
            string message;
            if (e.CurrentTemperature > e.OldTemperature)
                message = "Temperature increased";
            else if (e.CurrentTemperature < e.OldTemperature)
                message = "Temperature decreased";
            else
                message = "Temperature unchanged";

            Console.WriteLine($"{e.Location}: {e.CurrentTemperature}°C - {message}");
        }
    }

    public delegate void TemperatureChangedEventHandler(object sender, TemperatureChangedEventArgs e);

    public class TemperatureChangedEventArgs : EventArgs
    {
        public string Location { get; }
        public double CurrentTemperature { get; }
        public double OldTemperature { get; }

        public TemperatureChangedEventArgs(string location, double currentTemperature, double oldTemperature)
        {
            Location = location;
            CurrentTemperature = currentTemperature;
            OldTemperature = oldTemperature;
        }
    }
    public class TemperatureSensor
    {
        public event TemperatureChangedEventHandler TemperatureChanged;

        private string location;
        private double currentTemperature;

        public string Location => this.location;
        public double CurrentTemperature => this.currentTemperature;

        public TemperatureSensor()
        {
            location = "Living Room";
            currentTemperature = 25; // Initial temperature
        }

        public void SetTemperature(double newTemperature)
        {
            double oldTemperature = currentTemperature;
            currentTemperature = newTemperature;
            OnTemperatureChanged(oldTemperature);
        }

        protected virtual void OnTemperatureChanged(double oldTemperature)
        {
            TemperatureChanged?.Invoke(this, new TemperatureChangedEventArgs(location, currentTemperature, oldTemperature));
        }
    }
}
