using System;
using System.Data;
using System.Data.SqlClient;

namespace ADODotNetDisconnected
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter condition ");
            var condition = Console.ReadLine();

            // disconnected architecture
            // rather than maximizing speed of getting the results
            // we want to min the time connection spends open

            // still need NuGet package System.Data.SqlClient (for sql server)
            // and using directive "using System.Data;"

            // System.Data.DataSet can store data that DataReader gets,
            // with the help of DataAdapter
            var dataSet = new DataSet();

            var connectionString = SecretConfiguration.ConnectionString;
            var commandString = $"SELECT * FROM Movie.GenreId WHERE {condition}";

            using (var connection = new SqlConnection(connectionString))
            {
                // d/c architecture with ADO.NET

                // step 1. open the connections
                connection.Open();
                using (var command = new SqlCommand(commandString, connection))
                using (var adapter = new SqlDataAdapter(command))
                {
                    // step 2. execute the query, filling the dataset 
                    adapter.Fill(dataSet);
                    // (The DataAdapter is internally using DataReader)
                }
                // step 3. close the connection
                connection.Close();
            }
            // Step 4. Process the resu;ts
            // not while connection is open, to get it closed ASAP

            // inside DataSet is some DataTables
            // insde DataTable is DataColumn, DataRow
            // inside DataRow is object[]
            // this is non-generic

            //old fashioned non generic foreach
            // (based on nongeneric IEnumerable)
            // does implicit downcasting
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                DataColumn idCol = dataSet.Tables[0].Columns("GenreId");
                Console.WriteLine($"Genre #{row[idCol]}: + {row[1]}");
            }

            Console.ReadLine();
        }
    }
}
