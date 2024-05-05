namespace EmployeePayrollSystem
{
    class EmployeePayrollProgram
    {
        static void Main(string[] args)
        {
            const double defaultTaxRate = 0.03;

            // Create an array to hold employee objects
            Employee[] employees = new Employee[2];

            Console.WriteLine("Welcome to the Employee Payroll System!");

            // Input tax rate from the user
            Console.Write("Enter the tax rate (e.g., 0.03 for 3%): ");
            if (!double.TryParse(Console.ReadLine(), out double taxRate))
            {
                Console.WriteLine("Invalid tax rate entered. Using default tax rate (3%).");
                taxRate = defaultTaxRate;
            }

            for (int i = 0; i < employees.Length; i++)
            {
                Console.WriteLine($"\nEmployee {i + 1}");
                Console.WriteLine("********************");

                // Create a new employee object
                Employee employee = new Employee();

                Console.Write("Enter first name: ");
                employee.FirstName = Console.ReadLine();

                Console.Write("Enter last name: ");
                employee.LastName = Console.ReadLine();

                Console.Write("Enter hourly wage: ");
                if (!double.TryParse(Console.ReadLine(), out double wage) || wage <= 0)
                {
                    Console.WriteLine("Invalid wage entered. Defaulting to $10.00 per hour.");
                    wage = 10.00;
                }
                employee.HourlyWage = wage;

                Console.Write("Enter logged hours: ");
                if (!double.TryParse(Console.ReadLine(), out double hours) || hours < 0)
                {
                    Console.WriteLine("Invalid logged hours entered. Defaulting to 0 hours.");
                    hours = 0;
                }
                employee.LoggedHours = hours;

                // Add the employee to the array
                employees[i] = employee;
            }

            Console.WriteLine("\nEmployee Payroll Summary");
            Console.WriteLine("************************");

            foreach (var employee in employees)
            {
                // Calculate salary details
                double salary = employee.HourlyWage * employee.LoggedHours;
                double taxAmount = salary * taxRate;
                double netSalary = salary - taxAmount;

                // Display employee details and salary information
                Console.WriteLine($"First Name: {employee.FirstName}");
                Console.WriteLine($"Last Name: {employee.LastName}");
                Console.WriteLine($"Hourly Wage: ${employee.HourlyWage:F2}");
                Console.WriteLine($"Logged Hours: {employee.LoggedHours}");
                Console.WriteLine($"Gross Salary: ${salary:F2}");
                Console.WriteLine($"Tax Deduction ({taxRate * 100}%): ${taxAmount:F2}");
                Console.WriteLine($"Net Salary: ${netSalary:F2}\n");
            }

            Console.WriteLine("Thank you for using the Employee Payroll System!");
            Console.ReadKey();
        }
    }

    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double HourlyWage { get; set; }
        public double LoggedHours { get; set; }
    }
}

