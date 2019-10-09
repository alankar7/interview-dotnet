using GroceryStore.Data;
using GroceryStore.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace GroceryStoreAPI.Controllers
{
    [ApiController]
    public class OrdersController : ControllerBase
    {
        // List all orders
        // GET: api/Orders
        [Route("api/orders")]
        [HttpGet]
        public ActionResult<IEnumerable<Order>> GetOrders()
        {
            try
            {
                return Ok(OrderRepository.GetOrders());
            }
            catch
            {
                //TODO: Log exception
                return StatusCode(500); //Internal Server Error
            }
        }

        // List all orders for a given date
        // GET: api/Orders/date/10102019
        [Route("api/orders/date/{orderDate}")]
        [HttpGet]
        public ActionResult<Order> GetOrderByDate(string orderDate)
        {
            try
            {
                var order = OrderRepository.GetOrdersByDate(orderDate);
                if (order == null)
                {
                    return NotFound();
                }
                return Ok(order);
            }
            catch (Exception e)
            {
                //TODO: Log exception
                return StatusCode(500); //Internal Server Error
            }
        }

        // retrieve an order by id
        // GET: api/Orders/5
        [Route("api/orders/{id}")]
        [HttpGet]
        public ActionResult<Order> GetOrderById(int id)
        {
            try
            {
                var order = OrderRepository.GetOrderById(id);
                if (order == null)
                {
                    return NotFound();
                }
                return Ok(order);
            }
            catch (Exception e)
            {
                //TODO: Log exception
                return StatusCode(500); //Internal Server Error
            }
        }

        // retrieve an order by a customer
        // GET: api/Orders/Bob
        [Route("api/orders/CustomerName/{customerName}")]
        [HttpGet]
        public ActionResult<Order> GetOrderByCustomer(string customerName)
        {
            try
            {
                var order = OrderRepository.GetOrdersByCustomer(customerName);
                if (order == null)
                {
                    return NotFound();
                }
                return Ok(order);
            }
            catch (Exception e)
            {
                //TODO: Log exception
                return StatusCode(500); //Internal Server Error
            }
        }
    }
}
