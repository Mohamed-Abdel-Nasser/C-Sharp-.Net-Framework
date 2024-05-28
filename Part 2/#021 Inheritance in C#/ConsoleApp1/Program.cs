namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Manager m = new Manager(1000, "Ali A.", 180, 10);
            Maintanence ms = new Maintanence(1001, "Salim M.", 182, 8);
            Sales s = new Sales(1002, "Sally N.", 176, 9, 0.05m, 10000m);
            Developer d = new Developer(1003, "Issam A.", 186, 15, true);
            Employee[] employees = { m, ms, s, d };

            foreach (var employee in employees)
            {
                Console.WriteLine("\n----------");
                Console.WriteLine(employee);
            }
            Console.ReadKey();
        }

    }

    public class Employee
    {
        public const int MinimumLoggedHours = 176;
        public const decimal OverTimeRate = 1.25m;
        protected int Id { get; set; }
        protected string Name { get; set; }
        protected decimal LoggedHours { get; set; }
        protected decimal Wage { get; set; }

        public Employee(int id, string name, decimal loggedHours, decimal wage)
        {
            Id = id;
            Name = name;
            LoggedHours = loggedHours;
            Wage = wage;
        }

       
        private decimal CalculateBaseSalary()
        {
            return LoggedHours * Wage;
        }

        public virtual decimal CalculateOverTime()
        {
            var additionalHours = ((LoggedHours - MinimumLoggedHours) > 0 ? LoggedHours - MinimumLoggedHours : 0);
            return (additionalHours * Wage * OverTimeRate);
        }

        protected virtual decimal Calculate()
        {
            return CalculateBaseSalary() + CalculateOverTime();
        }

        public override string ToString()
        {
            var type = GetType().ToString().Replace("CAInheritance.", "");
            return $"{type}" +
                   $"\nID {Id}" +
                   $"\nName {Name}" +
                   $"\nLogged Hours {LoggedHours} hrs" +
                   $"\nWage {Wage} $/hr" +
                   $"\nBase Salary: ${Math.Round(CalculateBaseSalary(), 2):NO}" +
                   $"\nOvertime: ${Math.Round(CalculateOverTime(), 2):NO}";
        }

    }
    public class Developer : Employee
    {
        private const decimal Commission = 0.03m;
        protected bool TaskCompleted { get; set; }

        public Developer(int id, string name, decimal loggedHours, decimal wage,
            bool taskCompleted) : base(id, name, loggedHours, wage)
        {
            this.TaskCompleted = taskCompleted;
        }
        protected override decimal Calculate()
        {
            return base.Calculate() + CalculateBonus();
        }
        private decimal CalculateBonus()
        {
            if (TaskCompleted) return base.Calculate() * Commission; return 0;
        }
        public override string ToString()
        {
            return base.ToString() +
            $"\nTask Completed: ${(TaskCompleted ? "Yes" : "No")}" +
            $"\nBonus: ${Math.Round(CalculateBonus(), 2): NO}" +
            $"\nNet Salary: ${Math.Round(this.Calculate(), 2):NO}";
        }
    }
    public class Manager : Employee
    {
        public Manager(int id, string name, decimal loggedHours, decimal wage) : base(id, name, loggedHours, wage)
        {
        }

        private const decimal AllowanceRate = 0.05m;
        protected override decimal Calculate()
        {
            return base.Calculate() + CalculateAllowance();
        }
        private decimal CalculateAllowance()
        {
            return base.Calculate() * AllowanceRate;
        }
        public override string ToString()
        {
            return base.ToString() +
                   $"\nAllowance: ${CalculateAllowance()}" +
                   $"\nNet Salary: ${this.Calculate()}";
        }

    }
    public class Maintanence : Employee
    {
        private const decimal Hardship = 100m;

        public Maintanence(int id, string name, decimal loggedHours, decimal wage) : base(id, name, loggedHours, wage)
        {
        }
        protected override decimal Calculate()
        {
            return base.Calculate() + Hardship;
        }
        public override string ToString()
        {
            return base.ToString() +
            $"\nHardship: ${Math.Round(Hardship, 2):NO}" +
            $"\nNet Salary: ${Math.Round(this.Calculate(), 2): NO}";
        }
    }
    public class Sales : Employee
    {
        protected decimal SalesVolume { get; set; }
        protected decimal Commission { get; set; }

        public Sales(int id, string name, decimal loggedHours, decimal wage,
            decimal salesVolume, decimal commission) : base(id, name, loggedHours, wage)

        {
            this.SalesVolume = salesVolume;
            this.Commission = commission;
        }

        protected override decimal Calculate()
        {
            return base.Calculate() + CalculateBonus();
        }
        private decimal CalculateBonus()
        {
            return SalesVolume * Commission;
        }
        public override string ToString()
        {
            return base.ToString() +
            $"\nCommission: ${Math.Round(Commission, 2): NO}" +
            $"\nBonus: ${Math.Round(CalculateBonus(), 2): NO}" +
            $"\nNet Salary: ${Math.Round(this.Calculate(), 2):N0}";
        }

    }

}
