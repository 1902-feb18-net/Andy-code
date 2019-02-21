using System;
using System.Collections;
using System.Collections.Generic;

namespace Collection
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Arrays();
            Lists();
            Sets();
            StringEquality();

            //couple other collections
            new Stack<int>(); // first in, last out
            new Queue<int>(); // first in, first out

        }

        static void Arrays()
        {
            // we can make fzed length lists of things, arrays
            int[] ints1 = new int[5];
            int[] ints2 = new int[] { 1, 2, 3, 4, 50 };

            // can go through arrays with for loop
            // if we have no need of index

            // can have arrays of any type
            int[][] twoDArry = new int[9][];
            twoDArry[0] = new int[4];
            twoDArry[1] = new int[4];
            // etc...
            // this is a 9 by 4 2d array
            // this is called a jagged array
            // each row could have diff len if we want 

            //c# has multidim array
            int[,] multiDArray = new int[5, 5];
            // makes a 5x5 multi-d array 
            multiDArray[0, 0] = 8;
            // comma instead of xtra brackets
            int[,,,] fourDArray = new int[5, 5, 4, 2]; 

            // rarely have any use for arrays
            // for performance is the main reason

            // in practice we use other objects
         
        }

        static void Lists()
        {
            // use .Add or initialization syntac for the initial contents
            var list = new ArrayList { 5, 8, 1 };
            list.AddRange(new int[] { 4, 5, 6, 7, 8 });
            list.Remove(8);

            for (int i = 0; i < list.Count; i++)
            {
                // can index into the list as if array
                Console.WriteLine(list[i]);
                //list[i] = 4 + i;
            }

            //foreach(var item in list)
            //{

            //}

            // early in c# history we got generics and we stoped using ArrayList

            // YAY GENERICS!
            var genericList = new List<int> { 1,2,3};
            // this list doesnt upcast everything to object, it only allows ints
            //genericList.Add("abc"); // this list instance is only tied to int type, this line will error

            foreach(var item in genericList)
            {
                Console.WriteLine(item * 2); // works since knows is ints
            }
        }

        static void Sets()
        {
            var set = new HashSet<string>();
            set.Add("abc");
            set.Add("abc");
            set.Add("abclasmda");
            // we take idea from math
            // a set has no concept of duplicates, something is either in it or not
            // a set also has no concept of order
            Console.WriteLine(set.Count);

            //sets are usfull when we arent interested in storing in any order
            // the main thing we want to do is later on
            // check if some thing is or is not inside the set

            // checking membership in the set is fast
            var list = new List<int> { 1, 2, 2, 2, 3 };
            var withoutDupes = new List<int>(new HashSet<int>(list));
        }

        static void Maps()
        {
            var dictionary = new Dictionary<string, string>();
            // store k,v of things between things
            dictionary["classroom"] = "room where classes are held";
            // also have initializer syntax for dictionaries
            var grades = new Dictionary<string, double>();
            grades["Nick"] = 80;

            // helpful members: Keys, Values, ContainsKey, ContainsValue, TryGetValue

            foreach(KeyValuePair<string, double> item in grades)
            {
                //item.Key;
                //item.Value;
            }

            // dictionary objects let you use any type you want to index into it
            // and any type to use for the value stored for that key

        }

        static void StringEquality()
        {
            string a = "asdf";
            string b = "asdf";
            Console.WriteLine(a == b); //returns true

            //value types and reference types
            //value types vars store their values directly
            // ref type var stores a ref to their val

            // in c# many of our basic types are value types
            // int, double, bool, float, long

            int n1 = 5;
            int n2 = n1; // int is value type so n2 gets a copy of n1

            var dummy1 = new Dummy();
            var dummy2 = dummy1;

            dummy1.Data = 10;
            if(dummy2.Data == 10)
            {
                Console.WriteLine("reference type");
            }
            else
            {
                Console.WriteLine("Value type");
            }
            // Dummy is a ref type, so dummy2 is a copy of the ref
            // e.g. a new ref to the same object

            // obj made from classes are ref types, always
            // obj made from structs are value types
            // all the built in val types are structs in c#

            var vDummy1 = new ValueDummy();
            var vDummy2 = vDummy1;

            vDummy2.Data = 10;
            if (vDummy2.Data == 10)
            {
                Console.WriteLine("reference type");
            }
            else
            {
                Console.WriteLine("Value type");
            }

            //structs are copied entirely every time we pass it to a new method or assign to a new var
            // value types are deleted from mem as soon as it goes out of scope

            // ref types we get a new copy of ref
            // but to the same underlying obj
            // ref types needs to be garbage collected because we don't know right away
            // when the last var pointing to it has passed out of scope

            // in C# we have idea of managed vs unmanaged code
            // in unmanaged code you have to manually write the code to delete ref type obj from mem

            // in managed code, there is a garbage that runs periodically
            // to search for obj that are unreachable by any running parts of the code

            // tradeoff, computer should work harder so the dev can solve real problems

            // back to strings

            // Normally '==' compares value types by value, and ref by ref

            Console.WriteLine(new Dummy() == new Dummy()); //false... ref types
            // for val types like structs, they don't have to be the same obj
            // just have the same value

            // but we have an exception for strings because it's awkward to have to 
            // do string.Equals() for comparing strings
            //"abc" == "abc";

            // in C#, all value types do derive ultimately from obj
            // so we can always upcast them to obj vars
            int i1 = 5;
            object o2 = i1; //implicit upcasting, aka boxing
            // the int is wrapped inside a ref type
            // to give that value ref type semantics
            // "unboxing" ... the reverse with downcasting
            int i2 = (int)o2; // extract that valu from inside the obj wrapper

            // java has awkward Integer vs int distinctions
            // we have this as boxing and unboxing with object

            // sometimes we want to see if two objs have the same values in them
            // for that we make use of .Equals
        }
    }
    class Dummy {
        public int Data { get; set; }
    }
    struct ValueDummy {
        public int Data { get; set; }
    }
}
