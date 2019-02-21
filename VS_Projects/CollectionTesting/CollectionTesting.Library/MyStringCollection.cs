using System;
using System.Collections.Generic;

namespace CollectionTesting.Library
{
    public class MyStringCollection : MyGenericCollection<string>
    {
        // use a private or protected field 
        // to store a List<String> to handle all the list operations

        // implement some collection methods like Add, Contains, Remove, and some
        // others not  already on the list (e.g. remove all empty string)

        // at least 5 methods on there

        // : base() this means if someone calls the zero param constructo
        // first call the base class's zero param constructor (this is done by default)
        public MyStringCollection() : base()
        {

        }

        public MyStringCollection(string[] initial) : base(initial)
        {

        }

        // in c# we prefer thin constructors,
        // and setting properties after the fact
        // If we still want validation logic, can put that in propert "sets" and 
        // maybe a .validate method

        // now we are getting field from parent class
        //private List<String> _list = new List<string>();

        //public void Add(string value)
        //{
        //    _list.Add(value);
        //}

        //public void Contains(string value)
        //{
        //    _list.Contains(value);
        //}

        /// <summary>
        /// Replace all contained strings with lowercased versions
        /// </summary>
        public void MakeLowercase()
        {
            for(int i = 0; i < _list.Count; i++)
            {
                _list[i] = _list[i].ToLower();
            }
        }

        public void RemoveEmpty()
        {
            while(_list.Contains(""))
            {
                _list.Remove("");
            }
            // or.. using lambda
            _list.RemoveAll(x => x == "");
        }

        public bool Remove(string value)
        {
            return _list.Remove(value);
        }

        public string GetFirst()
        {
            // throws IndexOutOfBoundsException
            if(_list.Count == 0)
            {
                throw new InvalidOperationException("list is empty");
            }
            return _list[0];
        }
    }
}
