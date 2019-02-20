using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes.Library
{
    public interface IShape
    {
        double Width { get; set; }
        double Height { get; set; }
        string Name { get; set; }

        double CalculateArea();
    }
}
