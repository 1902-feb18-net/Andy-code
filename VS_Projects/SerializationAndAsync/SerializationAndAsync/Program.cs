using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerializationAndAsync
{
    class Program
    {
        static void Main(string[] args)
        {
            var persons = new List<Person>
            {
                new Person
                {
                    Id = 1,
                    Name = "Jan",
                    Address = new Address
                    {
                        Street = "123 apple lane",
                        City = "Austin",
                        State = "TX"
                    }
                },
                new Person
                {
                    Id = 2,
                    Name = "Jojojojojojojojo",
                    Address = new Address
                    {
                        Street = "some star lane",
                        City = "Reston",
                        State = "VA"
                    }
                }
            };

            // to send this over network or to disk, we need to serialize it
            // meaning collecting data from across memory locations
            // into a well defined text or binary format
            // ideally this is reversible, we can deserialize the data back from
            // its format into memory (maybe on the other end of the network connection)

            // normally \ is used as an escape character in string literals
            // this string has a new ling character
            string newLine = "\n";
            string fileName = @"C:\revature\persons_data.xml";

            // we would write this
            // except main can't be async, so we will synchronously wait on results
            //persons = await DeserializeXMLFromFileAsync(fileName);
            persons =  DeserializeXMLFromFileAsync(fileName).Result;

            // FIX this line later
            //persons.Add(new Person { Id = persons.Max((p => p.Id) + 1) });

            SerializeAsXMLToFile(fileName, persons);

            // we could serialize in JSOn format instead of XML...
            // DataContractSerializer (built in to .NET)
            // JSON.NET (aka Newtonsoft JSON) (3rd party)

            string jsonFile = @"C:\revature\persons_data.json";
            // JSON STUFFS RELOOK THROUGH LATER AND FILL THE BLANKS
            string data = File.ReadAllTextAsync(jsonFile).Result;
            persons = JsonConvert.DeserializeObject<List<Person>>(data);

            persons.Add(new Person { Id = persons.Max(persons => persons.Id) + 1 });
            //Wait() and .Result both wait synchronously
            BLARGHHH



        }

        // async code requires async tests


        private static void SerializeAsXMLToFile(string fileName, List<Person> persons)
        {
            // very old fashioned, our first object xmlSerializer
            // does not know about generics
            var serializer = new XmlSerializer(typeof(List<Person>));

            FileStream fileStream = null;
            try
            {
                fileStream = new FileStream(fileName, FileMode.Create);
                serializer.Serialize(fileStream, persons);
            }
            catch (IOException ex)
            {
                Console.WriteLine("error in writing to file");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                fileStream?.Dispose(); // all IDisposable have Dispose method
            }

            // create mode to overwrite file if already exist
            //FileStream fileStream = new FileStream(fileName, FileMode.Create);

            
        }

        // Wjem we make a code async...
        // the method has to have the "async" modifier
        // the method needs to return a task for void-return or
        // a Task<Something> if we wanted to return Something
        // the method should say Async at the end of its name for self doc purpose
        // when we call async methods in our methods, we need to "await" the tasks they give us
        private static async Task<Person> DeserializeXMLFromFileAsync(string fileName)
        {
            var serializer = new XmlSerializer(typeof(List<Person>));
            // in addition to those XMLblahblah attributes, we can also customize the 
            // format on the serializer obj itself
            //FileStream fileStream = null;
            //var memoryStream = new MemoryStream();

            // we're going to use "using statements" not to be confused
            // with "using directive" at the top of file

            // in place of boilerplate code with IDisposable "try finally disposed"

            using (var memoryStream = new MemoryStream())
            {
                using (FileStream fileStream = new FileStream(fileName, FileMode.Open))
                {
                    // copy the filestream into the memorystream
                    //Task copying = fileStream.CopyToAsync(memoryStream);
                    //await copying;
                    await fileStream.CopyToAsync(memoryStream);
                    // obj you're using need to support async, or you aren't able to use it
                    // XmlSerializer.DeserializeAsync doesn;t exist or else
                    // we wouldn't need the memoryStream
                }
                //using statement auto disposes the resource when we exit it

                // reset "cursor" of stream to beginning to read its contents
                memoryStream.Position = 0;

                return (List<Person>)serializer.Deserialize(memoryStream);
                // should be try catching through this method
            }

            //try
            //{
            //    fileStream = new FileStream(fileName, FileMode.Open);
            //    return (List<Person>)serializer.Deserialize(fileStream);
            //}
            //catch (IOException ex)
            //{
            //    Console.WriteLine("error in writing to file");
            //    Console.WriteLine(ex.Message);
            //    return null;
            //}
            //finally
            //{
            //    fileStream?.Dispose(); // all IDisposable have Dispose method
            //}

        }
    }
}
