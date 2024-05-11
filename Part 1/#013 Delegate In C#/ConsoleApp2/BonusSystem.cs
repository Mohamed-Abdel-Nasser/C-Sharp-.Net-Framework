namespace EmployeeSystemSalaryCalculation
{
    public class BonusSystem
    {
        public static void Main()
        {
            Employee employee1 = new Employee("John", 50000, 4);
            Employee employee2 = new Employee("Alice", 60000, 5);

            // Define a delegate instance that represents a bonus calculation rule
            BonusCalculatorDelegate calculateBonus = (salary, rating) =>
            {
                // Simple bonus calculation based on performance rating
                return rating switch
                {
                    4 => salary * 0.05,   // 5% bonus for rating 4
                    5 => salary * 0.08,   // 8% bonus for rating 5
                    _ => 0               // No bonus for other ratings
                };
            };

            // Calculate bonuses for employees using the defined delegate
            double bonusForJohn = employee1.CalculateBonus(calculateBonus);
            double bonusForAlice = employee2.CalculateBonus(calculateBonus);

            Console.WriteLine($"Bonus for {employee1.Name}: ${bonusForJohn}");
            Console.WriteLine($"Bonus for {employee2.Name}: ${bonusForAlice}");
        }
    }

    // Delegate for calculating bonus
    public delegate double BonusCalculatorDelegate(double salary, int performanceRating);
    public class Employee
    {
        public string Name { get; set; }
        public double BaseSalary { get; set; }
        public int PerformanceRating { get; set; }

        public Employee(string name, double baseSalary, int performanceRating)
        {
            Name = name;
            BaseSalary = baseSalary;
            PerformanceRating = performanceRating;
        }

        public double CalculateBonus(BonusCalculatorDelegate bonusCalculator)
        {
            return bonusCalculator(BaseSalary, PerformanceRating);
        }
    }
}
