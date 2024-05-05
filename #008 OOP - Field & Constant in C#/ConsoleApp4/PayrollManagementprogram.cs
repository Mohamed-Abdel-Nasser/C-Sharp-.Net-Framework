namespace PayrollManagementSystem
{
    internal class PayrollManagementprogram
    {
        static void Main(String[] args)
        {
            Employee[] emps = new Employee[2];
            Console.WriteLine("Tax");
            Employee.Tax = Convert.ToDouble(Console.ReadLine());


            // First Employee
            Employee employee1 = new Employee();
            Console.WriteLine("First Employee");
            Console.WriteLine("***************");

            Console.WriteLine("First Name ");
            employee1.fName = Console.ReadLine();

            Console.WriteLine("last Name");
            employee1.lName = Console.ReadLine();

            Console.WriteLine("Wage");
            employee1.wage = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Logged Hours");
            employee1.loggedHours = Convert.ToDouble(Console.ReadLine());
            emps[0] = employee1;


            // Second Employee  
            Employee employee2 = new Employee();
            Console.WriteLine("Second Employee");
            Console.WriteLine("***************************************");

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
                var salary = emp.wage * emp.loggedHours;
                var taxAmount = salary * Employee.Tax;
                var netSalary = salary - taxAmount;

                Console.WriteLine("#########################################");
                Console.WriteLine($"First Name: {emp.fName}");
                Console.WriteLine($" Last Name: {emp.lName}");
                Console.WriteLine($"Wage: {emp.wage}");
                Console.WriteLine($"Logged Hours: {emp.loggedHours}");
                Console.WriteLine("-------------------------------------------");

                Console.WriteLine($"Salary: {salary}");
                Console.WriteLine($"Tax Deduction ({Employee.Tax * 100}%) Amount ${taxAmount}");
                Console.WriteLine($"Net Salary: {netSalary}\n");

            }
            Console.ReadKey();

        }
    }

    public class Employee
    {
        public static double Tax = 0.03;
        public int id;
        public string fName;
        public string lName;
        public double wage;
        public double loggedHours;

    }
}
