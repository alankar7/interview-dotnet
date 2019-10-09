using GroceryStore.Data;
using GroceryStore.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace GroceryStoreAPI.Controllers
{
    [ApiController]
    public class ProductsController : ControllerBase
    {
        // list all products
        // GET: api/Products
        [Route("api/products")]
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            try
            {
                return Ok(ProductRepository.GetProducts());
            }
            catch
            {
                //TODO: Log exception
                return StatusCode(500); //Internal Server Error
            }
        }

        // retrieve a product by id
        // GET: api/Products/5
        [Route("api/products/{id}")]
        [HttpGet]
        public ActionResult<Product> GetProductById(int id)
        {
            try
            {
                var product = ProductRepository.GetProductById(id);
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            catch (Exception e)
            {
                //TODO: Log exception
                return StatusCode(500); //Internal Server Error
            }
        }

        // POST: api/Products
        [HttpPost]
        public ActionResult AddProduct([FromBody] Product product)
        {
            if (string.IsNullOrWhiteSpace(product.description))
            {
                return BadRequest();
            }
            int productId = ProductRepository.AddProduct(product);
            var newProduct = new Product()
            {
                id = productId,
                description = product.description,
                price = product.price
            };
            return CreatedAtAction(nameof(GetProductById), new { id = productId }, newProduct);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public ActionResult UpdateProduct([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            ProductRepository.UpdateProduct(product);
            return NoContent();
        }
    }
}
