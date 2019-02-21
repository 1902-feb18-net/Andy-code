using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionTesting.Library
{
    public class MyGenericCollection<T>
    {
        // by default T can be Any type
        protected readonly List<T> _list = new List<T>();

        // giving fields or props default values up here
        // is just for convenience - in reality
        // those assignments are copied to every constructor

        private int id;

        // when you make a new class inheriting from another
        // all fields, methods, and properties are inherited
        // however, const are not inherited

        // every non abstract class has at least one constr
        // if you don't write it in the '.cs' file, you get a default constr
        // with 0 params, that does nothing

        public MyGenericCollection() : this(null)
        {
            // all we do is set up fields, props, etc
            // any setu code
            // we don't put a return statement
        }

        //given array of T initial values
        // insert them into the list
        public MyGenericCollection(T[] initial)
        {
            id = new Random().Next();
            _list.AddRange(initial);
        }

        public void Add(T value)
        {
            _list.Add(value);
        }

        public bool Contains(T value)
        {
            return _list.Contains(value);
        }
    }
}
