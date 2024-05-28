namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            var products = new List<Product>();

            // Populate the list with sample product data
            products.Add(new Product("Laptop", 1200));
            products.Add(new Product("Smartphone", 800));
            products.Add(new Product("Tablet", 500));

            // Sort the list of products by price
            products.Sort();

            // Display sorted list of products
            Console.WriteLine("Products sorted by price:");
            foreach (var product in products)
            {
                Console.WriteLine($"Name: {product.Name}, Price: ${product.Price}");
            }

            Console.ReadKey();
        }
    }

    class Product : IComparable<Product>
    {
        public string Name { get; }
        public decimal Price { get; }

        public Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        public int CompareTo(Product other)
        {
            if (other == null)
                return 1;

            // Compare products by their price
            return Price.CompareTo(other.Price);
        }
    }
}
