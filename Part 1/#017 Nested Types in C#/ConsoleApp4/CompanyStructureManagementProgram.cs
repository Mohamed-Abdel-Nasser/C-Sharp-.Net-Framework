using System;
using System.Collections.Generic;
namespace CompanyStructureManagementSystem
{
    class CompanyStructureManagementProgram
    {
        static void Main(string[] args)
        {
            // Create a new company
            Company abcCompany = new Company("ABC Company");

            // Create departments
            Company.Department itDepartment = abcCompany.CreateDepartment("IT");
            Company.Department hrDepartment = abcCompany.CreateDepartment("HR");
            Company.Department financeDepartment = abcCompany.CreateDepartment("Finance");
            Company.Department auditDepartment = abcCompany.CreateDepartment("Audit");
            Company.Department operationDepartment = abcCompany.CreateDepartment("Operation");
            Company.Department marketingDepartment = abcCompany.CreateDepartment("Marketing");
            Company.Department salesDepartment = abcCompany.CreateDepartment("Sales");
            Company.Department purchaseDepartment = abcCompany.CreateDepartment("Purchase");

            // Create employees
            Company.Employee mohamedNAsser = itDepartment.CreateEmployee("Mohamed Abdel NAsser", 1001);
            Company.Employee ahmedNasser = hrDepartment.CreateEmployee("Ahmed Abdel Nasser", 1002);
            Company.Employee mustafaAbdelBasit = financeDepartment.CreateEmployee("Mustafa Abdel Basit", 1003);
            Company.Employee ibrhimAhmed = financeDepartment.CreateEmployee("Ibrhim Ahmed", 1004);
            Company.Employee aliMohaseb = auditDepartment.CreateEmployee("Ali Mohaseb", 1005);
            Company.Employee ibrahimAdel = auditDepartment.CreateEmployee("Ibrahim Adel", 1006);
            Company.Employee islamHorzallah = operationDepartment.CreateEmployee("Islam Horzallah", 1007);
            Company.Employee mostafaHorzallah = marketingDepartment.CreateEmployee("Mostafa Horzallah", 1008);
            Company.Employee islamGenedy = salesDepartment.CreateEmployee("Islam Genedy", 1009);
            Company.Employee khaledNasser = purchaseDepartment.CreateEmployee("Khaled Abdel Nasser", 1010);

            // Display company structure
            abcCompany.DisplayCompanyStructure();

            // Perform operations (e.g., promote employee, transfer employee)
            Console.WriteLine("\nPerforming operations...\n");

            // Promote Mohamed Abdel Nasser
            abcCompany.PromoteEmployee(mohamedNAsser);
            Console.WriteLine();

            // Transfer Mohamed Abdel Nasser to Marketing department
            itDepartment.TransferEmployee(mohamedNAsser, marketingDepartment);
            Console.WriteLine();

            // Transfer Sara Ali from Finance to Sales department
            financeDepartment.TransferEmployee(mustafaAbdelBasit, salesDepartment);
            Console.WriteLine();

            // Display updated company structure
            abcCompany.DisplayCompanyStructure();

            Console.ReadKey();
        }
    }
    // Define the Company class with nested Department and Employee classes
    class Company
    {
        public string Name { get; private set; }
        private List<Department> departments;

        public Company(string name)
        {
            Name = name;
            departments = new List<Department>();
        }

        public Department CreateDepartment(string name)
        {
            Department newDepartment = new Department(name);
            departments.Add(newDepartment);
            return newDepartment;
        }

        public void DisplayCompanyStructure()
        {
            Console.WriteLine("Company Structure:");
            Console.WriteLine("------------------");
            foreach (var department in departments)
            {
                department.DisplayDepartmentStructure();
                Console.WriteLine();
            }
        }

        public void PromoteEmployee(Employee employee)
        {
            Console.WriteLine($"Promoting Employee: {employee.Name}");
            employee.Promote();
        }

        // Nested Department class
        public class Department
        {
            public string Name { get; private set; }
            private List<Employee> employees;

            public Department(string name)
            {
                Name = name;
                employees = new List<Employee>();
            }

            public Employee CreateEmployee(string name, int employeeId)
            {
                Employee newEmployee = new Employee(name, employeeId);
                employees.Add(newEmployee);
                return newEmployee;
            }

            public void DisplayDepartmentStructure()
            {
                Console.WriteLine($"Department: {Name}");
                Console.WriteLine("Employees:");
                foreach (var employee in employees)
                {
                    Console.WriteLine($"- {employee.Name} (ID: {employee.EmployeeId})");
                }
            }

            public void TransferEmployee(Employee employee, Department newDepartment)
            {
                Console.WriteLine($"Transferring Employee {employee.Name} to Department: {newDepartment.Name}");
                employees.Remove(employee);
                newDepartment.employees.Add(employee);
            }
        }

        // Nested Employee class
        public class Employee
        {
            public string Name { get; private set; }
            public int EmployeeId { get; private set; }

            public Employee(string name, int employeeId)
            {
                Name = name;
                EmployeeId = employeeId;
            }

            public void Promote()
            {
                Console.WriteLine($"Employee {Name} has been promoted!");
            }
        }
    }

}
