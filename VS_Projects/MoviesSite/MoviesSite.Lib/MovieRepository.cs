﻿using System;
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
            return _genreData.First(g => g.Id == id);
        }

        public void Create(Movie movie)
        {
            int id = _moviesData.Max(m => m.Id) + 1;
            movie.Id = id;
            _moviesData.Add(movie);
        }

        public void CreateMovie(Movie movie)
        {
            if (_moviesData.Count == 0)
            {
                movie.Id = 1;
            }
            else
            {
                int id = _moviesData.Max(m => m.Id) + 1;
                movie.Id = id;

            }
            _moviesData.Add(movie);
        }

        public void Update(int id, Movie movie)
        {
            var oldMovie = MovieById(id);
            oldMovie.Title = movie.Title;
            oldMovie.genre = movie.genre is null ? null : GenreById(movie.genre.Id);
            oldMovie.DateReleased = movie.DateReleased;
        }

        public void DeleteMovie(int id)
        {
            _moviesData.Remove(MovieById(id));
        }

        public object AllGenres()
        {
            throw new NotImplementedException();
        }
    }
}
