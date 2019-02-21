using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensionMethodsAndLink
{
    public static class ListExtension
    {
        // C# supports adding methods on to any class/struct
        // using static methods whose first parameter is declared with this
        // the class/struct which type
        public static bool Empty<T>(this List<T> list)
        {
            return list.Count == 0;
        }

        public static int Pow(this int a, int b)
        {
            if (b < 0)
            {
                // nameof takes whatever you put into it and becomes a string
                // more flexible when you want to rename variables
                throw new ArgumentException("exponent must be nonnegative", nameof(b));
            }
            if (b == 0) { return 1; }
            int result;
            for (result = a; b > 1; b--)
            {
                result *= a;
            }
            
            return result;
        }
    }
}
