using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
namespace DataMagnitudeManagerSystem
{
    class DataMagnitudeManagerProgram
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a DigitalSize instance interactively
                Console.Write("Enter the size in bits: ");
                long inputBits = long.Parse(Console.ReadLine());
                DigitalSize size = new DigitalSize(inputBits);

                // Add more bits to the size
                Console.Write("Enter additional bits to add: ");
                long additionalBits = long.Parse(Console.ReadLine());
                size = size.AddBits(additionalBits);

                // Display the size information
                Console.WriteLine($"Size: {size}");
                Console.WriteLine($"Size in bytes: {size.Bytes:N0} bytes");
                Console.WriteLine($"Size in kilobytes: {size.ToString("KB")}");
                Console.WriteLine($"Size in megabytes: {size.ToString("MB")}");
                Console.WriteLine($"Size in gigabytes: {size.ToString("GB")}");
                Console.WriteLine($"Size in terabytes: {size.ToString("TB")}");

                // Compare sizes
                DigitalSize anotherSize = new DigitalSize(80000);
                if (size.Bytes > anotherSize.Bytes)
                {
                    Console.WriteLine("The first size is larger than the second size.");
                }
                else
                {
                    Console.WriteLine("The first size is smaller than or equal to the second size.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Input value is too large. Please enter a smaller number.");
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }

    public class DigitalSize
    {
        private const long BitsInByte = 8;
        private const long BytesInKilobyte = 1024;
        private const long BytesInMegabyte = BytesInKilobyte * 1024;
        private const long BytesInGigabyte = BytesInMegabyte * 1024;
        private const long BytesInTerabyte = BytesInGigabyte * 1024;

        private long bits;

        public DigitalSize(long bits)
        {
            if (bits < 0)
            {
                throw new ArgumentException("Size cannot be negative.", nameof(bits));
            }

            this.bits = bits;
        }

        public long Bits => bits;
        public long Bytes => bits / BitsInByte;
        public double Kilobytes => (double)Bytes / BytesInKilobyte;
        public double Megabytes => (double)Bytes / BytesInMegabyte;
        public double Gigabytes => (double)Bytes / BytesInGigabyte;
        public double Terabytes => (double)Bytes / BytesInTerabyte;

        public DigitalSize AddBits(long additionalBits)
        {
            if (additionalBits < 0)
            {
                throw new ArgumentException("Additional bits cannot be negative.", nameof(additionalBits));
            }

            return new DigitalSize(bits + additionalBits);
        }

        public override string ToString()
        {
            return $"{bits:N0} bits";
        }

        public string ToString(string format)
        {
            switch (format.ToLower())
            {
                case "b":
                    return $"{Bytes:N0} bytes";
                case "kb":
                    return $"{Kilobytes:N2} KB";
                case "mb":
                    return $"{Megabytes:N2} MB";
                case "gb":
                    return $"{Gigabytes:N2} GB";
                case "tb":
                    return $"{Terabytes:N2} TB";
                default:
                    return ToString(); // Default to displaying in bits
            }
        }
    }
}
