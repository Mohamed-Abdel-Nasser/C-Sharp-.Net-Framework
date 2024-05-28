namespace ConsoleApp1
{
    internal class Program   //Reflection And Metadata in C#
    {
        static void Main(string[] args)
        {
            Type type1 = DateTime.Now.GetType(); // at runtime
            Type type2 = typeof(DateTime); // at compile time

            //Console.WriteLine(type1);
            //Console.WriteLine(type2);

            Console.WriteLine($"DateTime Class : <Name>      : {type1.Name}");
            Console.WriteLine($"DateTime Class : <FullName>  : {type1.FullName}");   
            Console.WriteLine($"DateTime Class : <Namespace> : {type1.Namespace}");  
            Console.WriteLine($"DateTime Class : <BaseType>  : {type1.BaseType}");

            Console.WriteLine("----------------------------------------");

            Console.WriteLine($"IsPublic : {type1.IsPublic}");
            Console.WriteLine($"Assembly : {type1.Assembly}");
            Type type3 = typeof(int[,]);

            Console.WriteLine("----------------------------------------");

            Console.WriteLine($"T3 Type: {type3.Name}");
            var nestedTypes = typeof(Employee).GetNestedTypes();

            for (int i = 0; i < nestedTypes.Length; i++)
            {
                Console.WriteLine(nestedTypes[i]);

            }

            Console.WriteLine("----------------------------------------");

            var type4 = typeof(int);
            var interfaces = type4.GetInterfaces();
            for (int i = 0; i < interfaces.Length; i++)
            {
                Console.WriteLine(interfaces[i]);
            }
            Console.ReadKey();



        }

    }

    class Employee
    {
        
    }
}
