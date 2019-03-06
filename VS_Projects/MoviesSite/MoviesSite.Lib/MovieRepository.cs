using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoviesSite.Lib
{
    public class MovieRepository
    {
        private readonly IList<Movie> _moviesData;
        private readonly IList<Genre> _genreData;

        // ctor + Tab TAb makes constructors
        public MovieRepository(IList<Movie> moviesData, IList<Genre> genreData)
        {
            _moviesData = moviesData;
            _genreData = genreData;
        }

        public IEnumerable<Movie> AllMovies()
        {
            return _moviesData.ToList();
        }

        public IEnumerable<Movie> AllMoviesWithGenre(Genre genre)
        {
            return _moviesData.Where(m => m.genre.Id == genre.Id).ToList();
        }

        public Movie MovieById(int id)
        {
            return _moviesData.First(m => m.Id == id);
        }

        public Genre GenreById(int id)
        {   
            // fill out later
            return null;
        }

        public void Create(Movie movie)
        {
            int id = _moviesData.Max(m => m.Id) + 1;
            movie.Id = id;
            _moviesData.Add(movie);
        }

        public void Update(int id, Movie movie)
        {
            var oldMovie = MovieById(id);
            oldMovie.Title = movie.Title;
            //oldMovie.genre = movie.genre.Id;
            oldMovie.genre = GenreById(movie.genre.Id);
            oldMovie.DateReleased = movie.DateReleased;
        }

        public void DeleteMovie(int id)
        {
            _moviesData.Remove(MovieById(id));
        }
    }
}
