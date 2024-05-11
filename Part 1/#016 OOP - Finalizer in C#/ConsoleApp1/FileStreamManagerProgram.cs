using System;
using System.IO;
using System.Text;
namespace FileStreamManagerSystem
{
   class FileStreamManagerProgram
    {
        static void Main()
        {
            string filePath = "example.txt";

            // Using FileStreamManager in a using block
            using (var fileManager = new FileStreamManager(filePath))
            {
                fileManager.WriteToFile("Hello, world!");
                Console.WriteLine("Text written to file.");
            }

            // Simulating forgetting to call Dispose() explicitly
            FileStreamManager fileManager2 = new FileStreamManager(filePath);
            fileManager2.WriteToFile("This is another line.");
            Console.WriteLine("Text written to file again.");

            // Let's not dispose fileManager2 and allow finalization to happen
            fileManager2 = null;
            GC.Collect(); // Force garbage collection to trigger finalizer

            Console.ReadKey(); // Wait for user to see finalizer output
        }
    }

    class FileStreamManager : IDisposable
    {
        private readonly FileStream fileStream;
        private readonly Encoding encoding = Encoding.UTF8;
        private bool disposed = false;

        public FileStreamManager(string filePath)
        {
            fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        }

        ~FileStreamManager()
        {
            Dispose(false); // Finalizer called, cleanup unmanaged resources
        }

        public void WriteToFile(string text)
        {
            byte[] bytes = encoding.GetBytes(text);
            fileStream.Write(bytes, 0, bytes.Length);
        }

        public string ReadFromFile()
        {
            byte[] buffer = new byte[fileStream.Length];
            fileStream.Seek(0, SeekOrigin.Begin);
            fileStream.Read(buffer, 0, buffer.Length);
            return encoding.GetString(buffer);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Cleanup managed resources
                    fileStream.Close();
                    Console.WriteLine("File stream closed.");
                }

                // Cleanup unmanaged resources
                disposed = true;
            }
        }
    }
}
