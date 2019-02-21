using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Delegates
{
    public class MoviePlayer
    {
        // instead string, we use Movie from the Movie.cs enum we created
        public Movie CurrentMovie { get; set; }

        // declares a delegate type
        // all the type in c#: class, struct, interface, enum, delegate
        // delegate type is a name for a function with a particular signature (return value and params)
        public delegate void MovieFinishedHandler();

        // is an event member
        // every event has a delegate type to indicate 
        // what kind of functions can be subscribed to the event
        // "there will be a MovieFinished event and you can subscribe to it with any MovieFinishedHandler"
        // e.g. and void return, zero-param fn
        public event MovieFinishedHandler MovieFinished;

        // Action is for void returning function
        //   the type params are all the params of fn
        // Func type is for all other functions
        //  the last type param is for the return type
        public event Action<string> DiscEjected;

        // technically we can even subscribe to delegate typed members without events at all
        // but it's a bit more limited

        // return true if success, false if failure
        public bool Play()
        {
            // wait 3 secs
            Thread.Sleep(3000);

            // firing the Moviefinished event
            // must null check because there are 0 subscribers
            // nullReferenceException
            //if (MovieFinished is null)
            //{
            //    MovieFinished();
            //}

            // firing the MovieFinished Event
            MovieFinished?.Invoke();
            // will not just call one fn, but all event subscribers
            // `?.` is a special operator called the null coalescing operator
            // if the thing to left is null, it returns null
            // if thing to the left is not null, will behave like .

            // `??` is the null coalescing operator
            // a ?? b, means return a, unless it's null, in which case returns b

            // when we fire the event, we provide all the params that the event says it needs
            DiscEjected?.Invoke(CurrentMovie.ToString());
            return true;
        }
    }
}
