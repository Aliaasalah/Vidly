using AutoMapper;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;
using Vidly.DTO;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _contex;

        CustomersController()
        {
            _contex = new ApplicationDbContext();
        }
       
        public IHttpActionResult GetCustomers()
        {
            //  return _contex.Customers.ToList().Select(Mapper.Map<Customer,CustomerDTO>);
            //var r = _contex.Customers.ToList();
            var q = _contex.Customers.Include(x => x.MembershipType);

            var customerDtos = q.ToList().Select(Mapper.Map<Customer, CustomerDTO>);
            return Ok(customerDtos);

        }


        public IHttpActionResult GetCustomer(int id)
        {
            var Customer = _contex.Customers.SingleOrDefault(c => c.Id == id);
            if (Customer == null)
                return NotFound();

            return Ok(Mapper.Map<Customer, CustomerDTO>(Customer));
        }

        [HttpPost]
        public IHttpActionResult PostCustomer(CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var customer = Mapper.Map<CustomerDTO, Customer>(customerDTO);
            _contex.Customers.Add(customer);
            _contex.SaveChanges();

            customerDTO.Id = customer.Id;
            return Created(new Uri(Request.RequestUri+"/"+ customer.Id),customerDTO);
        }

        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDTO customerDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var customerInDB = _contex.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDB == null)
            {
                return NotFound();
            }

            Mapper.Map(customerDto, customerInDB);

            _contex.SaveChanges();

            return Ok();

        }

        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var customerInDB = _contex.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDB == null)
            {
                return NotFound();
            }

            _contex.Customers.Remove(customerInDB);
            _contex.SaveChanges();

            return Ok();

        }
    

    }
}
