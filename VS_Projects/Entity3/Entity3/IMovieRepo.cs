using Entity3Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Entity3
{
    interface IMovieRepo
    {
        // implement IMovieRepo (or similar) and then have your console app test those methods.
        IEnumerable<Movie> GetAllMovies();
        IEnumerable<Genre> GetAllGenres();
        Movie GetMovieById(int id);
        IEnumerable<Movie> GetMoviesByGenre(Genre genre);
        void AddMovie(Movie movie);
        void UpdateMovie(Movie movie);
        void DeleteMovie(Movie movie);
    }
}
