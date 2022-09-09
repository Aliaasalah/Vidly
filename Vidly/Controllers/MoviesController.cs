using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;
using System.Data.Entity.Validation;

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
        public ViewResult Index()
        {
            //var movies = _contex.Movies.Include( c=> c.Genre).ToList();
            return View();
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
                
                genres = genres
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            // movie.Genre
            if (movie.ID == 0)
            {
                movie.DateAdded = DateTime.Now;
                _contex.Movies.Add(movie);
            }
            else
            {
                var movie1 = _contex.Movies.Single(m => m.ID == movie.ID);
                movie1.Name = movie.Name;
                movie1.quantity = movie.quantity;
                movie1.ReleaseDate = movie.ReleaseDate;
                movie1.GenreId = movie.GenreId;


            }

            try
            {
                _contex.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {

                Console.WriteLine(e);
            } 
            
            return RedirectToAction("Index", "Movies");
        }

        // public ActionResult Edit(int id)
        // { 
        //     return Content("id = "+ id);
        // }
        public ActionResult Edit(int id)
        {
            var movie = _contex.Movies.SingleOrDefault(c => c.ID == id);
            if (movie == null)
                return HttpNotFound();
            var viewModel = new MovieFormView(movie)
            {
                genres = _contex.genres.ToList()
            };

            return View("MovieForm", viewModel);
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