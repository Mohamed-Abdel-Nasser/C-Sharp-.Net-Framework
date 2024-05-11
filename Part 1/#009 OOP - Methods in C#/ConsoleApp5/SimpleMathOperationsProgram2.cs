namespace SimpleMathOperationsSystem2

{
    class SimpleMathOperationsProgram2
    {
        static void Main()
        {
            MathOperations math = new MathOperations();

            int result1 = math.Square(5);
            Console.WriteLine($"Square of 5 (int): {result1}");

            double result2 = math.Square(3.5);
            Console.WriteLine($"Square of 3.5 (double): {result2}");

            int sum1 = math.Add(10, 20);
            Console.WriteLine($"Sum of 10 and 20 (int): {sum1}");

            double sum2 = math.Add(3.5, 2.5);
            Console.WriteLine($"Sum of 3.5 and 2.5 (double): {sum2}");
        }
    }

    public class MathOperations
    {
        // Method to calculate the square of an integer
        public int Square(int num)
        {
            return num * num;
        }

        // Method to calculate the square of a double
        public double Square(double num)
        {
            return num * num;
        }

        // Method to calculate the sum of two integers
        public int Add(int a, int b)
        {
            return a + b;
        }

        // Method to calculate the sum of two doubles
        public double Add(double a, double b)
        {
            return a + b;
        }
    }
}
