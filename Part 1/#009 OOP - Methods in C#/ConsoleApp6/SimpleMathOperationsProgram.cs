namespace SimpleMathOperationsSystem
{
    class SimpleMathOperationsProgram
    {
        static void Main(string[] args)
        {
            int num1 = 10;
            int num2 = 5;

            // Perform mathematical operations using methods
            Console.WriteLine($"Addition: {MathOperations.Add(num1, num2)}");
            Console.WriteLine($"Subtraction: {MathOperations.Subtract(num1, num2)}");
            Console.WriteLine($"Multiplication: {MathOperations.Multiply(num1, num2)}");

            try
            {
                Console.WriteLine($"Division: {MathOperations.Divide(num1, num2)}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
    class MathOperations
    {
        // Method to perform addition
        public static int Add(int a, int b)
        {
            return a + b;
        }

        // Method to perform subtraction
        public static int Subtract(int a, int b)
        {
            return a - b;
        }

        // Method to perform multiplication
        public static int Multiply(int a, int b)
        {
            return a * b;
        }

        // Method to perform division
        public static double Divide(double a, double b)
        {
            if (b == 0)
                throw new ArgumentException("Division by zero is not allowed.");

            return a / b;
        }
    }

}

