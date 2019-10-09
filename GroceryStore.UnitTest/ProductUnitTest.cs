using AutoFixture;
using GroceryStore.Data;
using GroceryStoreAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Xunit;

namespace GroceryStore.UnitTest
{
    public class ProductUnitTest
    {
        public ProductsController controller;

        public ProductUnitTest()
        {
            controller = new ProductsController();
        }

        [Fact]
        public void GetWhenCalledReturnsOkResult()
        {
            var okResult = controller.GetProducts();
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void GetWhenCalledReturnsAllItems()
        {
            var okResult = controller.GetProducts().Result as OkObjectResult;
            var items = Assert.IsType<List<Product>>(okResult.Value);
            Assert.NotEmpty(items);
        }

        [Fact]
        public void GetByIdWhenExistingIdPassedReturnsOkResult()
        {
            int testId = 1;
            var okResult = controller.GetProductById(testId);
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void GetByIdWhenExistingIdPassedReturnsCorrectItem()
        {
            var testId = 1;
            var okResult = controller.GetProductById(testId).Result as OkObjectResult;
            Assert.IsType<Product>(okResult.Value);
            Assert.Equal(testId, (okResult.Value as Product).id);
        }

        [Fact]
        public void AddWhenValidObjectPassedReturnsCreatedResponse()
        {
            var fixture = new Fixture();
            Product product = fixture.Create<Product>();
            var createdResponse = controller.AddProduct(product);
            Assert.IsType<CreatedAtActionResult>(createdResponse);
        }

        [Fact]
        public void AddWhenValidObjectPassedReturnedResponseHasCreatedItem()
        {
            var fixture = new Fixture();
            Product product = fixture.Create<Product>();
            var createdResponse = controller.AddProduct(product) as CreatedAtActionResult;
            var newProduct = createdResponse.Value as Product;
            Assert.IsType<Product>(newProduct);
            Assert.Equal(product.id, newProduct.id);
        }

        [Fact]
        public void UpdateWhenInvalidObjectPassedReturnedBadRequestResponse()
        {
            var updatedResponse = controller.UpdateProduct(null);
            Assert.IsType<BadRequestResult>(updatedResponse);
        }

        [Fact]
        public void UpdateWhenValidObjectPassedReturnedResponseNoContent()
        {
            var fixture = new Fixture();
            var product = fixture.Create<Product>();
            product.id = 1;
            var updatedResponse = controller.UpdateProduct(product);
            Assert.IsType<NoContentResult>(updatedResponse);
        }
    }
}
