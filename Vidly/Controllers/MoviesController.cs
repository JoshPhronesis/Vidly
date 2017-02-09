using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movie/Random
        ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMovies))
            {
                return View("List");
            }
            
                return View("ReadOnlyList");
            
            //var movies = _context.Movies;
            //return View(movies);
        }
        public ActionResult Details(int id)
        {
            Movie movie = _context.Movies.First(x => x.Id == id);
            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MoviesViewModel(movie)
                {
                    GenreTypes = _context.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }
            //var genre = _context.Genres.Single(g => g.Id == movie.GenreId);
            //movie.Genre = genre;
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var MovieInDb = _context.Movies.Single(c => c.Id == movie.Id);
                MovieInDb.Name = movie.Name;
                MovieInDb.ReleaseDate = movie.ReleaseDate;
                // MovieInDb.Genre = movie.Genre;
                MovieInDb.NumberInStock = movie.NumberInStock;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var genreType = _context.Genres.ToList();
            var moviesViewModel = new MoviesViewModel
            {
                Operation = "Add Movie",
                GenreTypes = genreType
            };

            return View("MovieForm", moviesViewModel);
        }
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            var ViewModel = new MoviesViewModel(movie)
            {
                GenreTypes = _context.Genres.ToList(),
                Operation = "Edit Movie",
               // GenreTypes = _context.Genres.ToList()
            };
            return View("MovieForm", ViewModel);
        }
    }
}