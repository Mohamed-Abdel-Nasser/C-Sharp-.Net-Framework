namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = new List<Person>();
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                int age = random.Next(18, 80);
                people.Add(new Person($"Person{i + 1}", age));
            }

            people.Sort();

            foreach (var person in people)
            {
                Console.WriteLine($"{person.Name}, Age: {person.Age}");
            }

            Console.ReadKey();
        }
    }

    class Person : IComparable
    {
        public string Name { get; }
        public int Age { get; }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public int CompareTo(object obj)
        {
            if (obj is null)
                return 1;

            var person = obj as Person;
            if (person is null)
                throw new ArgumentException("object is not a Person object");

            return this.Age.CompareTo(person.Age);
        }
    }
}
