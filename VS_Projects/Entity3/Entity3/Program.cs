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
            using (var dbContext = new MoviesContext(options))
            {
                // lots of complex setup... here is where the payoff begins
                //PrintMovies(dbContext);
                //Console.WriteLine();

                //AddMovie(dbContext);

                //PrintMovies(dbContext);
                //Console.WriteLine();

                //UpdateMovies(dbContext);

                //PrintMovies(dbContext);
                //Console.WriteLine();

                //DeleteAMovie(dbContext);

                //PrintMovies(dbContext);
                //Console.WriteLine();
            }

            Console.ReadLine();
        }

        void AddMovie(Movie movie) { }
        void UpdateMovie(Movie movie) { }
        void DeleteMovie(Movie movie) { }
    }
}
