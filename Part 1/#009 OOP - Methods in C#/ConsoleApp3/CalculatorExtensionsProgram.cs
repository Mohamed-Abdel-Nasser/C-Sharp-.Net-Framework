using System;
namespace CalculatorExtensionsSystem
{
    class CalculatorExtensionsProgram
    {
        static void Main(string[] args)
        {
            // Call different overloads of the Add method
            Console.WriteLine($"Addition of two integers: {Calculator.Add(10, 20)}");
            Console.WriteLine($"Addition of three integers: {Calculator.Add(10, 20, 30)}");
            Console.WriteLine($"Addition of two doubles: {Calculator.Add(3.5, 2.5)}");
        }
    }

    class Calculator
    {
        // Method to add two integers
        public static int Add(int a, int b)
        {
            return a + b;
        }

        // Method to add three integers
        public static int Add(int a, int b, int c)
        {
            return a + b + c;
        }

        // Method to add two doubles
        public static double Add(double a, double b)
        {
            return a + b;
        }
    }

}



