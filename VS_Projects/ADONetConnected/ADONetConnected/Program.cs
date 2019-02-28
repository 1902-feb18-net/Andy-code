using System;
using System.Data.SqlClient;

namespace ADONetConnected
{
    class Program
    {
        static void Main(string[] args)
        {
            // ADO.NET
            // originally meant: Active Data Objects, ADO. now later ADO.NET
            // ADO.NET is the "brand name"/"namespace" for all .NET data access stuff (including Identity framework)
            // but in practive, when we say ADO.NET we mean the old fashioned way
            // we're about to see

            // ADO.NET has things in System.Data namespace
            // we need a data provider - use NuGet package System.Data.sqlClient
            // for SQL server connections

            var connString = SecretConfiguration.ConnectionString;
            //var connection = new SqlConnection(connString);

            Console.WriteLine("Enter condition: ");
            var condition = Console.ReadLine();
            // e.g. MovieId < 2
            var commString = $"SELECT * FROM Movie.Movie Where {condition}";

            // CAREFUL OF SQL INJECTION!!!
            // user could enter "1 = 1; DROP TABLE Movie.Movie;" and I drop table.
            // solution: sanitize and validate all user input

            // for connected architecture

            // we should be catching exceptions
            using (var connection = new SqlConnection(connString))
            {
                // 1. open the connection
                connection.Open();

                // 2. execute query
                var commString2 = "SELECT * FROM Movie.Movie;";
                using (var command = new SqlCommand(commString2, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // we have a command.ExecuteReader which returns a DataReader
                        //  For SELECT queries
                        // we have a command.ExecuteQuery which just returns num
                        //  of rows affected for DELETE, INSERT, etc

                    //3. process the results
                        if(reader.HasRows)
                        {
                            // reader.read advances the cursor through the results, one row at a time
                            // the results are coming in to the computer's network buffer
                            // and DataReader is reading them each as soon as they come in
                            // (network are slower compared to code) 
                            while(reader.Read())
                            {
                                object id = reader["MovieId"];
                                object title = reader["Title"];
                                // object fullTitle = reader[5]; //5th col, 0 takes something up it seems?
                                string fullTitle = reader.GetString(5); //5th col

                                // i could do downcasting and instantiate some Movie class
                                // or just print results

                                Console.WriteLine($"Movie #{id}: {fullTitle}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No rows returned");

                        }

                        // 4. close the connection
                        connection.Close();
                    }
                }
            }
            //connection.Open();
            Console.ReadKey();
        }
    }
}
