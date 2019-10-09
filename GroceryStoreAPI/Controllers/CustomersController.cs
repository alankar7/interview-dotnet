using GroceryStore.Data;
using GroceryStore.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace GroceryStoreAPI.Controllers
{
    [ApiController]
    public class CustomersController : ControllerBase
    {
        // list all customers
        // GET: api/Customers
        [Route("api/customers")]
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetCustomers()
        {
            try
            {
                return Ok(CustomerRepository.GetCustomers());
            }
            catch
            {
                //TODO: Log exception
                return StatusCode(500); //Internal Server Error
            }
        }

        // retrieve a customer by id
        // GET: api/Customers/5
        [Route("api/customers/{id}")]
        [HttpGet]
        public ActionResult<Customer> GetCustomerById(int id)
        {
            try
            {
                var customer = CustomerRepository.GetCustomerById(id);
                if (customer == null)
                {
                    return NotFound();
                }
                return Ok(customer);
            }
            catch (Exception e)
            {
                //TODO: Log exception
                return StatusCode(500); //Internal Server Error
            }
        }

        // POST: api/Customers
        [HttpPost]
        public ActionResult AddCustomer([FromBody] string customerName)
        {
            if (string.IsNullOrWhiteSpace(customerName))
            {
                return BadRequest();
            }
            int customerId = CustomerRepository.AddCustomer(customerName);
            var newCustomer = new Customer()
                                {
                                    id = customerId,
                                    name = customerName
                                };
            return CreatedAtAction(nameof(GetCustomerById), new { id = customerId }, newCustomer);
        }

        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public ActionResult UpdateCustomer([FromBody] Customer customer)
        {
            if (customer == null)
            {
                return BadRequest();
            }

            CustomerRepository.UpdateCustomer(customer);
            return NoContent();
        }
    }
}
