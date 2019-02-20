using System;
using System.Collections.Generic;
using System.Text;

namespace MoreAnimals.Library
{
    // abstract class
    public abstract class Bird : IAnimal
    {

        // "expression body" methods/props
        // in contrast to block body 
        public int Id { get; set; }
        public string Name { get; set; }

        // like in an interface we dont have to implement this one
        // it's abstract, the sub classes of this class will have to implement it
        public abstract void MakeNoise();

        public virtual void GoTo(string location)
        {
            Console.WriteLine($"Flying to {location.ToLower()}");
        }
    }
}
