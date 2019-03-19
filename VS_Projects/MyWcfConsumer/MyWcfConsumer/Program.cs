using MyWcfConsumer.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWcfConsumer
{
    class Program
    {
        // to make work, change version from 7.0 to 7.3
        // right click project -> build -> advanced -> top thing change to 7.3
        // when we make anything async, if it returns void, we make it return task
        // but if it returns T, we make it return Task<T>
        static async Task Main(string[] args)
        {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            Console.WriteLine("Hello World!");

            using (var client = new Service1Client())
            {
                client.Open();

                var version = await client.GetServiceVersionAsync();
                Console.WriteLine(version);

                Console.WriteLine("enter number: ");
                if (int.TryParse(Console.ReadLine(), out var num))
                {
                    // check Nick's note to see how he used TransactionScope
                    //using (var trans = new TransactionScope())
                    var doubled = await client.DoubleNumberAsync(num);
                    Console.WriteLine($"Doubled: {doubled}");
                }
                else
                {
                    Console.WriteLine("Not a number");
                }

                // won't know since we need to rescaffold
                // right click serviceReference1 and update it
                Question question = client.GetQuestion(1);
                var question2 = client.GetQuestion(2);


               
            }

            Console.ReadKey();

        }
    }
}
