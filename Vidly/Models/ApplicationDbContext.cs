using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Vidly.Models;

namespace Vidly.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext()
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }

        public DbSet<MembershipType> membershipTypes { get; set; }

        public DbSet<Genre> genres { get; set; }
    }

}
