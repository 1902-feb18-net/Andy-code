using System;
using System.Collections.Generic;
using System.Text;

namespace MoreAnimals.Library
{
    // c# we extend classes and implment interfaces with :
    public class Eagle : Bird
    {
        // in c# overriding inherited members is not allowed
        // only adding new members
        public override void MakeNoise()
        {
            Console.WriteLine("caww");
        } 

        //public void GoTo(string location)
        //{
        //    Console.WriteLine($"I'm an eagle flying to {location}");
        //}

        // override is the counterpart to virtual
        // override goes on the child class
        public override void GoTo(string location)
        {
            Console.WriteLine($"I'm an eagle flying to {location}");
        }
    }
}
