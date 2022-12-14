using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Vidly.Models
{
    public class Movie
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        
        public Genre Genre { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public byte GenreId { get; set; }

          [Required]
        public DateTime ReleaseDate { get; set; }

      //  [Required]
        public DateTime DateAdded { get; set; }

        [Required]
        [QuantityValidation]
        public byte quantity { get; set; }

        public static readonly byte MinQuantity = 1;
        public static readonly byte MaxQuantity = 20;


    }
}