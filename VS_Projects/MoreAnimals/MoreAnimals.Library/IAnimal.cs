using System;
using System.Collections.Generic;
using System.Text;

namespace MoreAnimals.Library
{
    public interface IAnimal
    {
        // in an interface, the member must have same access levels as the whole
        // interface so we do not say explicitly

        // dont have fields in interfaces, but has properties
        int Id { get; set; }
        string Name { get; set; }
        void MakeNoise();
        void GoTo(string location);
    }
}
