using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity3Database;

namespace Entity3
{
    // here we implement our interface IMovieRepo
    class MovieRepo : IMovieRepo
    {
        public static MoviesContext dbContext { get; set; }

        public void AddMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public void DeleteMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public void UpdateMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Genre> GetAllGenres()
        {
            //throw new NotImplementedException();
            return dbContext.Genre.ToList();
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            //throw new NotImplementedException();
            return dbContext.Movie.ToList();
        }

        public Movie GetMovieById(int id)
        {
            //throw new NotImplementedException();
            return dbContext.Movie
                .Single(movie => movie.MovieId == id);
        }

        public IEnumerable<Movie> GetMoviesByGenre(Genre genre)
        {
            //throw new NotImplementedException();
            return dbContext.Movie
                .ToList()
                .Where(movie => movie.Genre == genre);
        }
    }
}
