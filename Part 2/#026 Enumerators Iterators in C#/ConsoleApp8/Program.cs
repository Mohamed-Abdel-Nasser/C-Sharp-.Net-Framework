namespace ConsoleApp8
{
    class Program
    {
        static void Main(string[] args)
        {
            var product1 = new Product("Laptop", 1);
            var product2 = new Product("Laptop", 1);
            var product3 = new Product("Desktop", 2);

            Console.WriteLine(product1.Equals(product2));  // True
            Console.WriteLine(product1.Equals(product3));  // False

            Console.WriteLine(product1.GetHashCode());  // Same as product2's hash code
            Console.WriteLine(product3.GetHashCode());  // Unique hash code based on Name and CategoryId

            Console.ReadKey();
        }
    }
    public class Product
    {
        public string Name { get; }
        public int CategoryId { get; }

        public Product(string name, int categoryId)
        {
            Name = name;
            CategoryId = categoryId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, CategoryId);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Product))
                return false;

            var otherProduct = (Product)obj;
            return this.Name == otherProduct.Name && this.CategoryId == otherProduct.CategoryId;
        }
    }
}


