using System.Xml.Linq;

namespace SalesReportGeneratorSystem
{
    internal class SalesReportProgram
    {


        static void Main(string[] args)
        {
            var emps = new Employee[]
{
            new Employee {Id = 1, Name = "Issam  A", Gender = "M", TotalSales = 65000m },
            new Employee {Id = 2, Name = "Reem   S", Gender = "F", TotalSales = 50000m},
            new Employee {Id = 3, Name = "Suzan  B", Gender = "F", TotalSales = 65000m },
            new Employee {Id = 4, Name = "Sara   A", Gender = "F", TotalSales = 40000m },
            new Employee {Id = 5, Name = "Salah  C", Gender = "M", TotalSales = 42000m },
            new Employee {Id = 6, Name = "Rateb  A", Gender = "M", TotalSales = 30000m},
            new Employee {Id = 7, Name = "Abeer  C", Gender = "F", TotalSales = 16000m },
            new Employee {Id = 8, Name = "Marwan M", Gender = "M", TotalSales = 15000m },
            };

            //var report = new Report();
            //report.PrintEmployeesWithSale60kOrPlus(emps);
            //report.PrintEmployeesWithSalesBetween30kAnd60k(emps);
            //report.PrintEmployeesWithSaleLessThan30k(emps);
            //Console.ReadKey();

            //var report = new Report();
            //report.PrintEmployee(emps, "Employees With Total Sales $60K Or Plus", IsGreaterThanOrEqual60000);
            //report.PrintEmployee(emps, "Employees With Total Sales Btween $30K - $60K", IsBetween30000And59999);
            //report.PrintEmployee(emps, "Employees With Total Sales Less Than $30K", IsLessThan30000);
            //Console.ReadKey();

            //ANNONYMOUS DELEGATE
            //var report = new Report();
            //report.PrintEmployee(emps, "Employees With Total Sales $60K Or Plus", delegate (Employee employee) { return employee.TotalSales > 60000m; });
            //report.PrintEmployee(emps, "Employees With Total Sales Btween $30K - $60K", delegate (Employee employee) { return employee.TotalSales >= 30000m && employee.TotalSales > 60000m; });
            //report.PrintEmployee(emps, "Employees With Total Sales Less Than $30K", delegate (Employee employee) { return employee.TotalSales > 3000m; }  );
            //Console.ReadKey();

            // lambda expressions
            var report = new Report();
            report.PrintEmployee(emps, "Employees With Total Sales $60K Or Plus", employee => employee.TotalSales > 60000m);
            report.PrintEmployee(emps, "Employees With Total Sales Btween $30K - $60K", employee => employee.TotalSales >= 30000m && employee.TotalSales > 60000m);
            report.PrintEmployee(emps, "Employees With Total Sales Less Than $30K", employee => employee.TotalSales > 3000m);
            Console.ReadKey();
        }



        //static bool IsGreaterThanOrEqual60000(Employee employee) => employee.TotalSales > 60000m;
        //static bool IsBetween30000And59999(Employee employee) => employee.TotalSales >= 30000m && employee.TotalSales < 60000m;
        //static bool IsLessThan30000(Employee employee) => employee.TotalSales < 30000m;
    }



    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal TotalSales { get; set; }
        public string Gender { get; set; }
    }
    public class Report
    {
        public delegate bool IllegibleSales(Employee employee);
        public void PrintEmployee(Employee[] employees, string title, IllegibleSales isIllegible)
        {
            Console.WriteLine(title);
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            foreach (var employee in employees)
            {
                if (isIllegible(employee))
                {
                    Console.WriteLine($"{employee.Id} | {employee.Name} | {employee.Gender} | ${employee.TotalSales}");
                }
            }
            Console.WriteLine("\n\n");
        }
        public void PrintEmployeesWithSale60kOrPlus(Employee[] employees)
        {
            Console.WriteLine("Employees with $60,000+ Sales");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            foreach (var eemployee in employees)
            {
                if (eemployee.TotalSales >= 60000m)
                {
                    Console.WriteLine($"{eemployee.Id} | {eemployee.Name} | {eemployee.Gender} | ${eemployee.TotalSales}");
                }
                Console.WriteLine("\n\n");

            }
        }
        public void PrintEmployeesWithSalesBetween30kAnd60k(Employee[] employees)
        {
            Console.WriteLine("Employees with sales between $30,000 And $59,999 Sales");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            foreach (var employee in employees)
            {
                if (employee.TotalSales < 60000m && employee.TotalSales >= 30000m)
                {
                    Console.WriteLine($"{employee.Id} | {employee.Name} | {employee.Gender} | ${employee.TotalSales}");
                }
            }
            Console.WriteLine("\n\n");

        }
        public void PrintEmployeesWithSaleLessThan30k(Employee[] employees)
        {
            Console.WriteLine("Employees with sales Less Than $30,000");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            foreach (var e in employees)
            {
                if (e.TotalSales < 30000m)
                {
                    Console.WriteLine($"{e.Id} | {e.Name} | {e.Gender} | ${e.TotalSales}");
                }
            }
            Console.WriteLine("\n\n");
        }
    }

}
