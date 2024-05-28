using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int> { 10, 20, 30, 40, 50 };

        // Check if a number exists in the list
        bool hasThirty = numbers.Exists(x => x == 30);

        if (hasThirty)
        {
            Console.WriteLine("The list contains the number 30.");
        }
        else
        {
            Console.WriteLine("The list does not contain the number 30.");
        }
    }
}
