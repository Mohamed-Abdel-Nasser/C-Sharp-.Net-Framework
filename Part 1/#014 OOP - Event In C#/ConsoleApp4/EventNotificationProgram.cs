namespace EventNotificationSystem
{
    // Define a delegate type for handling events
    public delegate void NotificationHandler(string message);
    internal class EventNotificationProgram
    {
        static void Main(string[] args)
        {
            // Create an instance of the event publisher
            var publisher = new EventPublisher();

            // Create multiple subscribers
            var subscriber1 = new EventSubscriber("Subscriber 1");
            var subscriber2 = new EventSubscriber("Subscriber 2");
            var subscriber3 = new EventSubscriber("Subscriber 3");

            // Subscribe the subscribers to the event
            publisher.NotificationEvent += subscriber1.HandleNotification;
            publisher.NotificationEvent += subscriber2.HandleNotification;
            publisher.NotificationEvent += subscriber3.HandleNotification;

            // Trigger the event
            publisher.DoSomething();

            // Unsubscribe one of the subscribers
            publisher.NotificationEvent -= subscriber2.HandleNotification;

            // Trigger the event again
            publisher.DoSomething();

            Console.ReadKey();
        }
    }

    // Event subscriber class
    public class EventSubscriber
    {
        private readonly string _name;

        public EventSubscriber(string name)
        {
            _name = name;
        }

        // Event handler method
        public void HandleNotification(string message)
        {
            Console.WriteLine($"{_name} received a notification: {message}");
        }
    }

    // Event publisher class
    public class EventPublisher
    {
        // Define an event of type NotificationHandler
        public event NotificationHandler NotificationEvent;

        // Method to simulate triggering an event
        public void DoSomething()
        {
            // Raise the event if there are subscribers
            NotificationEvent?.Invoke("Event is triggered!");
        }
    }
}
