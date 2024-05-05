namespace RectangleGeometrySystem
{
    public delegate void RectangleOperationDelegate(decimal width, decimal height);
    internal class RectangleGeometryProgram
    {
        static void Main(string[] args)
        {

            var helper = new RectangleHelper();
            RectangleOperationDelegate rect;
            rect = helper.CalculateArea;
            rect += helper.CalculatePerimeter;
            rect(10, 10);
            Console.ReadKey();

        }
    }
    public class RectangleHelper
    {
        public void CalculateArea(decimal width, decimal height)
        {
            if (width <= 0 || height <= 0)
            {
                Console.WriteLine("Invalid dimensions. Width and height must be positive numbers.");
                return;
            }

            var result = width * height;
            Console.WriteLine($"Area is : {width} X {height} = {result}");
        }
        public void CalculatePerimeter(decimal width, decimal height)
        {
            if (width <= 0 || height <= 0)
            {
                Console.WriteLine("Invalid dimensions. Width and height must be positive numbers.");
                return;
            }

            var result = 2 * (width + height);
            Console.WriteLine($"Perimeter is: 2 X ({width} + {height}) = {result}");
        }
    }
}
