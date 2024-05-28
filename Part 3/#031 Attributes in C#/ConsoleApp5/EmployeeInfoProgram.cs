using System;
using System.Collections.Generic;

namespace EmployeeManagementSystem
{
    internal class EmployeeInfoProgram
    {
        static List<Employee> employees = new List<Employee>();
        static void Main(string[] args)
        {
            // Example employees (can be inputted by the user later)
            employees.Add(new Employee
            {
                Name = "Ahmed Abdel-Rahman",
                Age = 32,
                Salary = 60000,
                Department = "IT",
                MaritalStatus = "Married",
                PrivateAddress = "123 Private St., Cairo",
                PrivatePhone = "01012345678",
                PrivateEmail = "ahmed@example.com",
                WorkAddress = "456 Work Blvd., Cairo",
                WorkPhone = "01123456789",
                WorkEmail = "ahmed@company.com",
                Company = "Tech Solutions Ltd.",
                JobPosition = "Software Engineer"
            });

            employees.Add(new Employee
            {
                Name = "Fatma Ali",
                Age = 28,
                Salary = 55000,
                Department = "HR",
                MaritalStatus = "Single",
                PrivateAddress = "456 Private St., Alexandria",
                PrivatePhone = "01098765432",
                PrivateEmail = "fatma@example.com",
                WorkAddress = "789 Work Blvd., Alexandria",
                WorkPhone = "01187654321",
                WorkEmail = "fatma@company.com",
                Company = "HR Solutions Inc.",
                JobPosition = "HR Manager"
            });

            DisplayMenu();
        }

        static void DisplayMenu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Welcome to Employee Management System");
                Console.WriteLine("=====================================");
                Console.WriteLine("1. Display Employee Information");
                Console.WriteLine("2. Add New Employee");
                Console.WriteLine("3. Edit Employee Information");
                Console.WriteLine("4. Exit");
                Console.WriteLine("=====================================");
                Console.ResetColor();

                Console.Write("Select an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        DisplayEmployees();
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.Clear();
                        AddNewEmployee();
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.Clear();
                        EditEmployee();
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        break;
                    case "4":
                        exit = true;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid option. Please try again.");
                        Console.ResetColor();
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void DisplayEmployees()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Current Employee Information:");
            Console.ResetColor();
            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.Name}:");
               
                Console.WriteLine("Private Information:");
                Console.WriteLine($"    → Age: {employee.Age}");
                Console.WriteLine($"    → Marital Status: {employee.MaritalStatus}");
                Console.WriteLine($"    → Private Address: {employee.PrivateAddress}");
                Console.WriteLine($"    → Private Phone: {employee.PrivatePhone}");
                Console.WriteLine($"    → Private Email: {employee.PrivateEmail}");

                Console.WriteLine("Work Information:");
                Console.WriteLine($"    → Work Address: {employee.WorkAddress}");
                Console.WriteLine($"    → Work Phone: {employee.WorkPhone}");
                Console.WriteLine($"    → Work Email: {employee.WorkEmail}");
                Console.WriteLine($"    → Company: {employee.Company}");
                Console.WriteLine($"    → Job Position: {employee.JobPosition}");
                Console.WriteLine($"    → Salary: {employee.Salary:C0}");
                Console.WriteLine($"    → Department: {employee.Department}");


                Console.WriteLine();
            }
        }

        static void AddNewEmployee()
        {
            Console.WriteLine("Enter the new employee details:");

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Age: ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("Salary: ");
            decimal salary = decimal.Parse(Console.ReadLine());

            Console.Write("Department: ");
            string department = Console.ReadLine();

            Console.Write("Marital Status: ");
            string maritalStatus = Console.ReadLine();

            Console.Write("Private Address: ");
            string privateAddress = Console.ReadLine();

            Console.Write("Private Phone: ");
            string privatePhone = Console.ReadLine();

            Console.Write("Private Email: ");
            string privateEmail = Console.ReadLine();

            Console.Write("Work Address: ");
            string workAddress = Console.ReadLine();

            Console.Write("Work Phone: ");
            string workPhone = Console.ReadLine();

            Console.Write("Work Email: ");
            string workEmail = Console.ReadLine();

            Console.Write("Company: ");
            string company = Console.ReadLine();

            Console.Write("Job Position: ");
            string jobPosition = Console.ReadLine();

            employees.Add(new Employee
            {
                Name = name,
                Age = age,
                Salary = salary,
                Department = department,
                MaritalStatus = maritalStatus,
                PrivateAddress = privateAddress,
                PrivatePhone = privatePhone,
                PrivateEmail = privateEmail,
                WorkAddress = workAddress,
                WorkPhone = workPhone,
                WorkEmail = workEmail,
                Company = company,
                JobPosition = jobPosition
            });

            Console.WriteLine("Employee added successfully!");
        }

        static void EditEmployee()
        {
            Console.WriteLine("Select an employee to edit:");

            for (int i = 0; i < employees.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {employees[i].Name}");
            }

            Console.Write("Enter employee number: ");
            int employeeIndex = int.Parse(Console.ReadLine()) - 1;

            if (employeeIndex >= 0 && employeeIndex < employees.Count)
            {
                var employee = employees[employeeIndex];

                Console.WriteLine($"Editing employee: {employee.Name}");
                Console.WriteLine("Enter new information:");

                Console.Write("Age: ");
                employee.Age = int.Parse(Console.ReadLine());

                Console.Write("Salary: ");
                employee.Salary = decimal.Parse(Console.ReadLine());

                Console.Write("Department: ");
                employee.Department = Console.ReadLine();

                Console.Write("Marital Status: ");
                employee.MaritalStatus = Console.ReadLine();

                Console.Write("Private Address: ");
                employee.PrivateAddress = Console.ReadLine();

                Console.Write("Private Phone: ");
                employee.PrivatePhone = Console.ReadLine();

                Console.Write("Private Email: ");
                employee.PrivateEmail = Console.ReadLine();

                Console.Write("Work Address: ");
                employee.WorkAddress = Console.ReadLine();

                Console.Write("Work Phone: ");
                employee.WorkPhone = Console.ReadLine();

                Console.Write("Work Email: ");
                employee.WorkEmail = Console.ReadLine();

                Console.Write("Company: ");
                employee.Company = Console.ReadLine();

                Console.Write("Job Position: ");
                employee.JobPosition = Console.ReadLine();

                Console.WriteLine("Employee information updated successfully!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid employee number.");
                Console.ResetColor();
            }
        }
    }

    public class AgeAttribute : Attribute
    {
        public int Minimum { get; private set; }
        public int Maximum { get; private set; }

        public AgeAttribute(int minimum, int maximum)
        {
            Minimum = minimum;
            Maximum = maximum;
        }

        public bool IsValid(int value)
        {
            return value >= Minimum && value <= Maximum;
        }
    }

    public class Employee
    {
        public string Name { get; set; }

        [Age(18, 70)]
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public string Department { get; set; }

        // Private Information
        public string MaritalStatus { get; set; }
        public string PrivateAddress { get; set; }
        public string PrivatePhone { get; set; }
        public string PrivateEmail { get; set; }

        // Work Information
        public string WorkAddress { get; set; }
        public string WorkPhone { get; set; }
        public string WorkEmail { get; set; }
        public string Company { get; set; }
        public string JobPosition { get; set; }
    }
}
