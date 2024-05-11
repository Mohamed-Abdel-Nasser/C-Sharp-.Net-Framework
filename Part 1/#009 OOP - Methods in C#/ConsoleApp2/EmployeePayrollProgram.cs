namespace EmployeePayrollSystem
{
    internal class EmployeePayrollProgram

    {
        static void Main(string[] args)
        {

            Employee[] emps = new Employee[2];

            Console.WriteLine("Tax");
            Employee.Tax = Convert.ToDouble(Console.ReadLine());

            Employee employee1 = new Employee();
            Console.WriteLine("First Employee");
            Console.WriteLine("************************************************");


            Console.WriteLine("First Name ");
            employee1.fName = Console.ReadLine();

            Console.WriteLine("last Name");
            employee1.lName = Console.ReadLine();

            Console.WriteLine("Wage");
            employee1.wage = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Logged Hours");
            employee1.loggedHours = Convert.ToDouble(Console.ReadLine());
            emps[0] = employee1;


            Employee employee2 = new Employee();
            Console.WriteLine("Second Employee");
            Console.WriteLine("***********************************************");

            Console.WriteLine("First Name ");
            employee2.fName = Console.ReadLine();

            Console.WriteLine("last Name");
            employee2.lName = Console.ReadLine();

            Console.WriteLine("Wage");
            employee2.wage = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Logged Hours");
            employee2.loggedHours = Convert.ToDouble(Console.ReadLine());
            emps[1] = employee2;

            foreach (var emp in emps)
            {
                Console.WriteLine(emp.printPayslip());
            }
            Console.ReadKey();

        }
    }

    public class Employee
    {
        public string fName;
        public string lName;
        public double wage;
        public double loggedHours;

        public static double Tax = 0.03;
        public double calculate() => wage * loggedHours;
        public double calculateTax() => calculate() * Tax;
        public double calculateNetSalary() => calculate() - calculateTax();

        public string printPayslip()
        {
            return $"\nFirst Name: {fName}" +
                    $"\nLast Name: {lName}" +
                    $"\nWage: {wage}" +
                    $"\nLogged Hours: {loggedHours}" +
                    $"\nSalary: ${calculate()}" +
                    $"\nDeductable Tax ({Tax * 100}%) Amount: ${calculateTax()}" + // 0.03 x 100 3%
                    $"\nNet Salary: ${calculateNetSalary()}\n";
        }

    }

}
