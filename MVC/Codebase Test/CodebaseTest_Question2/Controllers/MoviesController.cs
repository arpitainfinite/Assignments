using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodebaseTest_Question2.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieRepository _movieRepository = new MovieRepository();

        public ActionResult Index()
        {
            // Display movies released in the year 2022 as an example
            var moviesInYear = _movieRepository.GetMoviesByYear(2022);
            return View(moviesInYear);
        }

        public ActionResult Create()
        {
            // Create a new movie
            var newMovie = new Movie
            {
                Moviename = "Inception",
                DateofRelease = new DateTime(2010, 7, 16)
            };
            _movieRepository.AddMovie(newMovie);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            // Retrieve a movie by id and update it
            var movieToUpdate = _movieRepository.GetMoviesByYear(id).FirstOrDefault();
            if (movieToUpdate != null)
            {
                movieToUpdate.Moviename = "Updated Movie";
                _movieRepository.UpdateMovie(movieToUpdate);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            // Delete a movie by id
            _movieRepository.DeleteMovie(id);
            return RedirectToAction("Index");
        }
    }

}