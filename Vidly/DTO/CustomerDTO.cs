using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.DTO
{
    public class CustomerDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter Customer's name.")]
        [StringLength(225)]
        public string Name { get; set; }
       
        public bool IsSubscribedToNewsLetter { get; set; }

        public byte MembershiptypeId { get; set; }

        public MembershipTypeDto MembershipType { get; set; }


        //  [Min18YearsIfAMember]
        public DateTime? Birthday { get; set; }
    }
}