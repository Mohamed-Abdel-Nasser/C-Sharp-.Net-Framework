using System;
using System.IO;
namespace ProductManagementSystem
{
    class ProductManagementProgram
    {
        static void Main()
        {
            string productFilePath = "product.txt";
            ProductFileManager productFileManager = new ProductFileManager(productFilePath);
            productFileManager.WriteProductInfo("Product details...");

            // Let productFileManager go out of scope and be garbage collected
            productFileManager = null;

            // Force garbage collection to demonstrate finalization
            Console.WriteLine("Forcing garbage collection...");
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Console.ReadKey(); // Wait for user to see finalizer output
        }
    }
    class ProductFileManager : IDisposable
    {
        private FileStream fileStream;

        public ProductFileManager(string filePath)
        {
            fileStream = File.Open(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            Console.WriteLine("File stream opened for product file.");
        }

        ~ProductFileManager()
        {
            Dispose(false); // Finalizer called, cleanup unmanaged resources
        }

        public void WriteProductInfo(string info)
        {
            // Simulated writing product information to file
            using (var writer = new StreamWriter(fileStream))
            {
                writer.WriteLine(info);
                Console.WriteLine("Product information written to file.");
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Clean up managed resources (e.g., close file stream)
                if (fileStream != null)
                {
                    fileStream.Close();
                    Console.WriteLine("File stream closed.");
                }
            }
            // Clean up unmanaged resources (if any)
            Console.WriteLine("Product file manager cleaned up.");
        }

      
    }
}

