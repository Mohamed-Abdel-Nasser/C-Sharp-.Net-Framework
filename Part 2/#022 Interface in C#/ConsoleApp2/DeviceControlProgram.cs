namespace DeviceControlSystem
{
    internal class DeviceControlProgram
    {
        static void Main(string[] args)
        {
            // Create a Phone
            Phone myPhone = new Phone();
            Console.WriteLine("Phone Actions:");
            myPhone.PowerOn();
            myPhone.DisplayContent("Hello, world!");
            myPhone.PlayMedia("Music");
            myPhone.PowerOff();
            Console.WriteLine();

            // Create a TV
            TV myTV = new TV();
            Console.WriteLine("TV Actions:");
            myTV.PowerOn();
            myTV.DisplayContent("Welcome to the channel!");
            myTV.PlayMedia("Movie");
            myTV.PowerOff();
        }
    }

    // Interface for devices that can display content
    public interface IDisplayable
    {
        void DisplayContent(string content);
    }


    // Interface for devices that can play media
    public interface IMediaPlayer
    {
        void PlayMedia(string media);
    }


    // Interface for devices that can power on and off
    public interface IPowerable
    {
        void PowerOn();
        void PowerOff();
    }

    // Phone class implementing IPowerable, IDisplayable, and IMediaPlayer
    public class Phone : IPowerable, IDisplayable, IMediaPlayer
    {
        private bool isPoweredOn;

        public Phone()
        {
            isPoweredOn = false;
        }

        public void PowerOn()
        {
            isPoweredOn = true;
            Console.WriteLine("Phone is powered on.");
        }

        public void PowerOff()
        {
            isPoweredOn = false;
            Console.WriteLine("Phone is powered off.");
        }

        public void DisplayContent(string content)
        {
            if (isPoweredOn)
                Console.WriteLine($"Phone displays: {content}");
            else
                Console.WriteLine("Phone is not powered on.");
        }

        public void PlayMedia(string media)
        {
            if (isPoweredOn)
                Console.WriteLine($"Phone is playing: {media}");
            else
                Console.WriteLine("Phone is not powered on.");
        }
    }


    // TV class implementing IPowerable, IDisplayable, and IMediaPlayer
    public class TV : IPowerable, IDisplayable, IMediaPlayer
    {
        private bool isPoweredOn;

        public TV()
        {
            isPoweredOn = false;
        }

        public void PowerOn()
        {
            isPoweredOn = true;
            Console.WriteLine("TV is powered on.");
        }

        public void PowerOff()
        {
            isPoweredOn = false;
            Console.WriteLine("TV is powered off.");
        }

        public void DisplayContent(string content)
        {
            if (isPoweredOn)
                Console.WriteLine($"TV displays: {content}");
            else
                Console.WriteLine("TV is not powered on.");
        }

        public void PlayMedia(string media)
        {
            if (isPoweredOn)
                Console.WriteLine($"TV is playing: {media}");
            else
                Console.WriteLine("TV is not powered on.");
        }
    }
}
