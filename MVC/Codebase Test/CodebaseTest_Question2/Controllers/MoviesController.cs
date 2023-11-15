using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodebaseTest_Question2.Models;

namespace CodebaseTest_Question2.Controllers
{
    public class MoviesController : Controller
    {

        MoviesContext Movies;
        List<Movies> list;
        public MoviesController()
        {
            list = new List<Movies>()
            {
                new Movies{movieid=1, moviename="moddwj", dateofrelease="20/09/2001"},
                new Movies{movieid=2, moviename="modj", dateofrelease="21/09/2001"},
                new Movies{movieid=3, moviename="mowj", dateofrelease="22/09/2001"}
            };
        }
        public ActionResult Index()
        {
            // Display movies released in the year 2022 as an example
            return View(moviesInYear);
        }

        public ActionResult Create()
        {
            // Create a new movie
          

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
          
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            // Delete a movie by id
        
            return RedirectToAction("Index");
        }
    }

}