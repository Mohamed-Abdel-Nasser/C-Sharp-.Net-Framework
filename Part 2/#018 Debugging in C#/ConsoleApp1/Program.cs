using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var f = ConvertCelsiusToFehrenhite(0);
            Console.WriteLine($"{0}C = {f}F");

            var c = ConvertFehrenhiteToCelsius(32);
            Console.WriteLine($"{0}F = {c}C");

            Console.ReadKey();
        }

        public static decimal ConvertCelsiusToFehrenhite(decimal clsius)
        {
            var fehrenhite = 0m;
            fehrenhite = (clsius * 9 / 5) + 32;
            return fehrenhite;
        }

        public static decimal ConvertFehrenhiteToCelsius(decimal fehrenhite)
        {
            var celsius = 0m;
            celsius = fehrenhite - 32 * 9 / 5;
            return celsius;
        }
    }
}
