namespace ConsoleApp7
{
    class Program
    {
        static void Main(string[] args)
        {
            var student1 = new Student("Alice", 101);
            var student2 = new Student("Bob", 102);
            var student3 = new Student("Alice", 101);

            Console.WriteLine(student1.Equals(student2));  // False
            Console.WriteLine(student1.Equals(student3));  // True

            Console.WriteLine(student1.GetHashCode());  // Unique hash code based on Name and StudentId
            Console.WriteLine(student2.GetHashCode());  // Unique hash code based on Name and StudentId
            Console.WriteLine(student3.GetHashCode());  // Same as student1's hash code

            Console.ReadKey();
        }
    }

    public class Student
    {
        public string Name { get; }
        public int StudentId { get; }

        public Student(string name, int studentId)
        {
            Name = name;
            StudentId = studentId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, StudentId);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Student))
                return false;

            var otherStudent = (Student)obj;
            return this.StudentId == otherStudent.StudentId;
        }
    }
}
