using System;
using System.Net.Http;
namespace PaymentGatewaySystem
{
    class PaymentGatewayProgram
    {
        static void Main()
        {
            PaymentGatewayClient paymentClient = new PaymentGatewayClient();
            paymentClient.ProcessPayment(100.0m);

            // Let paymentClient go out of scope and be garbage collected
            paymentClient = null;

            // Force garbage collection to demonstrate finalization
            Console.WriteLine("Forcing garbage collection...");
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Console.ReadKey(); // Wait for user to see finalizer output
        }
    } 
    class PaymentGatewayClient : IDisposable
    {
        private HttpClient httpClient;

        public PaymentGatewayClient()
        {
            httpClient = new HttpClient();
            Console.WriteLine("Payment gateway client initialized.");
        }

        ~PaymentGatewayClient()
        {
            Dispose(false); // Finalizer called, cleanup unmanaged resources
        }


        public void ProcessPayment(decimal amount)
        {
            // Simulated payment processing logic
            Console.WriteLine($"Processing payment of {amount}...");
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
                // Clean up managed resources (e.g., close HTTP client)
                if (httpClient != null)
                {
                    httpClient.Dispose();
                    Console.WriteLine("HTTP client disposed.");
                }
            }
            // Clean up unmanaged resources (if any)
            Console.WriteLine("Payment gateway client cleaned up.");
        }

        
    }
}
