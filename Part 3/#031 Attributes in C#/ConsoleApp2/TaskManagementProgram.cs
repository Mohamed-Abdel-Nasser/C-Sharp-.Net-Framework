using System;
using System.Collections.Generic;
using System.Threading;

namespace TaskManagementSystem
{

    // Main program to demonstrate task management with enhanced display
    class TaskManagementProgram
    {
        static void Main()
        {
            // Create some tasks with different statuses
            var tasks = new List<TaskItem>
            {
                new TaskItem(1, "Implement feature A", TaskStatus.OPEN),
                new TaskItem(2, "Refactor module B", TaskStatus.INPROGRESS),
                new TaskItem(3, "Test module C", TaskStatus.COMPLETED),
                new TaskItem(4, "Review documentation", TaskStatus.CLOSED)
            };

            DisplayTasks(tasks);
        }

        static void DisplayTasks(List<TaskItem> tasks)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Tasks in the system:");
            Console.WriteLine("=======================================");

            foreach (var task in tasks)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Task ID: {task.TaskId}");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Description: {task.Description}");

                // Display status with color coding
                Console.ForegroundColor = GetStatusColor(task.Status);
                Console.WriteLine($"Status: {task.Status}");

                // Display action based on status
                Console.ForegroundColor = ConsoleColor.Gray;
                switch (task.Status)
                {
                    case TaskStatus.OPEN:
                        SimulateOperationWithDelay("Assigning task to a team member...", 1500);
                        break;
                    case TaskStatus.INPROGRESS:
                        SimulateOperationWithDelay("Checking status updates...", 1500);
                        break;
                    case TaskStatus.COMPLETED:
                        SimulateOperationWithDelay("Reviewing and closing task...", 1500);
                        break;
                    case TaskStatus.CLOSED:
                        SimulateOperationWithDelay("Archiving task for reference...", 1500);
                        break;
                    default:
                        Console.WriteLine("Action: Unknown action.");
                        break;
                }

                Console.WriteLine("---------------------------------------");
            }

            Console.ResetColor();
        }

        // Helper method to simulate operation with delay using Thread.Sleep
        static void SimulateOperationWithDelay(string action, int delayMilliseconds)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(action);
            Thread.Sleep(delayMilliseconds); // Simulate delay using Thread.Sleep
        }

        // Helper method to get color based on task status
        static ConsoleColor GetStatusColor(TaskStatus status)
        {
            switch (status)
            {
                case TaskStatus.OPEN:
                    return ConsoleColor.Green;
                case TaskStatus.INPROGRESS:
                    return ConsoleColor.Blue;
                case TaskStatus.COMPLETED:
                    return ConsoleColor.Magenta;
                case TaskStatus.CLOSED:
                    return ConsoleColor.Red;
                default:
                    return ConsoleColor.Gray;
            }
        }
    }
    // Define a Task class representing a task in a task management system
    public class TaskItem
    {
        public int TaskId { get; }
        public string Description { get; }
        public TaskStatus Status { get; set; }

        public TaskItem(int id, string description, TaskStatus status)
        {
            TaskId = id;
            Description = description;
            Status = status;
        }
    }

    // Define an enum for task statuses
    public enum TaskStatus
    {
        OPEN,
        INPROGRESS,
        COMPLETED,
        [Obsolete("This status is deprecated. Use 'Archived' instead.")]
        CLOSED
    }

}
