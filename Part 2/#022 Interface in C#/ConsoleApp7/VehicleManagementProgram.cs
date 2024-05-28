using System;
using System.Runtime.ConstrainedExecution;
namespace VehicleManagementSystem2
{
    class VehicleManagementProgram
    {
        static void Main(string[] args)
        {
            IVehicle car = new Car
            {
                Brand = "Toyota",
                Model = "Camry",
                Year = 2022
            };

            IVehicle motorcycle = new Motorcycle
            {
                Brand = "Honda",
                Model = "CBR600RR",
                Year = 2021
            };

            Console.WriteLine("Car Operations:");
            car.Start();
            car.Accelerate();
            car.Brake();

            Console.WriteLine();

            Console.WriteLine("Motorcycle Operations:");
            motorcycle.Start();
            motorcycle.Accelerate();
            motorcycle.Brake();

            Console.ReadKey();
        }
    }
    public interface IVehicle
    {
        string Brand { get; set; }
        string Model { get; set; }
        int Year { get; set; }

        void Start();
        void Accelerate();
        void Brake();
    }
    public class Motorcycle : IVehicle
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public void Start()
        {
            Console.WriteLine($"Starting {Brand} {Model}...");
        }

        public void Accelerate()
        {
            Console.WriteLine($"{Brand} {Model} is speeding up...");
        }

        public void Brake()
        {
            Console.WriteLine($"{Brand} {Model} is applying brakes...");
        }
    }
    public class Car : IVehicle
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public void Start()
        {
            Console.WriteLine($"Starting {Brand} {Model}...");
        }

        public void Accelerate()
        {
            Console.WriteLine($"{Brand} {Model} is accelerating...");
        }

        public void Brake()
        {
            Console.WriteLine($"{Brand} {Model} is braking...");
        }
    }

}

