namespace ConsoleApp5
{
    class program
    {
        public static void Main(string[] args)
        {
            // Create a counter object
            Counter myCounter = new Counter(5);

            // Use prefix increment
            Console.WriteLine("Counter after prefix increment: {0}", ++myCounter); // Output: 6

            // Use postfix increment (value before increment)
            int beforePostfix = myCounter.Value;
            Console.WriteLine("Value before postfix increment: {0}", beforePostfix); // Output: 6 (value before increment)
            Console.WriteLine("Counter after postfix increment: {0}", myCounter++); // Output: 6 (value before increment)

            // Use addition operator
            Counter updatedCounter = myCounter + 3;
            Console.WriteLine("Counter after adding 3: {0}", updatedCounter); // Output: 9

            // Use subtraction operator
            updatedCounter = updatedCounter - 2;
            Console.WriteLine("Counter after subtracting 2: {0}", updatedCounter); // Output: 7

            // Use ToString method
            Console.WriteLine("Current counter value: {0}", myCounter.ToString()); // Output: 7

            Console.ReadKey();
        }


    }

    public class Counter
    {
        private int value;

        public int Value => this.value;

        public Counter(int initialValue)
        {
            this.value = initialValue;
        }

        public static Counter operator ++(Counter counter) // Prefix increment
        {
            counter.value++;
            return counter;
        }

        public static Counter operator --(Counter counter) // Prefix decrement
        {
            counter.value--;
            return counter;
        }

        public static Counter operator +(Counter counter, int amount) // Add value to counter
        {
            return new Counter(counter.value + amount);
        }

        public static Counter operator -(Counter counter, int amount) // Subtract value from counter
        {
            return new Counter(counter.value - amount);
        }

        public override string ToString()
        {
            return value.ToString();
        }
    }

}
