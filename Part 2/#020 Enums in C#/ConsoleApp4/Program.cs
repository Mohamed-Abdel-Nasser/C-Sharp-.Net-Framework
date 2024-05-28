using System;

public enum EmploymentStatus
{
    [AssociatedData("Full-Time", "Standard full-time employment")]
    FullTime,

    [AssociatedData("Part-Time", "Flexible part-time employment")]
    PartTime,

    [AssociatedData("Contractor", "Independent contractor for specific projects")]
    Contractor,

    [AssociatedData("Intern", "Internship position for learning and training")]
    Intern
}

public class AssociatedDataAttribute : Attribute
{
    public string Name { get; }
    public string Description { get; }

    public AssociatedDataAttribute(string name, string description)
    {
        Name = name;
        Description = description;
    }
}

public static class EnumExtensions
{
    public static string GetDisplayName(this Enum value)
    {
        var fieldInfo = value.GetType().GetField(value.ToString());
        var attribute = fieldInfo.GetCustomAttributes(typeof(AssociatedDataAttribute), false)
                                  .SingleOrDefault() as AssociatedDataAttribute;
        return attribute != null ? attribute.Name : value.ToString();
    }

    public static string GetDescription(this Enum value)
    {
        var fieldInfo = value.GetType().GetField(value.ToString());
        var attribute = fieldInfo.GetCustomAttributes(typeof(AssociatedDataAttribute), false)
                                  .SingleOrDefault() as AssociatedDataAttribute;
        return attribute != null ? attribute.Description : string.Empty;
    }
}

public class Program
{
    public static void Main()
    {
        EmploymentStatus empStatus = EmploymentStatus.FullTime;
        Console.WriteLine($"Employment Status: {empStatus.GetDisplayName()}");
        Console.WriteLine($"Description: {empStatus.GetDescription()}");
    }
}
