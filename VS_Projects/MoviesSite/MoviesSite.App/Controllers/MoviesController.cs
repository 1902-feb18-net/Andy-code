using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesSite.App.Models;
using MoviesSite.Lib;

namespace MoviesSite.App.Controllers
{
    public class MoviesController : Controller
    {
        private static readonly List<Movie> _moviesDb = new List<Movie>();
        private static readonly List<Genre> _genreDb = new List<Genre>();

        static MoviesController()
        {
            // place to set up static fields
            
            _genreDb = new List<Genre>
            {
                new Genre {Id = 1, Name = "Action"},
                new Genre {Id = 2, Name = "Comedy"},
            };

            _moviesDb = new List<Movie>
            {
                new Movie
                {
                    Id=1,
                    Title = "Star wars 4",
                    DateReleased = new DateTime(1970, 1, 1),
                    genre = _genreDb[0]
                }
            };
        }

        public MovieRepository MovieRepo { get; set; } =
            new MovieRepository(_moviesDb, _genreDb);

        // GET: Movies
        public ActionResult Index()
        {
            var viewModel = "something";
            var movies = MovieRepo.AllMovies();
            return View(movies);
        }

        // GET: Movies/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var movie = MovieRepo.MovieById(id);
                var viewModel = new MovieViewModel {
                    Id = movie.Id,
                    Title = movie.Title,
                    ReleaseDate = movie.DateReleased,
                    etc...
                };
                return View(movie);
            }
            catch (InvalidOperationException)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            var viewModel = new MovieViewModel
            {
                Genres = MovieRepo.AllGenres().ToList()
            };
            return View();
        }

        // POST: Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie)
        {
            try
            {
                // TODO: Add insert logic here
                if(!ModelState.IsValid)
                {   
                    // DataAnnotations on view model
                    // prompt client side validation
                    // also during model binding (when the user's form data
                    // is put into apples biscuits butterscotch 

                    return View(viewModel)
                }
                // fill in later
                var movie = new Movie
                {
                    Id = viewModel.Id,
                    Title = viewModel.Title,
                    DateReleased,
                    Genre =  blah
                }
                MovieRepo.CreateMovie(movie);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(movie);
            }
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int id)
        {
            // with edit, we prepopulate existing values
            try
            {
                var movie = MovieRepo.MovieById(id);
                return View(movie);
            }
            catch(InvalidOperationException)
            {
                // log that and redirect to error page
                return RedirectToAction("Error", "Home");
            }
            
        }

        // POST: Movies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Movie movie)
        {
            try
            {
                // TODO: Add update logic here
                MovieRepo.Update(id, movie);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(movie);
            }
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int id)
        {
            {
                try
                {
                    var movie = MovieRepo.MovieById(id);
                    return View(movie);
                }
                catch (InvalidOperationException ex)
                {
                    // should log that, and redirect to error page
                    return RedirectToAction("Error", "Home");
                }
            }
        }

        // POST: Movies/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                MovieRepo.DeleteMovie(id);
                // way to write string index and will redirect there
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}