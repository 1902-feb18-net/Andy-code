using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes.Library
{
    public class Square : IShape
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public string Name { get; set; }

        public double CalculateArea()
        {
            //Console.WriteLine($"Area of Square is: {Width * Height}");
            return Width * Height;
        }
    }
}
