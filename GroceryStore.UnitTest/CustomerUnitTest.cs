using AutoFixture;
using GroceryStore.Data;
using GroceryStoreAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Xunit;

namespace GroceryStore.UnitTest
{
    public class CustomerUnitTest
    {
        public CustomersController controller;

        public CustomerUnitTest()
        {
            controller = new CustomersController();
        }

        [Fact]
        public void GetWhenCalledReturnsOkResult()
        {
            var okResult = controller.GetCustomers();
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void GetWhenCalledReturnsAllItems()
        {
            var okResult = controller.GetCustomers().Result as OkObjectResult;
            var items = Assert.IsType<List<Customer>>(okResult.Value);
            Assert.NotEmpty(items);
        }

        [Fact]
        public void GetByIdWhenExistingIdPassedReturnsOkResult()
        {
            int testId = 1;
            var okResult = controller.GetCustomerById(testId);
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void GetByIdWhenExistingIdPassedReturnsCorrectItem()
        {
            var testId = 1;
            var okResult = controller.GetCustomerById(testId).Result as OkObjectResult;
            Assert.IsType<Customer>(okResult.Value);
            Assert.Equal(testId, (okResult.Value as Customer).id);
        }

        [Fact]
        public void AddWhenValidObjectPassedReturnsCreatedResponse()
        {
            var fixture = new Fixture();
            string customerName = fixture.Create<string>();
            var createdResponse = controller.AddCustomer(customerName);
            Assert.IsType<CreatedAtActionResult>(createdResponse);
        }

        [Fact]
        public void AddWhenValidObjectPassedReturnedResponseHasCreatedItem()
        {
            var fixture = new Fixture();
            string customerName = fixture.Create<string>();
            var createdResponse = controller.AddCustomer(customerName) as CreatedAtActionResult;
            var newCustomer = createdResponse.Value as Customer;
            Assert.IsType<Customer>(newCustomer);
            Assert.Equal(customerName, newCustomer.name);
        }

        [Fact]
        public void UpdateWhenInvalidObjectPassedReturnedBadRequestResponse()
        {
            var updatedResponse = controller.UpdateCustomer(null);
            Assert.IsType<BadRequestResult>(updatedResponse);
        }

        [Fact]
        public void UpdateWhenValidObjectPassedReturnedResponseNoContent()
        {
            var fixture = new Fixture();
            var customer = fixture.Create<Customer>();
            customer.id = 1;
            var updatedResponse = controller.UpdateCustomer(customer);
            Assert.IsType<NoContentResult>(updatedResponse);
        }
    }
}
