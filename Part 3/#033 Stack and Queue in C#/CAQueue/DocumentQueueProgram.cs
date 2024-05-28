using System;
using System.Collections.Generic;

namespace DocumentQueueManager
{
    class DocumentQueueProgram
    {
        static void Main(string[] args)
        {
            PriorityQueue<PrintingJob> printingJobs = new PriorityQueue<PrintingJob>();
            Random rnd = new Random();

            // Simulate adding printing jobs with priorities
            AddSampleJobs(printingJobs);

            Console.WriteLine($"Number of Jobs in Queue: {printingJobs.Count}");

            while (printingJobs.Count > 0)
            {
                var job = printingJobs.Dequeue();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Processing: {job}");

                // Simulate printing process
                SimulatePrinting(job, rnd);

                // Optionally handle job failure
                HandleJobCompletion(job, rnd);
            }

            Console.WriteLine($"All jobs processed. Remaining in Queue: {printingJobs.Count}");
            Console.ReadKey();
        }

        static void AddSampleJobs(PriorityQueue<PrintingJob> queue)
        {
            queue.Enqueue(new PrintingJob("document.pdf", 2));     // Low priority
            queue.Enqueue(new PrintingJob("presentation.pptx", 6)); // High priority
            queue.Enqueue(new PrintingJob("spreadsheet.xlsx", 6));  // High priority
            queue.Enqueue(new PrintingJob("invoice.doc", 5));       // Medium priority
            queue.Enqueue(new PrintingJob("email.pdf", 4));         // Medium priority
            queue.Enqueue(new PrintingJob("code.cs", 1));           // Low priority
        }

        static void SimulatePrinting(PrintingJob job, Random rnd)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"Printing started: {job}");

            int processingTimeInSeconds = rnd.Next(3, 8);
            System.Threading.Thread.Sleep(processingTimeInSeconds * 1000);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Printing completed: {job}");

        }


        static void HandleJobCompletion(PrintingJob job, Random rnd)
        {
            // Simulate occasional job failure (1 in 5 chance)
            if (rnd.Next(1, 6) == 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Printing failed: {job}");
                // Implement retry, notify user, or log failure here
                Console.WriteLine("-----------------------------------------------------");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Printing successful: {job}");
                // Implement success handling (e.g., notify user, log success)
                Console.WriteLine("-----------------------------------------------------");

            }
        }
    }

    // Represents a printing job with file name and priority
    class PrintingJob
    {
        public string FileName { get; }
        public int Priority { get; }

        public PrintingJob(string fileName, int priority)
        {
            FileName = fileName;
            Priority = priority;
        }

        public override string ToString()
        {
            return $"{FileName} (Priority: {Priority})";
        }
    }

    // Priority queue implementation based on priority levels
    class PriorityQueue<T>
    {
        private readonly Queue<T> _lowPriority = new Queue<T>();
        private readonly Queue<T> _mediumPriority = new Queue<T>();
        private readonly Queue<T> _highPriority = new Queue<T>();

        public int Count => _lowPriority.Count + _mediumPriority.Count + _highPriority.Count;

        public void Enqueue(T item, int priority = 0)
        {
            switch (priority)
            {
                case 0:
                    _lowPriority.Enqueue(item);
                    break;
                case 1:
                    _mediumPriority.Enqueue(item);
                    break;
                case 2:
                    _highPriority.Enqueue(item);
                    break;
                default:
                    _lowPriority.Enqueue(item);
                    break;
            }
        }

        public T Dequeue()
        {
            if (_highPriority.Count > 0)
                return _highPriority.Dequeue();
            else if (_mediumPriority.Count > 0)
                return _mediumPriority.Dequeue();
            else if (_lowPriority.Count > 0)
                return _lowPriority.Dequeue();
            else
                throw new InvalidOperationException("Queue is empty.");
        }
    }
}
