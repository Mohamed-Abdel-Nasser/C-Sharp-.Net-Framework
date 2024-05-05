namespace EventSubscriberDemo
{
    public class EventSubscriberProgram
    {
        public static void Main()
        {
            var eventManager = new EventManager();

            // Subscribe to the events
            eventManager.OnEvent1 += HandleEvent1;
            eventManager.OnEvent2 += HandleEvent2;

            // Trigger events
            eventManager.TriggerEvent1();
            eventManager.TriggerEvent2();

            // Unsubscribe from an event
            eventManager.OnEvent2 -= HandleEvent2;

            // Trigger event 2 again after unsubscribe
            eventManager.TriggerEvent2();
            Console.ReadKey();
        }

        public static void HandleEvent1(string message)
        {
            Console.WriteLine("Handling Event 1: " + message);
        }

        public static void HandleEvent2(int value)
        {
            Console.WriteLine("Handling Event 2: " + value);
        }
    }


    public class EventManager
    {
        // Define delegate types for events
        public delegate void Event1Handler(string message);
        public delegate void Event2Handler(int value);

        // Define events based on delegates
        public event Event1Handler OnEvent1;
        public event Event2Handler OnEvent2;

        // Method to trigger Event 1
        public void TriggerEvent1()
        {
            OnEvent1?.Invoke("Event 1 was triggered");
        }

        // Method to trigger Event 2
        public void TriggerEvent2()
        {
            OnEvent2?.Invoke(42);
        }
    }
}
