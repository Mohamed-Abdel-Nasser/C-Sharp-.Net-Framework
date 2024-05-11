using System;
namespace ConsoleApp4
{
    class Program
    {
        static void Main()
        {
            using (var obj = new ResourceIntensiveObject())
            {
                // Use the resource-intensive object
                Console.WriteLine("Object created and used.");
            }

            // At the end of the 'using' block, Dispose is automatically called,
            // which releases resources deterministically.

            // Force garbage collection to demonstrate finalization (not recommended)
            Console.WriteLine("Forcing garbage collection...");
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Console.WriteLine("End of program.");
        }
    }

    class ResourceIntensiveObject : IDisposable
    {
        private IntPtr resource; // Simulated resource handle

        public ResourceIntensiveObject()
        {
            // Simulate resource allocation
            this.resource = AcquireResource();
        }

        // Destructor (finalizer) - called during garbage collection
        ~ResourceIntensiveObject()
        {
            // Finalizer should release unmanaged resources
            ReleaseResource(this.resource);
        }

        // Implement IDisposable pattern for deterministic resource cleanup
        public void Dispose()
        {
            // Explicitly release resources
            ReleaseResource(this.resource);

            // Suppress finalization to prevent finalizer from running
            GC.SuppressFinalize(this);
        }

        // Simulated resource acquisition method
        private IntPtr AcquireResource()
        {
            Console.WriteLine("Resource acquired.");
            return new IntPtr(123); // Simulated resource handle
        }

        // Simulated resource release method
        private void ReleaseResource(IntPtr res)
        {
            Console.WriteLine("Resource released.");
            // Simulated resource release logic
        }
    }
}
