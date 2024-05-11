namespace MathDelegateApp
{
    public delegate void MathOperation(int x, int y); // Delegate declaration
    class MathDelegateProgram
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();
            MathOperation operation;
            operation = calc.Add; // Instantiate delegates with methods
            operation += calc.Subtract; // Multicast delegate (adding another method)
            operation += calc.Multiply; // Multicast delegate (adding another method)           
            operation(10, 5);  // Invoke the delegate, which in turn invokes all methods it references

            Console.ReadKey();
        }
    }

    public class Calculator
    {
        public void Add(int x, int y)
        {
            Console.WriteLine($"{x} + {y} = {x + y}");
        }

        public void Subtract(int x, int y)
        {
            Console.WriteLine($"{x} - {y} = {x - y}");
        }

        public void Multiply(int x, int y)
        {
            Console.WriteLine($"{x} * {y} = {x * y}");
        }
    }

}
