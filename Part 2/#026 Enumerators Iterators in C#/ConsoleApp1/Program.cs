namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee employee1 = new Employee { Id = 100, Name = "Issam A", Salary = 1000m, Department = "IT" };
            Employee employee2 = new Employee { Id = 100, Name = "Issam A", Salary = 1000m, Department = "IT" };
            Employee employee3 = employee1;
            //Console.WriteLine(employee1 == employee2); // references
            //Console.WriteLine(employee1 == employee3); // references
            //Console.WriteLine(e1.Equals(employee2)); // Content

            Console.WriteLine(employee1 == employee2); // Content
            Console.WriteLine(employee1.Equals(employee2)); // Content

            Console.ReadKey();
        }

    }

    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }


        public override bool Equals(object obj)
        {
            if (obj is null || !(obj is Employee)) return false;
            var emp = obj as Employee; return
            this.Id == emp.Id
         && this.Name == emp.Name
         && this.Department == emp.Department
         && this.Salary == emp.Salary;
        }

        public override int GetHashCode()
        {
            int hash = 13;
            hash = (hash * 7) + Id.GetHashCode();
            hash = (hash * 7) + Name.GetHashCode();
            hash = (hash * 7) + Department.GetHashCode();
            hash = (hash * 7) + Salary.GetHashCode();
            return hash;
        }

        public static bool operator ==(Employee leftHandSide, Employee rightHandSide) => leftHandSide.Equals(rightHandSide);
        public static bool operator !=(Employee leftHandSide, Employee rightHandSide) => !leftHandSide.Equals(rightHandSide);

    }

}

