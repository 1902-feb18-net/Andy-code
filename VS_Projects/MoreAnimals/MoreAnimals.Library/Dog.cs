using System;
using System.Collections.Generic;
using System.Text;

namespace MoreAnimals.Library
{
    //by default is internal
    // Dog implements IAnimal interface
    // means every member is guaranteed to be present in this class
    public class Dog : IAnimal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }

        public void MakeNoise()
        {
            Console.WriteLine("Woof!");
        }

        public void GoTo(string location)
        {
            Console.WriteLine($"Walking to {location}");
        }
    }
}
