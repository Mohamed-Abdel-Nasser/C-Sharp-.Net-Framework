namespace WorkforceManagementSystem
{
    internal class WorkforceManagementProgram
    {
        static void Main(string[] args)
        {
            // Create a Manager
            Manager manager = new Manager();
            Console.WriteLine("Manager Actions:");
            manager.Work();
            manager.ManageTasks();
            manager.Communicate();
            manager.Supervise();
            Console.WriteLine();

            // Create an Employee
            Employee employee = new Employee();
            Console.WriteLine("Employee Actions:");
            employee.Work();
            employee.ManageTasks();
            employee.Communicate();

            Console.ReadKey();

        }
    }


    // Manager class implementing IWorkable, ITaskManageable, ICommunicate, and ISupervise
    public class Manager : IWorkable, ITaskManageable, ICommunicate, ISupervise
    {
        public void Work()
        {
            Console.WriteLine("Manager is working.");
        }

        public void ManageTasks()
        {
            Console.WriteLine("Manager is managing tasks.");
        }

        public void Communicate()
        {
            Console.WriteLine("Manager is communicating with team members.");
        }

        public void Supervise()
        {
            Console.WriteLine("Manager is supervising the team.");
        }
    }

    // Employee class implementing IWorkable, ITaskManageable, and ICommunicate
    public class Employee : IWorkable, ITaskManageable, ICommunicate
    {
        public void Work()
        {
            Console.WriteLine("Employee is working.");
        }

        public void ManageTasks()
        {
            Console.WriteLine("Employee is managing tasks.");
        }

        public void Communicate()
        {
            Console.WriteLine("Employee is communicating with colleagues.");
        }
    }


    // Interface for employees that can communicate
    public interface ICommunicate
    {
        void Communicate();
    }

    // Interface for employees that can manage tasks
    public interface ITaskManageable
    {
        void ManageTasks();
    }
    // Interface for employees that can supervise
    public interface ISupervise
    {
        void Supervise();
    }

    // Interface for employees that can work
    public interface IWorkable
    {
        void Work();
    }
}
