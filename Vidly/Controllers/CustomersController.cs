using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers

        private ApplicationDbContext _contex;

        public CustomersController()
        {
            _contex = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _contex.Dispose(); 
        }

        public ActionResult New()
        {
            var membershipTypes = _contex.membershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                customer=new Customer(),
                membershipTypes = membershipTypes
            };

            return View("CustomerForm",viewModel);
        }

        [HttpPost]
        public ActionResult Save( Customer customer)
        {
            if (customer.id == 0)
                _contex.Customers.Add(customer);
            else
            {
                var Cust = _contex.Customers.Single(c => c.id==customer.id);
                Cust.Name = customer.Name;
                Cust.Birthday = customer.Birthday;
                Cust.MembershiptypeId = customer.MembershiptypeId;
                Cust.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            }
            _contex.SaveChanges();
            return RedirectToAction("Index","Customers"); 
        }


        public ActionResult Index()
        {
            _contex.Customers.Include(x => x.MembershipType).ToList();

            var customers = _contex.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }

        public ActionResult Edit(int id)
        {
            var customer = _contex.Customers.SingleOrDefault(c => c.id==id);
            if (customer == null)
                return HttpNotFound();
            var viewModel = new CustomerFormViewModel()
            {customer=customer,
            membershipTypes= _contex.membershipTypes.ToList()};

            return View("CustomerForm",viewModel);
        }

        public ActionResult Details(int id)
        {
            var customer = _contex.Customers.Include(c => c.MembershipType).SingleOrDefault(c=> c.id==id);
            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }

    }
}