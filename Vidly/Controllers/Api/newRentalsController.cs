using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{

    public class newRentalsController : ApiController
    {
        ApplicationDbContext _context;
        public newRentalsController()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<Rental> GetRentals()
        {
            return  _context.Rentals.ToList();
        }
        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            if (newRental.MovieIds.Count == 0)
            {
                return BadRequest("No Movie Ids have been given");
            }
            var customer = _context.Customers.SingleOrDefault(c => c.Id == newRental.CustomerId);
            if (customer == null)
            {
                return BadRequest("Customer Id is not valie");
            }

            var movies = _context.Movies.Where(m => newRental.MovieIds.Contains(m.Id)).ToList();
            if (movies.Count != newRental.MovieIds.Count)
            {
                return BadRequest("One or more MovieIds are invalid");
            }

            foreach (var movie in movies)
            {
                movie.NumberInStock--;
                if (movie.Availability == 0)
                {
                    return BadRequest("Movie is not available");
                }
                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);
            }
            _context.SaveChanges();
            return Ok();
        }
    }

}
