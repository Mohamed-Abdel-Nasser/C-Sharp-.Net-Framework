namespace EngineTechAnalyzerSystem
{
    class EngineTechAnalyzer
    {
        static void Main()
        {
            Engine v6Engine = new Engine("V6");
            Car car1 = new Car("Toyota", "Camry", v6Engine);
            Console.WriteLine(car1);

            Engine v8Engine = new Engine("V8");
            Car car2 = new Car("Ford", "Mustang", v8Engine);
            Console.WriteLine(car2);
        }
    }
    public class Engine
    {
        public string Type { get; }

        public Engine(string type)
        {
            Type = type;
        }
    }
    public class Car
    {
        public string Make { get; }
        public string Model { get; }
        public Engine Engine { get; }

        public Car(string make, string model, Engine engine)
        {
            Make = make;
            Model = model;
            Engine = engine;
        }

        public override string ToString()
        {
            return $"Car: {Make} {Model}, Engine Type: {Engine.Type}";
        }
    }



}
