namespace ConsoleApp4
{
    class Program
    {
        static void Main()
        {
            MyDate date1 = new MyDate(10, 4, 2022);
            MyDate date2 = new MyDate(15, 4, 2022);

            // Adding days to a custom date using operator overloading
            MyDate futureDate = date1 + 7;
            Console.WriteLine($"Future Date: {futureDate}");

            // Subtracting dates to get difference in days
            int daysDifference = date2 - date1;
            Console.WriteLine($"Days Difference: {daysDifference}");

            // Comparing dates using overloaded operators
            Console.WriteLine($"Are date1 and date2 equal? {date1 == date2}");
            Console.WriteLine($"Are date1 and futureDate equal? {date1 == futureDate}");
        }
    }
    public class MyDate
    {
        public int Day { get; }
        public int Month { get; }
        public int Year { get; }

        public MyDate(int day, int month, int year)
        {
            Day = day;
            Month = month;
            Year = year;
        }

        // Overload addition operator (+) for custom date increment
        public static MyDate operator +(MyDate date, int daysToAdd)
        {
            DateTime dt = new DateTime(date.Year, date.Month, date.Day).AddDays(daysToAdd);
            return new MyDate(dt.Day, dt.Month, dt.Year);
        }

        // Overload subtraction operator (-) to calculate difference in days
        public static int operator -(MyDate date1, MyDate date2)
        {
            DateTime dt1 = new DateTime(date1.Year, date1.Month, date1.Day);
            DateTime dt2 = new DateTime(date2.Year, date2.Month, date2.Day);
            TimeSpan difference = dt1 - dt2;
            return difference.Days;
        }

        // Overload equality operator (==) to compare dates
        public static bool operator ==(MyDate date1, MyDate date2)
        {
            return date1.Day == date2.Day && date1.Month == date2.Month && date1.Year == date2.Year;
        }

        // Overload inequality operator (!=) to compare dates
        public static bool operator !=(MyDate date1, MyDate date2)
        {
            return !(date1 == date2);
        }

        // Override ToString method to display date in a readable format
        public override string ToString()
        {
            return $"{Day}-{Month}-{Year}";
        }

        // Override Equals method to compare dates
        public override bool Equals(object obj)
        {
            if (!(obj is MyDate))
                return false;

            MyDate otherDate = (MyDate)obj;
            return this == otherDate;
        }

        // Override GetHashCode method
        public override int GetHashCode()
        {
            return HashCode.Combine(Day, Month, Year);
        }
    }

   

}
