namespace VehicleManagementSystem1
{
    internal class VehicleManagementProgram
    {
        static void Main(string[] args)
        {
            Vehicle vehicle1 = new Honda("Honda", "Civic", 2021);

            Honda car1 = new Honda("Honda", "Accord", 2021);
            Console.ReadKey();

        }
    }

    abstract class Vehicle
    {
        protected string Brand;
        protected string Model;
        protected int Year;

        public Vehicle(string brand, string model, int year)
        {
            Brand = brand;
            Model = model;
            Year = year;
        }
    }


    interface ILoader
    {
        void Load();
        void Unload();
    }
    interface IDrivable
    {
        void Move();
        void Stop();

    }
    class Honda : Vehicle, IDrivable
    {
        public Honda(string brand, string model, int year) : base(brand, model, year)
        {
        }
        public void Move()
        {
            Console.WriteLine("Moving");
        }
        public void Stop()
        {
            Console.WriteLine("Stopping");
        }
    }
    class Caterpillar : Vehicle, IDrivable, ILoader
    {
        public Caterpillar(string brand, string model, int year) : base(brand, model, year)
        {

        }

        public void Load()
        {
            Console.WriteLine("Loading");
        }

        public void Unload()
        {
            Console.WriteLine("Unloading");
        }

        public void Move()
        {
            Console.WriteLine("Moving");
        }

        public void Stop()
        {
            Console.WriteLine("Stopping");
        }


    }

}
