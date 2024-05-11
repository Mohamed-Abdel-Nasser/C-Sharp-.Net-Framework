namespace EmployeeTrackerSystem
{
    class EmployeeTrackerProgram
    {
        static void Main()
        {
            Employee emp1 = new Employee("Mohamed A. Nasser", 30, 60000m);
            Console.WriteLine(emp1);

            Employee emp2 = new Employee("Ahmed A. Nasser", 25, 50000m);
            Console.WriteLine(emp2);

            Console.WriteLine($"Total Employees: {Employee.GetEmployeeCount()}");
            Console.ReadKey();
        }
    }
    public class Employee
    {
        public string Name { get; }
        public int Age { get; }
        public decimal Salary { get; }

        // Static field initialized in a static constructor
        private static int employeeCount;

        // Static constructor to initialize static members
        static Employee()
        {
            employeeCount = 0;
        }

        // Parameterized constructor with constructor initialization
        public Employee(string name, int age, decimal salary)
        {
            Name = name;
            Age = age;
            Salary = salary;
            employeeCount++;
        }

        // Method to get the total count of employees
        public static int GetEmployeeCount()
        {
            return employeeCount;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}, Salary: {Salary:C}";
        }
    }


}
