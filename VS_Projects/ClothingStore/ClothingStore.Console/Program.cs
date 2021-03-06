﻿using System;
using System.Collections.Generic;

namespace ClothingStore.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Clothing Store!");
            while(true)
            {
                Console.WriteLine();
                Console.WriteLine("r:\tDisplay Store Locations.");
                Console.WriteLine("a:\tAdd new Store.");
                Console.WriteLine("s:\tSave data to disk.");
                Console.WriteLine("l:\tLoad data from disk.");
                Console.WriteLine();
                Console.Write("Enter valid menu option, or \"q\" to quit: ");
                var input = Console.ReadLine();
                switch(input)
                {
                    case "r":
                        Console.WriteLine("Here is a list of Store locations, one per area.");
                        break;
                    case "a":
                        Console.WriteLine("Type in a store location here.");
                        Test();
                        break;
                    case "q":
                        Console.WriteLine("Bye! Please come again!");
                        break;
                    default:
                        Console.WriteLine("\n[Please enter a valid command]");
                        break;
                }
                if (input == "q")
                {
                    break;
                }
                
            }
        }

        // let's write other functions here
        static void Test()
        {
            Console.WriteLine("We are using Test");
        }
    }
}
