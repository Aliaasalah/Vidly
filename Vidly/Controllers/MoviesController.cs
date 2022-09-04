using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies

        private ApplicationDbContext _contex;

        public MoviesController()
        {
            _contex = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _contex.Dispose();
        }
        public ActionResult Index()
        {
            var movies = _contex.Movies.Include( c=> c.Genre).ToList();
            return View(movies);
        }
        public ActionResult Random()
        {
            var Movie = new Movie() { Name = "MULAN" };
            /*//return View(Movie);
            // return Content("Hello");
            //return new EmptyResult();
            return RedirectToAction("Index", "Home"
                ,new { page = 1, sortBy = "name" });*/

            var customers = new List<Customer>
            { new Customer{Name="Cust1" },
              new Customer{Name = "Cust2"} };

            var ViewModel = new RandowMovieViewModel()
            { Movie=Movie,
            Customers = customers};
            return View(ViewModel);

        }

        public ActionResult Details(int id)
        {
            var movie = _contex.Movies.Include(x => x.Genre).SingleOrDefault(c => c.ID == id);
            if (movie == null)
                return HttpNotFound();
            return View(movie);
        }

        //[Route("movies/released/{year}/{month:regex(\\d{4}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year , int month)
        {
            return Content(year+"/"+month);
        }

        public ActionResult New()
        {
            var genres = _contex.genres.ToList(); ;
            var viewModel = new MovieFormView()
            {
                Movie = new Movie(),
                genres = genres
            };

            return View("MovieForm", viewModel);
        }

        public ActionResult Edit(int id)
        { 
            return Content("id = "+ id);
        }

     /*   public ActionResult Index(int? PageIndex , string sortBy)
        {
            if (!PageIndex.HasValue)
            {
                PageIndex = 1;
            }
            if (String.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }

            return Content(String.Format("pageIndex={0}&sortBy={1}",PageIndex,sortBy));

        }*/
    }
}