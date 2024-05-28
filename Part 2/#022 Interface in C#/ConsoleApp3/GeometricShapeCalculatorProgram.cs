namespace GeometricShapeCalculatorSystem
{
    internal class GeometricShapeCalculatorProgram
    {
        static void Main(string[] args)
        {
            // Create a Rectangle
            Rectangle rectangle = new Rectangle(5.0, 3.0);
            double rectangleArea = rectangle.CalculateArea();
            double rectanglePerimeter = rectangle.CalculatePerimeter();

            Console.WriteLine("Rectangle:");
            Console.WriteLine($"Area: {rectangleArea}");
            Console.WriteLine($"Perimeter: {rectanglePerimeter}");
            Console.WriteLine();

            // Create a Circle
            Circle circle = new Circle(2.5);
            double circleArea = circle.CalculateArea();
            double circlePerimeter = circle.CalculatePerimeter();

            Console.WriteLine("Circle:");
            Console.WriteLine($"Area: {circleArea}");
            Console.WriteLine($"Perimeter: {circlePerimeter}");
            Console.ReadKey();
        }
    }


    // Concrete class representing a Rectangle
    public class Rectangle : IShape
    {
        public double Length { get; set; }
        public double Width { get; set; }

        public Rectangle(double length, double width)
        {
            Length = length;
            Width = width;
        }

        public double CalculateArea()
        {
            return Length * Width;
        }

        public double CalculatePerimeter()
        {
            return 2 * (Length + Width);
        }
    }


    public interface IShape
    {
        double CalculateArea();
        double CalculatePerimeter();
    }


    // Concrete class representing a Circle
    public class Circle : IShape
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }

        public double CalculatePerimeter()
        {
            return 2 * Math.PI * Radius;
        }
    }
}
