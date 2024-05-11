using System;
using System.Collections.Generic;
namespace HRManagementSystem
{
    // Delegate for handling employee events
    public delegate void EmployeeEventHandler(object sender, EmployeeEventArgs e);
    public class HRManagementProgram
    {
        public static void Main()
        {
            var hr = new HRDepartment();
            var payroll = new PayrollSystem();

            // Subscribe the PayrollSystem's ProcessPayroll method to the EmployeeHired event
            hr.EmployeeHired += payroll.ProcessPayroll;

            // Hire new employees
            var employeesToHire = new List<Employee>
        {
            new Employee { EmployeeId = 1, Name = "John Doe", Salary = 50000 },
            new Employee { EmployeeId = 2, Name = "Jane Smith", Salary = 60000 }
        };

            foreach (var employee in employeesToHire)
            {
                try
                {
                    hr.HireEmployee(employee);
                    Console.WriteLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error hiring employee: {ex.Message}");
                }
            }
            Console.ReadKey();
        }

    }
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }

    }
    public class HRDepartment
    {
        // Event to notify when an employee is hired
        public event EmployeeEventHandler EmployeeHired;

        // Method to hire a new employee
        public void HireEmployee(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee), "Employee cannot be null.");

            Console.WriteLine($"Hiring new employee: {employee.Name}");

            // Raise the EmployeeHired event with event args
            OnEmployeeHired(new EmployeeEventArgs(employee));
        }
        protected virtual void OnEmployeeHired(EmployeeEventArgs e)
        {
            EmployeeHired?.Invoke(this, e);
        }
    }
    public class PayrollSystem
    {
        // Method to calculate and process payroll
        public void ProcessPayroll(object sender, EmployeeEventArgs e)
        {
            if (e == null || e.Employee == null)
                throw new ArgumentNullException(nameof(e), "Invalid employee event arguments.");

            var employee = e.Employee;
            Console.WriteLine($"Processing payroll for employee: {employee.Name}");
            Console.WriteLine($"Salary: {employee.Salary}");
        }
    }
    // Event arguments for employee events
    public class EmployeeEventArgs : EventArgs
    {
        public Employee Employee { get; set; }

        public EmployeeEventArgs(Employee employee)
        {
            Employee = employee;
        }
    }



}
