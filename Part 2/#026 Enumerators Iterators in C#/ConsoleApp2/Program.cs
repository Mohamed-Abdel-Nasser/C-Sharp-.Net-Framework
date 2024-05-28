namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            var Temperatures = new List<Tempreture>();

            Random random = new Random();
            for (var i = 0; i < 100; i++)
            {
                Temperatures.Add(new Tempreture(random.Next(-30, 50)));
            }

            Temperatures.Sort();

            foreach (var Temperature in Temperatures)
            {
                Console.WriteLine(Temperature.Value);
            }
            Console.ReadKey();
        }
    }

    class Tempreture : IComparable
    {
        private int _value;

        public Tempreture(int value)
        {
            _value = value;
        }
        public int Value => _value;

        public int CompareTo(object obj)
        {
            if (obj is null)
                return 1;

            var temp = obj as Tempreture;
            if (temp is null)
                throw new ArgumentException("object is not a tempreture object");

            return this._value.CompareTo(temp._value);
        }
    }
}
