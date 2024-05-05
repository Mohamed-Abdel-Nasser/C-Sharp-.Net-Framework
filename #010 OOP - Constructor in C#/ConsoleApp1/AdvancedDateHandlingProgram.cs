namespace AdvancedDateHandlingSystem
{
    class AdvancedDateHandlingProgram
    {
        static void Main(string[] args)
        {
            Date d1 = new Date(29, 02, 1999);
            Console.WriteLine(d1.GetDate());
            Console.ReadKey();
        }
    }
    internal class Employee
    {
        private string FName;
        private string LName;
        private int Id;
        public Employee()
        {

        }
        public Employee(int id, string fName, string lName)
        {
            this.Id = id;
            this.FName = fName;
            this.LName = lName;
        }
        public Employee create(int id, string fName, string lName)
        {
            return new Employee(id, fName, lName);
        }

    }

    internal class Date

    {
        private static readonly int[] _daysToMonth365 = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        private static readonly int[] _daysToMonth366 = { 0, 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        private readonly int _day;
        private readonly int _month;
        private readonly int _year;
        public Date(int day, int month, int year)
        {
            var isLeap = year % 4 == 0 && (year % 100 != 0 || year % 400 == 0);

            if (year >= 1 && year <= 9999 && month >= 1 && month <= 12)
            {
                int[] days = isLeap ? _daysToMonth366 : _daysToMonth365;
                if (day >= 1 && day <= days[month])
                {
                    _day = day;
                    _month = month;
                    _year = year;
                }
                else
                {
                    _day = 01;
                    _month = 01;
                    _year = 01;

                }

            }
            else
            {
                _day = 01;
                _month = 01;
                _year = 01;
            }

        }
        public Date(int year) : this(01, 01, year)
        {

        }
        public Date(int month, int year) : this(01, month, 01)
        {

        }

        //public void SetValue(int _day, int _month , int _year)
        //{
        //    this._day = _day;
        //    this._month = _month;
        //    this._year = _year;
        //}
        public string GetDate()
        {
            return $" {_day.ToString().PadLeft(2, '0')} / {_month.ToString().PadLeft(2, '0')} / {_year.ToString().PadLeft(4, '0')}";
        }
    }
}