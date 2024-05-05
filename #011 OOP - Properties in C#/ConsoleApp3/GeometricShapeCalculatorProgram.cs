namespace GeometricShapeCalculatorSystem
{
    public class GeometricShapeCalculatorProgram
    {
        public static void Main()
        {
            try
            {
                Circle circle = new Circle(5);
                Console.WriteLine($"Circle with radius {circle.Radius} has area: {circle.Area:F2}");

                // Uncomment the line below to see how validation works:
                // Circle invalidCircle = new Circle(-2); // Throws an exception due to negative radius
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Console.ReadKey();
        }
    }
    public class Circle
    {
        private double radius;

        public double Radius
        {
            get => radius;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Radius must be positive.");
                radius = value;
            }
        }

        public double Area => Math.PI * Radius * Radius;

        public Circle(double radius)
        {
            Radius = radius;
        }
    }

}


