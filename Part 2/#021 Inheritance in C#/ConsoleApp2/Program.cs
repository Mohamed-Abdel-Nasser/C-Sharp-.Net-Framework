using System;

class Program
{
    static void Main(string[] args)
    {
        Manager manager = new Manager(1000, "Ali A.", 180, 10);
        Maintenance maintenance = new Maintenance(1001, "Salim M.", 182, 8);
        Sales salesPerson = new Sales(1002, "Sally N.", 176, 9, 0.05m, 10000m);
        Developer developer = new Developer(1003, "Issam N.", 186, 15, true);

        Employee[] employees = { manager, maintenance, salesPerson, developer };

        Console.WriteLine("Employee Details:");
        
        foreach (var employee in employees)
        {
            Console.WriteLine("==================================================");
            Console.WriteLine($"Employee Department: {employee.GetType().Name}");
            Console.WriteLine($"Employee ID: {employee.Id}");
            Console.WriteLine($"Employee Name: {employee.Name}");
            Console.WriteLine($"Employee Logged Hours: {employee.LoggedHours} hrs");
            Console.WriteLine($"Employee Wage: ${employee.Wage} per hour");
            Console.WriteLine($"Employee Base Salary: ${employee.CalculateBaseSalary():N2}");

            if (employee is Manager)
            {
                Manager mgr = (Manager)employee;
                Console.WriteLine($"Employee Allowance: ${mgr.CalculateAllowance():N2}");
            }
            else if (employee is Maintenance)
            {
                Maintenance maint = (Maintenance)employee;
                Console.WriteLine($"Employee Hardship Allowance: ${Maintenance.HardshipAmount:N2}");
            }
            else if (employee is Sales)
            {
                Sales sales = (Sales)employee;
                Console.WriteLine($"Employee Commission Rate: {sales.Commission:P}");
                Console.WriteLine($"Employee Sales Volume: ${sales.SalesVolume:N2}");
                Console.WriteLine($"Employee Bonus: ${sales.CalculateBonus():N2}");
            }
            else if (employee is Developer)
            {
                Developer dev = (Developer)employee;
                Console.WriteLine($"Employee Task Completed: {(dev.TaskCompleted ? "Yes" : "No")}");
                Console.WriteLine($"Employee Bonus: ${dev.CalculateBonus():N2}");
            }

            Console.WriteLine($"Employee Overtime Pay: ${employee.CalculateOverTime():N2}");
            Console.WriteLine($"Employee Net Salary: ${employee.Calculate():N2}");
        }

        Console.ReadKey();
    }
}

public class Employee
{
    public int Id { get; protected set; }
    public string Name { get; protected set; }
    public decimal LoggedHours { get; protected set; }
    public decimal Wage { get; protected set; }

    public Employee(int id, string name, decimal loggedHours, decimal wage)
    {
        Id = id;
        Name = name;
        LoggedHours = loggedHours;
        Wage = wage;
    }

    public virtual decimal CalculateBaseSalary()
    {
        return LoggedHours * Wage;
    }

    public virtual decimal CalculateOverTime()
    {
        decimal overtimeHours = Math.Max(LoggedHours - 176, 0);
        return overtimeHours * Wage * 1.25m;
    }

    public virtual decimal Calculate()
    {
        return CalculateBaseSalary() + CalculateOverTime();
    }
}

public class Developer : Employee
{
    public bool TaskCompleted { get; protected set; }

    public Developer(int id, string name, decimal loggedHours, decimal wage, bool taskCompleted)
        : base(id, name, loggedHours, wage)
    {
        TaskCompleted = taskCompleted;
    }

    public override decimal Calculate()
    {
        decimal baseSalary = base.Calculate();
        return TaskCompleted ? baseSalary * 1.03m : baseSalary;
    }

    public decimal CalculateBonus()
    {
        return CalculateBaseSalary() * 0.03m;
    }
}

public class Manager : Employee
{
    public Manager(int id, string name, decimal loggedHours, decimal wage)
        : base(id, name, loggedHours, wage)
    {
    }

    public decimal CalculateAllowance()
    {
        return CalculateBaseSalary() * 0.05m;
    }
}

public class Maintenance : Employee
{
    public const decimal HardshipAmount = 100m;

    public Maintenance(int id, string name, decimal loggedHours, decimal wage)
        : base(id, name, loggedHours, wage)
    {
    }

    public override decimal Calculate()
    {
        return base.Calculate() + HardshipAmount;
    }
}

public class Sales : Employee
{
    public decimal Commission { get; protected set; }
    public decimal SalesVolume { get; protected set; }

    public Sales(int id, string name, decimal loggedHours, decimal wage, decimal commission, decimal salesVolume)
        : base(id, name, loggedHours, wage)
    {
        Commission = commission;
        SalesVolume = salesVolume;
    }

    public override decimal Calculate()
    {
        return base.Calculate() + (SalesVolume * Commission);
    }

    public decimal CalculateBonus()
    {
        return SalesVolume * Commission;
    }
}
