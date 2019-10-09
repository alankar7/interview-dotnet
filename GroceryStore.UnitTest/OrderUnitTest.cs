using AutoFixture;
using GroceryStore.Data;
using GroceryStoreAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Xunit;

namespace GroceryStore.UnitTest
{
    public class OrderUnitTest
    {
        public OrdersController controller;

        public OrderUnitTest()
        {
            controller = new OrdersController();
        }

        [Fact]
        public void GetWhenCalledReturnsOkResult()
        {
            var okResult = controller.GetOrders();
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void GetWhenCalledReturnsAllItems()
        {
            var okResult = controller.GetOrders().Result as OkObjectResult;
            var items = Assert.IsType<List<Order>>(okResult.Value);
            Assert.NotEmpty(items);
        }

        [Fact]
        public void GetByIdWhenExistingIdPassedReturnsOkResult()
        {
            int testId = 1;
            var okResult = controller.GetOrderById(testId);
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void GetByIdWhenExistingIdPassedReturnsCorrectItem()
        {
            var testId = 1;
            var okResult = controller.GetOrderById(testId).Result as OkObjectResult;
            Assert.IsType<Order>(okResult.Value);
            Assert.Equal(testId, (okResult.Value as Order).id);
        }

        [Fact]
        public void GetByCustomerWhenExistingCustomerPassedReturnsOkResult()
        {
            string customerName = "Bob";
            var okResult = controller.GetOrderByCustomer(customerName);
            Assert.IsType<OkObjectResult>(okResult.Result);
        }
    }
}
