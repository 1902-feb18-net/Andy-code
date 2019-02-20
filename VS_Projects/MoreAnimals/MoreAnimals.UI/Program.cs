using System;
// remember to add this after adding the reference
using MoreAnimals.Library;

namespace MoreAnimals.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // c# has property initializer syntax
            Dog fido1 = new Dog();
            fido1.Id = 1;
            fido1.Name = "Fido";
            fido1.Breed = "Husky";

            // property initializer syntax
            Dog fido2 = new Dog
            {
                Id = 1,
                Name = "Fido",
                Breed = "Husky"
            };

            fido1.GoTo("park");
            fido1.MakeNoise();

            // IAnimal is a parent type of Dog
            // Dog is a subtype of IAnimal
            IAnimal animal = fido1;
            // converting from dog var to IAnimal var is upcasting
            // upcasting is guaranteed to succeed, so it's implicit

            // converting the other was is downcasting, not guar to succeed
            // must be explicit with () casting
            //Bird bird = (Bird)animal;
            Dog dog3 = (Dog)animal;

            // not all casting is upcasting or downcasting e.g. int to double and back
            // double to int loses data, "unsafe", so must be explicit
            int integer = (int)3.4;

            //int to double cannot lose data, safe, can do with implicit cast
            double num = integer;

            var animals = new IAnimal[2];
            animals[0] = fido1;
            animals[1] = new Eagle()
            {
                Id = 3,
                Name = "Woody"
            };

            // animal class can implement as many interfaces as it likes, 
            // but a class may only have one direct parent class

            // this code doesnt care how the members are implemented
            // only that they can do the job specified by the interface
            foreach (IAnimal item in animals)
            {
                Console.WriteLine(item.Name);
                item.MakeNoise();
                item.GoTo("park");  // here we can't see Eagle.GoTo which only hides Bird.GoTo
                                    // without truly overriding it
                // once we use virtual/override, it does replace the method implementation
                //on the object itself
            }
            Eagle eagle1 = (Eagle)animals[1];
            eagle1.GoTo("park");

            MakeNoise(dog3); //upcasting here

            // use camelCase for local vars and private fields
            // TitleCase aka PascalCase for everything else
        }

        static void MakeNoise(IAnimal animal)
        {
            animal.MakeNoise();
        }
    }
}
