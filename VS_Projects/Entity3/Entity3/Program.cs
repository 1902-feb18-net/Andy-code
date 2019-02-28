using Entity3Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;


namespace Entity3
{
    class Program
    {
        static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MoviesContext>();
            optionsBuilder.UseSqlServer(SecretConfiguration.ConnectionString);
            var options = optionsBuilder.Options;
        }
    }
}
