namespace ResponsibilitiesManagementSystem
{
    internal class ResponsibilitiesManagementProgram
    {
        static void Main(string[] args)
        {
            // Create a Teacher
            Teacher myTeacher = new Teacher();
            Console.WriteLine("Teacher's Responsibilities:");
            myTeacher.Teach();
            myTeacher.Communicate();
            Console.WriteLine();

            // Create an Administrator
            Administrator myAdministrator = new Administrator();
            Console.WriteLine("Administrator's Responsibilities:");
            myAdministrator.Administrate();
            myAdministrator.Communicate();
        }
    }

    public interface IAdministrate
    {
        void Administrate();
    }

    public interface ICommunicate
    {
        void Communicate();
    }
    public interface ITeachable
    {
        void Teach();
    }

    // Teacher class implementing ITeachable and ICommunicate
    public class Teacher : ITeachable, ICommunicate
    {
        public void Teach()
        {
            Console.WriteLine("Teacher is teaching.");
        }

        public void Communicate()
        {
            Console.WriteLine("Teacher is communicating with students and parents.");
        }
    }

    // Administrator class implementing IAdministrate and ICommunicate
    public class Administrator : IAdministrate, ICommunicate
    {
        public void Administrate()
        {
            Console.WriteLine("Administrator is handling administrative tasks.");
        }

        public void Communicate()
        {
            Console.WriteLine("Administrator is communicating with staff and parents.");
        }
    }
}
