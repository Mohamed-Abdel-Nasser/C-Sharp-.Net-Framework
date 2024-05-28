namespace SmartHomeAutomationSystem
{
    internal class SmartHomeAutomationProgram
    {
        static void Main(string[] args)
        {
            // Create a Smart Light
            SmartLight mySmartLight = new SmartLight();
            Console.WriteLine("Smart Light Actions:");
            mySmartLight.PowerOn();
            mySmartLight.Connect("Home Network");
            mySmartLight.ConsumeEnergy();
            mySmartLight.Disconnect();
            mySmartLight.PowerOff();
            Console.WriteLine();

            // Create a Smart Speaker
            SmartSpeaker mySmartSpeaker = new SmartSpeaker();
            Console.WriteLine("Smart Speaker Actions:");
            mySmartSpeaker.PowerOn();
            mySmartSpeaker.Connect("Home Network");
            mySmartSpeaker.RemoteControl();
            mySmartSpeaker.ConsumeEnergy();
            mySmartSpeaker.Disconnect();
            mySmartSpeaker.PowerOff();
        }
    }


    // Interface for devices that can manage energy consumption
    public interface IEnergyConsumable
    {
        void ConsumeEnergy();
    }
    // Interface for devices that can connect to a network
    public interface IConnectable
    {
        void Connect(string networkName);
        void Disconnect();
    }

    public interface IPowerable
    {
        void PowerOn();
        void PowerOff();
    }
    public interface IRemoteControl
    {
        void RemoteControl();
    }


    // SmartLight class implementing IPowerable, IConnectable, and IEnergyConsumable
    public class SmartLight : IPowerable, IConnectable, IEnergyConsumable
    {
        private bool isPoweredOn;
        private bool isConnected;

        public SmartLight()
        {
            isPoweredOn = false;
            isConnected = false;
        }

        public void PowerOn()
        {
            isPoweredOn = true;
            Console.WriteLine("Smart Light is powered on.");
        }

        public void PowerOff()
        {
            isPoweredOn = false;
            Console.WriteLine("Smart Light is powered off.");
        }

        public void Connect(string networkName)
        {
            isConnected = true;
            Console.WriteLine($"Smart Light is connected to network: {networkName}");
        }

        public void Disconnect()
        {
            isConnected = false;
            Console.WriteLine("Smart Light is disconnected.");
        }

        public void ConsumeEnergy()
        {
            Console.WriteLine("Smart Light is consuming energy.");
        }
    }


    // SmartSpeaker class implementing IPowerable, IConnectable, IRemoteControl, and IEnergyConsumable
    public class SmartSpeaker : IPowerable, IConnectable, IRemoteControl, IEnergyConsumable
    {
        private bool isPoweredOn;
        private bool isConnected;

        public SmartSpeaker()
        {
            isPoweredOn = false;
            isConnected = false;
        }

        public void PowerOn()
        {
            isPoweredOn = true;
            Console.WriteLine("Smart Speaker is powered on.");
        }

        public void PowerOff()
        {
            isPoweredOn = false;
            Console.WriteLine("Smart Speaker is powered off.");
        }

        public void Connect(string networkName)
        {
            isConnected = true;
            Console.WriteLine($"Smart Speaker is connected to network: {networkName}");
        }

        public void Disconnect()
        {
            isConnected = false;
            Console.WriteLine("Smart Speaker is disconnected.");
        }

        public void RemoteControl()
        {
            Console.WriteLine("Smart Speaker can be controlled remotely.");
        }

        public void ConsumeEnergy()
        {
            Console.WriteLine("Smart Speaker is consuming energy.");
        }
    }

}
