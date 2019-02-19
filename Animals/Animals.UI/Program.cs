using System;

namespace Animals.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var dog = new Dog();
            dog.GoTo("Door");
            dog.MakeNoise();
        }
    }
}
