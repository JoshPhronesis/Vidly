using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MoviesViewModel
    {
        public MoviesViewModel()
        {
            Id = 0;
        }
        public MoviesViewModel(Movie movie)
        {

            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
                
        }
        public IEnumerable<Genre> GenreTypes { get; set; }
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }
        [Required]
        [Range(1,20)]
        [Display(Name = "Number in Stock")]
        public int? NumberInStock { get; set; }
        [Required]
        public Genre Genres { get; set; }
        [Required]

        [Display(Name = "Genres")]
        public int GenreId { get; set; }

        public string Operation { get; set; }
    }
}