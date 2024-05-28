using System;
using System.Collections.Generic;

namespace TaskManagerApp
{
    // Task class representing a single task
    public class Task
    {
        public int Id { get; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }

        public Task(int id, string description)
        {
            Id = id;
            Description = description;
            IsCompleted = false;
        }
    }

    // TaskManager class to manage tasks
    public class TaskManager
    {
        private List<Task> tasks;
        private int nextTaskId;

        public TaskManager()
        {
            tasks = new List<Task>();
            nextTaskId = 1;
        }

        public void AddTask(string description)
        {
            Task newTask = new Task(nextTaskId, description);
            tasks.Add(newTask);
            nextTaskId++;
            Console.WriteLine("Task added successfully.");
        }

        public void ViewTasks()
        {
            Console.WriteLine("Tasks:");
            foreach (var task in tasks)
            {
                Console.WriteLine($"[{task.Id}] - {task.Description} {(task.IsCompleted ? "(Completed)" : "")}");
            }
        }

        public void MarkTaskAsCompleted(int taskId)
        {
            Task taskToComplete = tasks.Find(t => t.Id == taskId);
            if (taskToComplete != null)
            {
                taskToComplete.IsCompleted = true;
                Console.WriteLine($"Task [{taskId}] marked as completed.");
            }
            else
            {
                Console.WriteLine($"Task with ID [{taskId}] not found.");
            }
        }

        public void DeleteTask(int taskId)
        {
            Task taskToRemove = tasks.Find(t => t.Id == taskId);
            if (taskToRemove != null)
            {
                tasks.Remove(taskToRemove);
                Console.WriteLine($"Task [{taskId}] deleted successfully.");
            }
            else
            {
                Console.WriteLine($"Task with ID [{taskId}] not found.");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            TaskManager taskManager = new TaskManager();

            while (true)
            {
                Console.WriteLine("\nTask Manager Menu:");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. View Tasks");
                Console.WriteLine("3. Mark Task as Completed");
                Console.WriteLine("4. Delete Task");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input. Please enter a valid menu option.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter task description: ");
                        string description = Console.ReadLine();
                        taskManager.AddTask(description);
                        break;
                    case 2:
                        taskManager.ViewTasks();
                        break;
                    case 3:
                        Console.Write("Enter task ID to mark as completed: ");
                        if (int.TryParse(Console.ReadLine(), out int taskIdToComplete))
                        {
                            taskManager.MarkTaskAsCompleted(taskIdToComplete);
                        }
                        else
                        {
                            Console.WriteLine("Invalid task ID. Please enter a valid integer.");
                        }
                        break;
                    case 4:
                        Console.Write("Enter task ID to delete: ");
                        if (int.TryParse(Console.ReadLine(), out int taskIdToDelete))
                        {
                            taskManager.DeleteTask(taskIdToDelete);
                        }
                        else
                        {
                            Console.WriteLine("Invalid task ID. Please enter a valid integer.");
                        }
                        break;
                    case 5:
                        Console.WriteLine("Exiting Task Manager...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option from the menu.");
                        break;
                }
            }
        }
    }
}
