using System;

namespace Animals.Library
{
    public class Dog
    {
        // field
        internal string Noise = "Woof!";

        // below are getters and setters
        public string getNoise()
        {
            return Noise + "!";
        }
        public void setNoise(String newValue)
        {
            if (newValue.Length == 0 || newValue == null)
            {
                throw new ArgumentException("");
            }
            Noise = newValue;
        }

        // instead of using getters and setters
        // c# have properties where other lang would use fields on their own

        // auto implmented property
        // field generated behind the scenes to back this property
        // usually properties have some backing field

        // this here is manual
        private string _name;
        public string Name 
        { 
            get
            {
                return _name;
            } 
            set 
            {
                // implicit argument value
                // could do null/empty/set
                _name = value;
            }
        }

        // can have properties without set
        public string Color { get; } = "brown";
        // shortcut type prop then tab

        // methods
        public void GoTo(string location)
        {
            // simple way
            // Console.WriteLine("Walking to " + location);
            // similar to JS
            Console.WriteLine($"Walking to {location}");
        }
        public void MakeNoise()
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