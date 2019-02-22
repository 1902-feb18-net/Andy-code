using NLog;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RefAndOut
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello ME!");

            Console.WriteLine("Enter number: ");

            // gets a string from user
            var input = Console.ReadLine();

            //int number;
            //try
            //{
            //    // Parse convert int to string representation
            //    number = int.Parse(input);
            //}
            //catch(FormatException)
            //{
            //    Console.WriteLine("invalid input");
            //}


            // out params are declared outside the method call,
            // then the method fills in that value
            // (normally not possible for a method to directly change a var outside it)

            // this enables methods to effectively return several things at once
            // bit nicer than try catch, don't have to deal with exceptions
            int number; 
            if (int.TryParse(input, out number))
            {
                Console.WriteLine($"num entered: {number}");
            }
            else
            {
                Console.WriteLine("invalid input");
            }

            // we can also just declare the out param in the call
            int.TryParse(input, out var num);

            var dict = new Dictionary<string, int>();
            if (dict.TryGetValue("bob", out var value))
            {
                //work with value
            }

            // we also have "ref" params
            // if you used pointers before... out is a little bit like passing a pointer
            // ref is even closer to passing a pointer

            int x = 40;
            ChangeMyIntDoesntWork(x);
            Console.WriteLine(x); // gives out 40
            ChangeMyInt(ref x);
            Console.WriteLine(x); //gives out 10

            // ref params lets us pass a whole var to a f(n) 
            // and have it change the contents of that var freely

            // ref has a greater performance penalty than out

            //pointers in c#
            unsafe
            {
                // declare int
                int x2 = 20;
                // get mem address of that int as a pointer to the int
                int* pointer = &x2;
                Console.WriteLine((int)pointer);
                // pass it to a function to change the value at that address
                ChangeMyIntTwo(pointer);
            }
            // we need unsafe code sometimes when we are 
            // calling unmanaged APIs (like Windows API) that requires
            // pointers at arguments to their methods. Otherwise avoid it!

            // after installing Nuget package for NLog and its configs, 
            // we can use ILogger after removing some comments in the config file
            ILogger logger = LogManager.GetCurrentClassLogger();
            logger.Debug("logger created successfully");
            try
            {
                int.Parse("abc");
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            // regular expression matching in c#
            var logline = "2019-02-22 10:30:54.0847 DEBUG logger created successfully";
            //Regex.Match(logline, @"([\d-]+) ([\d:.]+) (\w+)");
            var match = Regex.Match(logline, @"([\d-]+) ([\d:.]+) (\w+)");

            // regex syntax:
            // "character classes": \d for all digits, 
            // \w for all word characters (letters, nums, and underscore)
            // \s for all whitespace, most of these have a opposite version with uppercase
            // \S for all non-whitespace

            // [abcd] means, one character, EITHER a,b,c,or d
            // * means 0 to many a chars
            // + means 1 to many a chars

            // () are for surrounding groups of characters that you want to extract later

            // third capturing group
            string logLevel = match.Groups[3].Value;
            string datestr = match.Groups[1] + " " + match.Groups[2];

            if(DateTime.TryParse(datestr, out var date))
                {
                Console.WriteLine(date);
            }
            else
            {
                Console.WriteLine($"Couldnt parse {datestr}");
            }

            Console.ReadLine(); // wait after finished
        }

        public static void ChangeMyIntDoesntWork(int number)
        {
            number = 10;
        }
        public static void ChangeMyInt(ref int number)
        {
            number = 10;
        }

        // unsafe is the same as unmanaged
        // right click project and go to properties to allow unsafe code
        // enable on a project level (csproj file)
        public static unsafe void ChangeMyIntTwo(int* number)
        {
            // pointers are like ref vars
            // but less abstracted, we can see the exact
            // memory location of the value
            *number = 5;
        }
    }
}
