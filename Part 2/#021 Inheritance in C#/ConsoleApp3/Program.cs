using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Employee[] employees = {
            new Banker(2000, "Ahmed Khalil", 200, 20, "Wealth Management"),
            new Teller(2001, "Fatma Mahmoud", 180, 15, "Customer Service"),
            new LoanOfficer(2002, "Youssef Salah", 190, 18, "Mortgage Loans"),
            new BranchManager(2003, "Nadia Ibrahim", 180, 25, "Branch Operations"),
            new CustomerServiceRepresentative(2004, "Mona Ali", 160, 12, "Front Desk"),
            new FinancialAnalyst(2005, "Aya Ahmed", 175, 30, "Financial Analysis"),
            new PersonalRelationshipManager(2006, "Amr Samir", 185, 22, "Client Relationships"),
            new SoftwareDeveloper(2007, "Mohamed Hassan", 160, 35, "Software Development"),
            new SystemsAnalyst(2008, "Yasmine Adel", 170, 32, "Systems Analysis"),
            new NetworkSpecialist(2009, "Khaled Rami", 165, 28, "Network Administration"),
            new HRRecruiter(2010, "Nour Mahmoud", 175, 25, "Talent Acquisition"),
            new TrainingDevelopmentOfficer(2011, "Sara Hossam", 180, 20, "Employee Training"),
            new CreditRiskManagementOfficer(2012, "Ali Ibrahim", 185, 28, "Credit Risk Assessment")
        };

        Console.WriteLine("Bank Employee Details:\n");

        foreach (var employee in employees)
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine($"Employee ID: {employee.Id}");
            Console.WriteLine($"Employee Name: {employee.Name}");
            Console.WriteLine($"Logged Hours: {employee.LoggedHours} hrs");
            Console.WriteLine($"Hourly Wage: ${employee.Wage}");
            Console.WriteLine($"Job Title: {employee.JobTitle}");
            Console.WriteLine($"Departments: {string.Join(", ", employee.Departments)}");

            decimal baseSalary = employee.CalculateBaseSalary();
            decimal overtimePay = employee.CalculateOverTime();
            decimal netSalary = employee.Calculate();

            Console.WriteLine($"Base Salary: {FormatCurrency(baseSalary)}");
            Console.WriteLine($"Overtime Pay: {FormatCurrency(overtimePay)}");
            Console.WriteLine($"Net Salary: {FormatCurrency(netSalary)}");
        }

        Console.ReadKey();
    }

    static string FormatCurrency(decimal value)
    {
        return value.ToString("C2");
    }
}

public abstract class Employee
{
    public int Id { get; protected set; }
    public string Name { get; protected set; }
    public decimal LoggedHours { get; protected set; }
    public decimal Wage { get; protected set; }
    public List<string> Departments { get; protected set; } = new List<string>();
    public string JobTitle { get; protected set; }

    public Employee(int id, string name, decimal loggedHours, decimal wage, string jobTitle)
    {
        Id = id;
        Name = name;
        LoggedHours = loggedHours;
        Wage = wage;
        JobTitle = jobTitle;
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

    public void AddDepartment(string department)
    {
        Departments.Add(department);
    }

    public abstract string DisplayDetails();
}

public class Banker : Employee
{
    public string Specialty { get; protected set; }

    public Banker(int id, string name, decimal loggedHours, decimal wage, string specialty)
        : base(id, name, loggedHours, wage, "Banker")
    {
        Specialty = specialty;
        AddDepartment("Retail Banking");
    }

    public override string DisplayDetails()
    {
        return $"Specialty: {Specialty}";
    }
}

public class Teller : Employee
{
    public string Station { get; protected set; }

    public Teller(int id, string name, decimal loggedHours, decimal wage, string station)
        : base(id, name, loggedHours, wage, "Teller")
    {
        Station = station;
        AddDepartment("Retail Banking");
    }

    public override string DisplayDetails()
    {
        return $"Station: {Station}";
    }
}

public class LoanOfficer : Employee
{
    public string Focus { get; protected set; }

    public LoanOfficer(int id, string name, decimal loggedHours, decimal wage, string focus)
        : base(id, name, loggedHours, wage, "Loan Officer")
    {
        Focus = focus;
        AddDepartment("Retail Banking");
    }

    public override string DisplayDetails()
    {
        return $"Focus: {Focus}";
    }
}

public class BranchManager : Employee
{
    public string Role { get; protected set; }

    public BranchManager(int id, string name, decimal loggedHours, decimal wage, string role)
        : base(id, name, loggedHours, wage, "Branch Manager")
    {
        Role = role;
        AddDepartment("Retail Banking");
    }

    public override string DisplayDetails()
    {
        return $"Role: {Role}";
    }
}

public class CustomerServiceRepresentative : Employee
{
    public string Area { get; protected set; }

    public CustomerServiceRepresentative(int id, string name, decimal loggedHours, decimal wage, string area)
        : base(id, name, loggedHours, wage, "Customer Service Representative")
    {
        Area = area;
        AddDepartment("Retail Banking");
    }

    public override string DisplayDetails()
    {
        return $"Area: {Area}";
    }
}

public class FinancialAnalyst : Employee
{
    public string AnalysisType { get; protected set; }

    public FinancialAnalyst(int id, string name, decimal loggedHours, decimal wage, string analysisType)
        : base(id, name, loggedHours, wage, "Financial Analyst")
    {
        AnalysisType = analysisType;
        AddDepartment("Treasury");
    }

    public override string DisplayDetails()
    {
        return $"Analysis Type: {AnalysisType}";
    }
}

public class PersonalRelationshipManager : Employee
{
    public string FocusArea { get; protected set; }

    public PersonalRelationshipManager(int id, string name, decimal loggedHours, decimal wage, string focusArea)
        : base(id, name, loggedHours, wage, "Personal Relationship Manager")
    {
        FocusArea = focusArea;
        AddDepartment("Retail Banking");
    }

    public override string DisplayDetails()
    {
        return $"Focus Area: {FocusArea}";
    }
}

public class SoftwareDeveloper : Employee
{
    public string Technology { get; protected set; }

    public SoftwareDeveloper(int id, string name, decimal loggedHours, decimal wage, string technology)
        : base(id, name, loggedHours, wage, "Software Developer")
    {
        Technology = technology;
        AddDepartment("Information Technology");
    }

    public override string DisplayDetails()
    {
        return $"Technology: {Technology}";
    }
}

public class SystemsAnalyst : Employee
{
    public string AnalysisArea { get; protected set; }

    public SystemsAnalyst(int id, string name, decimal loggedHours, decimal wage, string analysisArea)
        : base(id, name, loggedHours, wage, "Systems Analyst")
    {
        AnalysisArea = analysisArea;
        AddDepartment("Information Technology");
    }

    public override string DisplayDetails()
    {
        return $"Analysis Area: {AnalysisArea}";
    }
}

public class NetworkSpecialist : Employee
{
    public string NetworkType { get; protected set; }

    public NetworkSpecialist(int id, string name, decimal loggedHours, decimal wage, string networkType)
        : base(id, name, loggedHours, wage, "Network Specialist")
    {
        NetworkType = networkType;
        AddDepartment("Information Technology");
    }

    public override string DisplayDetails()
    {
        return $"Network Type: {NetworkType}";
    }
}

public class HRRecruiter : Employee
{
    public string RecruitingType { get; protected set; }

    public HRRecruiter(int id, string name, decimal loggedHours, decimal wage, string recruitingType)
        : base(id, name, loggedHours, wage, "HR Recruiter")
    {
        RecruitingType = recruitingType;
        AddDepartment("Human Resources");
    }

    public override string DisplayDetails()
    {
        return $"Recruiting Type: {RecruitingType}";
    }
}

public class TrainingDevelopmentOfficer : Employee
{
    public string TrainingFocus { get; protected set; }

    public TrainingDevelopmentOfficer(int id, string name, decimal loggedHours, decimal wage, string trainingFocus)
        : base(id, name, loggedHours, wage, "Training & Development Officer")
    {
        TrainingFocus = trainingFocus;
        AddDepartment("Human Resources");
    }

    public override string DisplayDetails()
    {
        return $"Training Focus: {TrainingFocus}";
    }
}

public class CreditRiskManagementOfficer : Employee
{
    public string RiskAssessmentType { get; protected set; }

    public CreditRiskManagementOfficer(int id, string name, decimal loggedHours, decimal wage, string riskAssessmentType)
        : base(id, name, loggedHours, wage, "Credit Risk Management Officer")
    {
        RiskAssessmentType = riskAssessmentType;
        AddDepartment("Treasury");
    }

    public override string DisplayDetails()
    {
        return $"Risk Assessment Type: {RiskAssessmentType}";
    }
}
