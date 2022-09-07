using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class QuantityValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (Movie)validationContext.ObjectInstance;

            return (movie.quantity >= Movie.MinQuantity ||
                movie.quantity <= Movie.MaxQuantity)
                ? ValidationResult.Success
                : new ValidationResult("Quantity Must be between 1 and 20!");
        }
    }
}