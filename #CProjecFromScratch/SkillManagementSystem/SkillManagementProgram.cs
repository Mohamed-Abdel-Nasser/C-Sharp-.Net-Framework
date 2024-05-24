using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Xml;
using static System.Net.WebRequestMethods;

namespace SkillManagementSystem
{
    class SkillManagementProgram
    {
        static void Main(string[] args)
        {
            IDataStorage dataStorage = new XmlDataStorage("employees.xml");
            List<Employee> employees = dataStorage.LoadData();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Skills Management System");
                Console.WriteLine("========================");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Add Skill to Employee");
                Console.WriteLine("3. Update Skill Level");
                Console.WriteLine("4. Remove Skill from Employee");
                Console.WriteLine("5. View Employee Skills");
                Console.WriteLine("6. Save and Exit");
                Console.Write("Enter option: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1": // Add Employee
                        Console.Clear();
                        Console.Write("Enter employee name: ");
                        string empName = Console.ReadLine();
                        Employee newEmployee = new Employee(empName);
                        employees.Add(newEmployee);
                        Console.WriteLine($"Employee '{empName}' added.");
                        break;

                    case "2": // Add Skill to Employee
                        Console.Clear();
                        Console.Write("Enter employee name: ");
                        string empNameAdd = Console.ReadLine();
                        Employee empToAddSkill = employees.Find(e => e.Name.Equals(empNameAdd, StringComparison.OrdinalIgnoreCase));
                        if (empToAddSkill != null)
                        {
                            Console.Write("Enter skill name: ");
                            string skillNameAdd = Console.ReadLine();
                            Console.WriteLine("Select skill level:");
                            Console.WriteLine("1. Beginner");
                            Console.WriteLine("2. Intermediate");
                            Console.WriteLine("3. Advanced");
                            Console.WriteLine("4. Expert");
                            Console.Write("Enter skill level option: ");
                            if (Enum.TryParse(Console.ReadLine(), out SkillLevel level))
                            {
                                empToAddSkill.AddSkill(skillNameAdd, level);
                                Console.WriteLine($"Skill '{skillNameAdd}' added to {empToAddSkill.Name}.");
                            }
                            else
                            {
                                Console.WriteLine("Invalid skill level.");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Employee '{empNameAdd}' not found.");
                        }
                        break;

                    case "3": // Update Skill Level
                        Console.Clear();
                        Console.Write("Enter employee name: ");
                        string empNameUpdate = Console.ReadLine();
                        Employee empToUpdate = employees.Find(e => e.Name.Equals(empNameUpdate, StringComparison.OrdinalIgnoreCase));
                        if (empToUpdate != null)
                        {
                            Console.Write("Enter skill name: ");
                            string skillNameUpdate = Console.ReadLine();
                            Console.WriteLine("Select new skill level:");
                            Console.WriteLine("1. Beginner");
                            Console.WriteLine("2. Intermediate");
                            Console.WriteLine("3. Advanced");
                            Console.WriteLine("4. Expert");
                            Console.Write("Enter new skill level option: ");
                            if (Enum.TryParse(Console.ReadLine(), out SkillLevel newLevel))
                            {
                                empToUpdate.UpdateSkillLevel(skillNameUpdate, newLevel);
                                Console.WriteLine($"Skill '{skillNameUpdate}' updated for {empToUpdate.Name}.");
                            }
                            else
                            {
                                Console.WriteLine("Invalid skill level.");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Employee '{empNameUpdate}' not found.");
                        }
                        break;

                    case "4": // Remove Skill from Employee
                        Console.Clear();
                        Console.Write("Enter employee name: ");
                        string empNameRemove = Console.ReadLine();
                        Employee empToRemoveSkill = employees.Find(e => e.Name.Equals(empNameRemove, StringComparison.OrdinalIgnoreCase));
                        if (empToRemoveSkill != null)
                        {
                            Console.Write("Enter skill name: ");
                            string skillNameRemove = Console.ReadLine();
                            try
                            {
                                empToRemoveSkill.RemoveSkill(skillNameRemove);
                                Console.WriteLine($"Skill '{skillNameRemove}' removed from {empToRemoveSkill.Name}.");
                            }
                            catch (ArgumentException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Employee '{empNameRemove}' not found.");
                        }
                        break;

                    case "5": // View Employee Skills
                        Console.Clear();
                        Console.Write("Enter employee name: ");
                        string empNameView = Console.ReadLine();
                        Employee empToViewSkills = employees.Find(e => e.Name.Equals(empNameView, StringComparison.OrdinalIgnoreCase));
                        if (empToViewSkills != null)
                        {
                            Console.Clear();
                            empToViewSkills.DisplaySkills();
                        }
                        else
                        {
                            Console.WriteLine($"Employee '{empNameView}' not found.");
                        }
                        break;

                    case "6": // Save and Exit
                        dataStorage.SaveData(employees);
                        Console.WriteLine("Data saved. Exiting...");
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
    }

    public enum SkillLevel
    {
        Beginner,
        Intermediate,
        Advanced,
        Expert
    }

    public enum SkillType
    {
        IT,
        Languages,
        Marketing,
        ProgrammingLanguages,
        SoftSkills
    }

    public class Skill
    {
        public string Name { get; set; }
        public SkillLevel Level { get; set; }

        //Marketing
        public string Analytics { get; set; }
        public string CMS { get; set; }
        public string Communication { get; set; }
        public string Digitaladvertising { get; set; }
        public string EmailMarketing { get; set; }
        public string PublicSpeaking { get; set; }

        //Languages
        public string Arabic { get; set; }
        public string Bengali { get; set; }
        public string English { get; set; }
        public string Filipino { get; set; }
        public string French { get; set; }
        public string German { get; set; }


        //CloudComputing
        //Networking
        //Cybersecurity
        //DatabaseManagement
        //DevOps
        //System Administration(Linux, Windows)
        //Agile and Scrum methodologies

        public Skill(string name, SkillLevel level)
        {
            Name = name;
            Level = level;
        }

        public override string ToString()
        {
            return $"{Name} ({Level})";
        }
    }

    public class Employee
    {
        public string Name { get; set; }
        public List<Skill> Skills { get; set; }

        public Employee(string name)
        {
            Name = name;
            Skills = new List<Skill>();
        }

        public void AddSkill(string skillName, SkillLevel level)
        {
            Skills.Add(new Skill(skillName, level));
        }

        public void RemoveSkill(string skillName)
        {
            Skill skillToRemove = Skills.Find(s => s.Name.Equals(skillName, StringComparison.OrdinalIgnoreCase));
            if (skillToRemove != null)
            {
                Skills.Remove(skillToRemove);
            }
            else
            {
                throw new ArgumentException($"Skill '{skillName}' not found for {Name}");
            }
        }

        public void UpdateSkillLevel(string skillName, SkillLevel newLevel)
        {
            Skill skillToUpdate = Skills.Find(s => s.Name.Equals(skillName, StringComparison.OrdinalIgnoreCase));
            if (skillToUpdate != null)
            {
                skillToUpdate.Level = newLevel;
            }
            else
            {
                throw new ArgumentException($"Skill '{skillName}' not found for {Name}");
            }
        }

        public void DisplaySkills()
        {
            Console.WriteLine($"Skills of {Name}:");
            if (Skills.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("{0,-20} {1,-15}", "Skill", "Level");
                Console.ResetColor();
                foreach (var skill in Skills)
                {
                    Console.WriteLine("{0,-20} {1,-15}", skill.Name, skill.Level);
                }
            }
            else
            {
                Console.WriteLine("No skills found.");
            }
        }
    }

    public interface IDataStorage
    {
        void SaveData(List<Employee> employees);
        List<Employee> LoadData();
    }

    public class XmlDataStorage : IDataStorage
    {
        private string filePath;

        public XmlDataStorage(string filePath)
        {
            this.filePath = filePath;
        }

        public void SaveData(List<Employee> employees)
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlElement root = xmlDoc.CreateElement("Employees");
            foreach (var emp in employees)
            {
                XmlElement empNode = xmlDoc.CreateElement("Employee");
                XmlAttribute nameAttr = xmlDoc.CreateAttribute("Name");
                nameAttr.Value = emp.Name;
                empNode.Attributes.Append(nameAttr);
                foreach (var skill in emp.Skills)
                {
                    XmlElement skillNode = xmlDoc.CreateElement("Skill");
                    skillNode.SetAttribute("Name", skill.Name);
                    skillNode.SetAttribute("Level", skill.Level.ToString());
                    empNode.AppendChild(skillNode);
                }
                root.AppendChild(empNode);
            }
            xmlDoc.AppendChild(root);
            xmlDoc.Save(filePath);
        }

        public List<Employee> LoadData()
        {
            List<Employee> employees = new List<Employee>();
            if (File.Exists(filePath))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(filePath);
                XmlNodeList empNodes = xmlDoc.DocumentElement.SelectNodes("/Employees/Employee");
                foreach (XmlNode empNode in empNodes)
                {
                    string empName = empNode.Attributes["Name"].Value;
                    Employee emp = new Employee(empName);
                    foreach (XmlNode skillNode in empNode.ChildNodes)
                    {
                        string skillName = skillNode.Attributes["Name"].Value;
                        SkillLevel skillLevel = (SkillLevel)Enum.Parse(typeof(SkillLevel), skillNode.Attributes["Level"].Value);
                        emp.AddSkill(skillName, skillLevel);
                    }
                    employees.Add(emp);
                }
            }
            return employees;
        }
    }

}

