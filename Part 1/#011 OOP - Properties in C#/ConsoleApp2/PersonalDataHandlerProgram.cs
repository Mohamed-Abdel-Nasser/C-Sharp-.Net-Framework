namespace PersonalDataHandlerSystem
{
    public class PersonalDataHandlerProgram
    {
        public static void Main()
        {
            try
            {
                Person person = new Person("Mohamed Abdel Nasser", 28);
                Console.WriteLine(person.Info);

                // Uncomment the lines below to see how validation works:
                // Person invalidPerson = new Person(null, -5); // Throws exceptions due to invalid input
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Console.ReadKey();
        }
    }
    public class Person
    {
        private string name;
        private int age;

        public string Name
        {
            get => name;
            set => name = !string.IsNullOrWhiteSpace(value) ? value : throw new ArgumentException("Name cannot be null or empty.");
        }

        public int Age
        {
            get => age;
            set => age = value >= 0 ? value : throw new ArgumentOutOfRangeException("Age cannot be negative.");
        }

        public string Info => $"Name: {Name}, Age: {Age}";

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }



}


