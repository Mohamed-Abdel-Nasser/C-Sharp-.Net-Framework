using System;

namespace CAXMLDocumentation
{
    class Program
    {
        static void Main(string[] args)
        { 
            do
            {
                Console.Write("First Name: ");
                var fname = Console.ReadLine();

                Console.Write(" Last Name: ");
                var lname = Console.ReadLine();

                Console.Write(" Hire Date: ");
                DateTime? hireDate = null;
                if(DateTime.TryParse(Console.ReadLine(), out DateTime hDate))
                {
                    hireDate = hDate;
                }
                var empId = Generator.GenerateId(fname, lname, hireDate);
                var randomPassword = Generator.GenerateRandomPassword(8);

                Console.WriteLine($"{{\n Id: {empId},\n FName: {fname},\n LName: {lname},\n hire date: {hireDate.Value.ToShortDateString()}, \n Password: {randomPassword}\n}}");

            } while (1 == 1);
             
        }
    }
}
