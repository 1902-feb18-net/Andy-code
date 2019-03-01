using System;
using System.Collections.Generic;
using System.Text;
using Entity3Database;

namespace Entity3
{
    // here we implement our interface IMovieRepo
    class MovieRepo : IMovieRepo
    {
        public void AddMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public void DeleteMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Genre> GetAllGenres()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            throw new NotImplementedException();
        }

        public Movie GetMovieById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> GetMoviesByGenre(Genre genre)
        {
            throw new NotImplementedException();
        }

        public void UpdateMovie(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
