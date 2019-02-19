using System;

namespace Animals.UI
{
    internal class Dog
    {
        // field
        internal string Noise = "Woof!";
        // methods
        internal void GoTo(string location)
        {
            // simple way
            // Console.WriteLine("Walking to " + location);
            // similar to JS
            Console.WriteLine($"Walking to {location}");
        }
        internal void MakeNoise()
        {
            Console.WriteLine(Noise);
        }

        // access modifiers
        // C# class/interface/etc has some access modifier
        // and every one of them has some access modifier

        //public: everyone can access this member
        // (nothing): same as private
        // private: only by current class can access this member
        // internal: anything in the same assembly(project) can access.
        // ... but nothing from outside the assembly

        // no such thing as a private class
        // on classes interfaces, etc, we have public and internal
        // default is internal

    }
}