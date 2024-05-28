namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            var employees = new List<Employee>();

            // Populate the list with sample employee data
            employees.Add(new Employee("John Doe", 50000));
            employees.Add(new Employee("Jane Smith", 60000));
            employees.Add(new Employee("Mike Johnson", 55000));

            // Sort the list of employees by salary
            employees.Sort();

            // Display sorted list of employees
            Console.WriteLine("Employees sorted by salary:");
            foreach (var employee in employees)
            {
                Console.WriteLine($"Name: {employee.Name}, Salary: {employee.Salary}");
            }

            Console.ReadKey();
        }
    }

    class Employee : IComparable<Employee>
    {
        public string Name { get; }
        public decimal Salary { get; }

        public Employee(string name, decimal salary)
        {
            this.Name = name;
            this.Salary = salary;
        }

        public int CompareTo(Employee other)
        {
            if (other == null)
                return 1;

            // Compare employees by their salary
            return Salary.CompareTo(other.Salary);
        }
    }
}
