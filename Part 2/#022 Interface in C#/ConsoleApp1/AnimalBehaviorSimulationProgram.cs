namespace AnimalBehaviorSimulationSystem
{
    internal class AnimalBehaviorSimulationProgram
    {
        static void Main(string[] args)
        {
            // Create a Bird
            Console.WriteLine("Bird Actions:");
            Bird myBird = new Bird();
            myBird.Fly();
            myBird.MakeSound();


            Console.WriteLine("****************");

            // Create a Fish
            Console.WriteLine("Fish Actions:");
            Fish myFish = new Fish();
            myFish.Swim();
            myFish.MakeSound();

            Console.ReadKey();
        }
    }

    // Fish class implementing ISwimmable and ISoundProducible
    public class Fish : ISwimmable, ISoundProducible
    {
        public void Swim()
        {
            Console.WriteLine("The fish is swimming.");
        }

        public void MakeSound()
        {
            Console.WriteLine("The fish is bubbling.");
        }
    }

    // Bird class implementing IFlyable and ISoundProducible
    public class Bird : IFlyable, ISoundProducible
    {
        public void Fly()
        {
            Console.WriteLine("The bird is flying.");
        }

        public void MakeSound()
        {
            Console.WriteLine("The bird is chirping.");
        }
    }


    // Interface for objects that can swim
    public interface ISwimmable
    {
        void Swim();
    }

    // Interface for objects that can make a sound
    public interface ISoundProducible
    {
        void MakeSound();
    }

    // Interface for objects that can fly
    public interface IFlyable
    {
        void Fly();
    }
}
