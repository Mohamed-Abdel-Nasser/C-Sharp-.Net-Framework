using System;
using System.Collections.Generic;

namespace ConsoleApp3.CustomAttributesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a list of products with prices
            List<Product> products = new List<Product>
            {
                new Product { Name = "Laptop", Price = 1500 },
                new Product { Name = "Smartphone", Price = 800 },
                new Product { Name = "Headphones", Price = 120 },
                new Product { Name = "Tablet", Price = 2500 }
            };

            // Validate each product's price using custom attribute
            var validationErrors = new List<string>();
            foreach (var product in products)
            {
                var validationResults = ValidateProduct(product);
                if (validationResults.Count > 0)
                {
                    validationErrors.AddRange(validationResults);
                }
            }

            // Display validation results
            if (validationErrors.Count > 0)
            {
                Console.WriteLine("Validation Errors:");
                foreach (var error in validationErrors)
                {
                    Console.WriteLine($"- {error}");
                }
            }
            else
            {
                Console.WriteLine("All products are valid.");
            }
        }
        static List<string> ValidateProduct(Product product)
        {
            var errors = new List<string>();
            if (product == null)
            {
                errors.Add("Product instance is null.");
                return errors;
            }

            var properties = typeof(Product).GetProperties();

            foreach (var property in properties)
            {
                var rangeAttribute = (RangeAttribute)Attribute.GetCustomAttribute(property, typeof(RangeAttribute));
                if (rangeAttribute != null && property.PropertyType == typeof(decimal))
                {
                    var value = (decimal)property.GetValue(product);
                    if (value.CompareTo(rangeAttribute.Minimum) < 0 || value.CompareTo(rangeAttribute.Maximum) > 0)
                    {
                        errors.Add($"{product.Name}: {property.Name} value is out of range.");
                    }
                }
            }

            return errors;
        }
    }

    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class RangeAttribute : Attribute
    {
        public decimal Minimum { get; }
        public decimal Maximum { get; }

        public RangeAttribute(decimal minimum, decimal maximum)
        {
            Minimum = minimum;
            Maximum = maximum;
        }
    }
}
