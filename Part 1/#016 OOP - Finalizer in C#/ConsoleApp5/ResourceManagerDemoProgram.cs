using System;
namespace ResourceManagerDemoSystem
{
    class ResourceManagerDemoProgram
    {
        static void Main()
        {
            // Create and use the custom resource
            CustomResource resource = new CustomResource();
            Console.WriteLine("Resource created and used.");

            // Demonstrate automatic cleanup using using statement
            using (var anotherResource = new CustomResource())

            {
                Console.WriteLine("Another resource created and used.");
            }

            // At the end of the 'using' block, Dispose is automatically called,
            // which releases resources deterministically.

            // Let's nullify the reference to the resource
            resource = null;

            // Force garbage collection to demonstrate finalization (not recommended)
            Console.WriteLine("Forcing garbage collection...");
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Console.WriteLine("End of program.");
        }
    }

    class CustomResource : IDisposable
    {
        private IntPtr resource; // Simulated resource handle

        public CustomResource()
        {
            // Simulate resource allocation
            this.resource = AcquireResource();
        }

        // Destructor (finalizer) - called during garbage collection
        ~CustomResource()
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
