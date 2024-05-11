namespace ConsoleApp2
{
    class Program
    {
        static void Main()
        {
            // Create two complex numbers
            ComplexNumber c1 = new ComplexNumber(2, 3);
            ComplexNumber c2 = new ComplexNumber(1, -4);

            // Perform arithmetic operations using overloaded operators
            ComplexNumber sum = c1 + c2;
            ComplexNumber difference = c1 - c2;
            ComplexNumber product = c1 * c2;

            // Display the results
            Console.WriteLine($"Sum: {sum}");
            Console.WriteLine($"Difference: {difference}");
            Console.WriteLine($"Product: {product}");

            Console.ReadKey ();
        }
    }
    public class ComplexNumber
    {

        public double Real { get; }
        public double Imaginary { get; }

        public ComplexNumber(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        // Overload addition operator (+) for complex number addition
        public static ComplexNumber operator +(ComplexNumber c1, ComplexNumber c2)
        {
            double realPart = c1.Real + c2.Real;
            double imaginaryPart = c1.Imaginary + c2.Imaginary;
            return new ComplexNumber(realPart, imaginaryPart);
        }

        // Overload subtraction operator (-) for complex number subtraction
        public static ComplexNumber operator -(ComplexNumber c1, ComplexNumber c2)
        {
            double realPart = c1.Real - c2.Real;
            double imaginaryPart = c1.Imaginary - c2.Imaginary;
            return new ComplexNumber(realPart, imaginaryPart);
        }

        // Overload multiplication operator (*) for complex number multiplication
        public static ComplexNumber operator *(ComplexNumber c1, ComplexNumber c2)
        {
            double realPart = (c1.Real * c2.Real) - (c1.Imaginary * c2.Imaginary);
            double imaginaryPart = (c1.Real * c2.Imaginary) + (c1.Imaginary * c2.Real);
            return new ComplexNumber(realPart, imaginaryPart);
        }

        // Override ToString method to display complex numbers in a readable format
        public override string ToString()
        {
            string sign = (Imaginary >= 0) ? "+" : "-";
            return $"{Real} {sign} {Math.Abs(Imaginary)}i";
        }
    }

   
}
