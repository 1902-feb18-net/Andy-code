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

            SqlConnection connString = "Server=tcp:ly1902sql.database.windows.net,1433;Initial Catalog=Chinook;Persist Security Info=False;User ID={your_username};Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        }
    }
}
