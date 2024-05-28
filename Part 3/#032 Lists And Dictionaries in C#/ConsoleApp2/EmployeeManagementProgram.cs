using System;
using System.Collections.Generic;
namespace EmployeeManagementSystem
{
    class EmployeeManagementProgram
    {
        static Dictionary<int, Employee> employees = new Dictionary<int, Employee>();

        static void Main(string[] args)
        {
            Console.Title = "Employee Management System";

            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("===========================");
                Console.WriteLine("Employee Management System");
                Console.WriteLine("===========================");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("1. Add New Employee");
                Console.WriteLine("2. View Employee Details");
                Console.WriteLine("3. Edit Employee Details");
                Console.WriteLine("4. Delete Employee");
                Console.WriteLine("5. Exit");
                Console.WriteLine("===========================");
                Console.Write("Enter your choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter a number.");
                    Console.ResetColor();
                    Console.ReadKey();
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        AddEmployee();
                        break;
                    case 2:
                        ViewEmployeeDetails();
                        break;
                    case 3:
                        EditEmployeeDetails();
                        break;
                    case 4:
                        DeleteEmployee();
                        break;
                    case 5:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Exiting...");
                        Console.ResetColor();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                        Console.ResetColor();
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }

        static void AddEmployee()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Add New Employee");
            Console.WriteLine("----------------");

            Console.Write("Enter Employee ID: ");
            int id;
            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input for ID. Please enter a valid integer.");
                Console.ResetColor();
                return;
            }

            if (employees.ContainsKey(id))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Employee with ID {id} already exists.");
                Console.ResetColor();
                return;
            }

            Console.Write("Enter Employee Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Employee Department: ");
            string department = Console.ReadLine();

            Console.Write("Enter Employee Position: ");
            string position = Console.ReadLine();

            Console.Write("Enter Employee Date of Birth (MM/dd/yyyy): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime dateOfBirth))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid date format. Please enter date in MM/dd/yyyy format.");
                Console.ResetColor();
                return;
            }

            Console.Write("Enter Employee Salary: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal salary))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input for salary. Please enter a valid number.");
                Console.ResetColor();
                return;
            }

            employees.Add(id, new Employee(id, name, department, position, dateOfBirth, salary));

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Employee {name} added successfully.");
            Console.ResetColor();
        }

        static void ViewEmployeeDetails()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("View Employee Details");
            Console.WriteLine("---------------------");

            if (employees.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("No employees found.");
                Console.ResetColor();
                return;
            }

            Console.WriteLine("List of Employees:");
            foreach (var employee in employees.Values)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"ID: {employee.Id}, Name: {employee.Name}, Department: {employee.Department}, Position: {employee.Position}, " +
                    $"Date of Birth: {employee.DateOfBirth.ToString("MM/dd/yyyy")}, Salary: {employee.Salary:C}");
            }
            Console.ResetColor();
        }

        static void EditEmployeeDetails()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Edit Employee Details");
            Console.WriteLine("---------------------");

            Console.Write("Enter Employee ID to edit details: ");
            int id;
            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input for ID. Please enter a valid integer.");
                Console.ResetColor();
                return;
            }

            if (!employees.ContainsKey(id))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Employee with ID {id} not found.");
                Console.ResetColor();
                return;
            }

            Employee emp = employees[id];

            Console.Write("Enter New Employee Name: ");
            string newName = Console.ReadLine();

            Console.Write("Enter New Employee Department: ");
            string newDept = Console.ReadLine();

            Console.Write("Enter New Employee Position: ");
            string newPos = Console.ReadLine();

            Console.Write("Enter New Employee Date of Birth (MM/dd/yyyy): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime newDateOfBirth))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid date format. Please enter date in MM/dd/yyyy format.");
                Console.ResetColor();
                return;
            }

            Console.Write("Enter New Employee Salary: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal newSalary))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input for salary. Please enter a valid number.");
                Console.ResetColor();
                return;
            }

            emp.Name = newName;
            emp.Department = newDept;
            emp.Position = newPos;
            emp.DateOfBirth = newDateOfBirth;
            emp.Salary = newSalary;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Employee details updated successfully.");
            Console.ResetColor();
        }

        static void DeleteEmployee()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Delete Employee");
            Console.WriteLine("---------------------");

            Console.Write("Enter Employee ID to delete: ");
            int id;
            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input for ID. Please enter a valid integer.");
                Console.ResetColor();
                return;
            }

            if (!employees.ContainsKey(id))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Employee with ID {id} not found.");
                Console.ResetColor();
                return;
            }

            employees.Remove(id);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Employee with ID {id} deleted successfully.");
            Console.ResetColor();
        }
    }

    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal Salary { get; set; }

        public Employee(int id, string name, string department, string position, DateTime dateOfBirth, decimal salary)
        {
            Id = id;
            Name = name;
            Department = department;
            Position = position;
            DateOfBirth = dateOfBirth;
            Salary = salary;
        }
    }

}
