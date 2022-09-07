using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.DTO
{
    public class MovieDto
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }


        public GenreDto Genre { get; set; }

        public byte GenreId { get; set; }

        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        [Range (1,20)]
        public byte quantity { get; set; }
    }
}