namespace ProductManagementSystem
{
    class ProductManagementProgram
    {
        static void Main()
        {
            try
            {
                Product product1 = new Product(1, "Laptop", 1200m);
                Console.WriteLine(product1);

                Product product2 = new Product(2, "", 0m); // This will throw an ArgumentException
                Console.WriteLine(product2); // This line will not be reached
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error creating product: {ex.Message}");
            }
        }
    }
    public class Product
    {
        public int Id { get; }
        public string Name { get; }
        public decimal Price { get; }

        public Product(int id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
            ValidateProduct();
        }

        private void ValidateProduct()
        {
            if (Id <= 0)
                throw new ArgumentException("Product ID must be greater than zero.");

            if (string.IsNullOrEmpty(Name))
                throw new ArgumentException("Product name cannot be empty or null.");

            if (Price <= 0)
                throw new ArgumentException("Product price must be greater than zero.");
        }

        public override string ToString()
        {
            return $"Product ID: {Id}, Name: {Name}, Price: {Price:C}";
        }
    }

}
