﻿using System;

namespace Delegates
{
    class Program
    {
        static void Main(String[] args) {
            
            var moviePlayer = new MoviePlayer
            {
                CurrentMovie = Movie.StarWars4
            };

            MoviePlayer.MovieFinishedHandler handler = EjectDisc;

            //subscribe to an event
            moviePlayer.MovieFinished += handler;

            moviePlayer.MovieFinished += EjectDisc;

            //unsubscribe
            // moviePlayer.MovieFinished -= handler;
            moviePlayer.MovieFinished += () =>
            {
                // can do anything inside a lambda
                Console.WriteLine("handle event with block body");
            };

            // with expression body, you can only put one line in
            moviePlayer.MovieFinished += () => Console.WriteLine("expression body");

            // we can specify type on lamda function params
            // but usually they are inferred from context like var
            
            //moviePlayer.DiscEjected += (string s) => Console.WriteLine($"Ejecting {s}");
            moviePlayer.DiscEjected += s => Console.WriteLine($"Ejecting {s}");

            Console.WriteLine("Playing movie....");

            moviePlayer.Play();
        }

        private static void FuncAndAction()
        {
            Func<string, string, int> func = (s1, s2) => s1.Length + s2.Length;
            Action<string, string, int> action = (s1, s2, i) => Console.WriteLine(s1 + s2 + i);
        }

        public static void EjectDisc()
        {
            Console.WriteLine("Ejecting");
        }
        
    }
}
