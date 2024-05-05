namespace CirclePropertiesCalculatorSystem
{
    class CirclePropertiesCalculatorProgramn
    {
        static void Main(string[] args)
        {
            // Create a circle object with radius 5
            Circle myCircle = new Circle(5);

            // Display circle properties
            Console.WriteLine("Circle Properties:");
            Console.WriteLine($"Radius: {myCircle.Radius}");
            Console.WriteLine($"Area: {myCircle.CalculateArea():F2}");
            Console.WriteLine($"Circumference: {myCircle.CalculateCircumference():F2}");

            // Demonstrate using the constant Pi
            Console.WriteLine($"PI constant value: {Circle.Pi}");

            // Modify the radius and recalculate properties
            myCircle.Radius = 7.5;
            Console.WriteLine("\nCircle Properties (after radius change):");
            Console.WriteLine($"Radius: {myCircle.Radius}");
            Console.WriteLine($"Area: {myCircle.CalculateArea():F2}");
            Console.WriteLine($"Circumference: {myCircle.CalculateCircumference():F2}");

            Console.ReadKey();
        }
    }

    public class Circle
    {
        public const double Pi = 3.14159;
        private double radius;
        public double Radius
        {
            get { return radius; }
            set { radius = value; }
        }
        public Circle(double radius)
        {

            this.radius = radius;
        }
        public double CalculateArea()
        {

            return Pi * radius * radius;
        }
        public double CalculateCircumference()
        {

            return 2 * Pi * radius;
        }

    }

}

