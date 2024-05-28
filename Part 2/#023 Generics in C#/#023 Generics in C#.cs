using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Class1
    {
        static void Main(string[] args)
        {
            //var numbers = new Any<int>();
            //numbers.Add(1);
            //numbers.Add(2);
            //numbers.Add(3);
            //numbers.DisplayList();
            //numbers.RemoveAt(1);
            //numbers.DisplayList();
            //Console.WriteLine($"Length: {numbers.Count} items");
            //Console.WriteLine($"Empty: {numbers.IsEmpty}");
            //Console.ReadKey();

            var people = new Any<Person>();
            people.Add(new Person { Fname = "Ali", Lname = "N" });
            people.Add(new Person { Fname = "Reem", Lname = "S" });
            people.DisplayList();
            Console.WriteLine($"Length: {people.Count} items");
            Console.WriteLine($"Empty: {people.IsEmpty}");
            Console.ReadKey();

        }
    }

    public class Person
    {
        public string Fname { get; set; }
        public string Lname { get; set; }
        public override string ToString()
        {
            return $"'{Fname} {Lname}'";
        }
    }

    //public class Person
    //{
    //    public string Fname { get; set; }
    //    public string Lname { get; set; }
    //    public override string ToString()
    //    {
    //        return $"'{Fname} {Lname}'";
    //    }
    //}

    class Any<T>
    {
        private T[] _items;
        public void Add(T item)
        {
            if (_items is null)
            {
                _items = new T[] { item };
            }
            else
            {
                var length = _items.Length;
                var dest = new T[length + 1];
                for (int i = 0; i < length; i++)
                {
                    dest[i] = _items[i];
                }
                dest[dest.Length - 1] = item;
                _items = dest;
            }
        }
        public void RemoveAt(int position)
        {
            if (position < 0 || position > _items.Length - 1) return;
            var index = 0;
            var dest = new T[_items.Length];

            for (int i = 0; i < _items.Length; i++)
            {
                if (position == i)
                    continue;
                dest[index++] = _items[i];
            }
            _items = dest;
        }
        public bool IsEmpty => _items is null || _items.Length == 0;
        public int Count => _items is null ? 0 : _items.Length;
        public void DisplayList()
        {
            Console.Write("[");
            for (int i = 0; i < _items.Length; i++)
            {
                Console.Write(_items[i]);
                if (i < _items.Length - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine("]");
        }
    }
}
