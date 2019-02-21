using System;
using System.Collections.Generic;
// YAY, LINQ is useful
using System.Linq;

namespace ExtensionMethodsAndLink
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int result = 3.Pow(3);

            var list = new List<string>();
            list.Empty();
            var str = list.ToString();
            // can add breakpoint here then mouse over during debugging 
            // to see value of the variables

            //extension methods don't allow us to truly modify the original type
            // only visible when we have a using directive
            // for the namespace where my static method is defined

            // extension methods don't let us see any private/protected members
            // we can't cheat the access modifiers

            // LINQ
            // Language integrated query 
            // LINQ is a bunch of extension methods on IEnumerable<T> and IQueryable<T>
            // all come from System.Ling namespace
            list.ToList();
            list.AddRange(new string[] { "a", "b", "c", "balahsndlask" });
            int sum = 0;
            foreach(var s in list)
            {
                sum += str.Length;
            }
            double averageStringLength = sum / list.Count;
            // with LINQ
            averageStringLength = list.Average(s => s.Length);
            Console.WriteLine(averageStringLength);

            // a "lambda" is kind of like a method that's anonymous
            // and can be treated like an ordinary value/object
            Func<string, int> numberOfAs = x => x.Count(c => c == 'a');
            var numOfAllAs = list.Sum(numberOfAs); // getting function from a func variable
            var numofAllBs = list.Sum(NumberOfBs); // getting function from method

            //functional programming is a paradigm like
            // OOP, like procedural programming

            // we treat functions/methods as if they were another piece of data

            // c# is not a purely functional language
            // but it does have plenty of support for programming in that style
            // especially with LINQ
            // c# does have some immutable classes in the library

            // LINQ has 2 syntaxes
            // "method syntax"
            // and query syntax (SQL wannabe)

            var allEmptyStrings = from x in list
                                  where x == ""
                                  select x.Count();
            // method syntax version
            var allEmptyStrings2 = list.Where(x => x == "");

            // LINQ methods we should know..
            // Any is a big  OR condition over all the elements
            bool anyStringsLongerThanFive = list.Any(s => s.Length > 5);
            // All is a big AND on a condition over all the elements
            bool allStringsLongerThanFive = list.All(s => s.Length > 5);

            // we have Contains(value)
            // we have Count(), Count(filterFunction)
            // DefaultIfEmpty()
            // OrderBy

            // Distinct // filter whole collection and strip out dupes
            // the second chars of all the unique strings that starts with 'a'
            var secondCharList = list.Distinct().Where(x => x[0] == 'a').Select(x => x[1]);
            // Select and Where are the most common
            // Select applies a mapping to the collection
            // Where filters a collection on some condition

            // Where make a new list that satisfies condition, old list remains the same
            IEnumerable<string> allWithLengthThree = list.Where(s => s.Length == 3);

            // deferred execution
            // all these LINQ method return IEnumerable, not whatever the original collection
            // type was. In such cases, the processing defined by
            // the method calls doesn't happen until to start
            // trying to pull values out of theat IEnumerable

            foreach(var item in secondCharList)
            {
                // here in this loop we are actually executing the logic
                Console.WriteLine(item);
            }

            // ToArray, ToHashset, ToList

            // when we dont want deferred execution, we want all the values right now,,,
            // we use .ToList()
            secondCharList.Last();
            secondCharList.Last();
            secondCharList.Last();
            secondCharList.Last();
            // we sometimes want to avoid running the operations repetitively

            // apart from being used for LINQ, the importance of IEnumerable is
            // that it allows iterating with foreach statement
        }
        static int NumberOfBs(string x)
        {
            var count = 0;
            for(int i = 0; i < x.Length; i++)
            {
                if(x[i] == 'b')
                {
                    count++;
                }
            }
            return count;
        }
    }
}
