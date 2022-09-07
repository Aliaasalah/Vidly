using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly.Models
{
    public class Customer
    {
        public int id { get; set; }
       

        [Required(ErrorMessage ="Please enter Customer's name.")]
        [StringLength(225)]
        public string Name { get; set; }
        public MembershipType MembershipType { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
       
        [Display(Name="Membership Type")]
        public byte MembershiptypeId { get; set; }
        
        [Min18YearsIfAMember]
        [Display(Name="Date Of Birth")]
        public DateTime? Birthday { get; set; }
    }
}