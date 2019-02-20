using System;
using Shapes.Library;

namespace Shapes.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Square square1 = new Square()
            {
                Width = 4,
                Height = 4
            };

            Console.WriteLine(square1.CalculateArea());

        }
    }
}