namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {
            var person1 = new Person { FirstName = "John", LastName = "Doe", DateOfBirth = new DateTime(1985, 10, 15) };
            var person2 = new Person { FirstName = "John", LastName = "Doe", DateOfBirth = new DateTime(1985, 10, 15) };

            Console.WriteLine(person1 == person2);  // True (uses overloaded == operator)
            Console.WriteLine(person1.Equals(person2));  // True (uses overridden Equals method)

            Console.ReadKey();
        }
    }
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Person))
                return false;

            var otherPerson = (Person)obj;
            return this.FirstName == otherPerson.FirstName
                && this.LastName == otherPerson.LastName
                && this.DateOfBirth == otherPerson.DateOfBirth;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FirstName, LastName, DateOfBirth);
        }

        public static bool operator ==(Person person1, Person person2)
        {
            if (object.ReferenceEquals(person1, person2))
                return true;
            if (person1 is null || person2 is null)
                return false;

            return person1.Equals(person2);
        }

        public static bool operator !=(Person person1, Person person2)
        {
            return !(person1 == person2);
        }
    }
}
