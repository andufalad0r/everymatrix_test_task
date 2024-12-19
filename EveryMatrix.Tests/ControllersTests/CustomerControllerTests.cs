using EveryMatrix.Application.Interfaces;
using EveryMatrixApp.Presentation.Controllers;
using Moq;
using Microsoft.AspNetCore.Mvc;
using EveryMatrixApp.Domain.Entities;

namespace EveryMatrix.Tests.ControllersTests
{
    public class CustomerControllerTests
    {
        [Fact]
        public async Task GetAll_ReturnsAllCustomers()
        {
            // Arrange
            var _customerServiceMock = new Mock<ICustomerService>();
            _customerServiceMock
                .Setup(_customerService => _customerService.GetAllAsync())
                .ReturnsAsync(TestData.Customers());

            var _customerController = new CustomerController(_customerServiceMock.Object);

            // Act
            var result = await _customerController.GetAll();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<Customer>>(
                viewResult.ViewData.Model);
            Assert.Equal(3, model.Count());
        }

        [Fact]
        public async Task Add_InvalidCustomerDto_CustomerIsntAdded()
        {
            // Arrange
            var _customerServiceMock = new Mock<ICustomerService>();

            var _customerController = new CustomerController(_customerServiceMock.Object);

            var customerViewModel = TestData.ValidCustomerViewModel();
            customerViewModel.CustomerDto = TestData.InvalidCustomerDto();

            // Act
            _customerController.ModelState.AddModelError("PhoneNumber", "Invalid PhoneNumber");
            var result = await _customerController.Add(customerViewModel);

            // Assert
            Assert.False(customerViewModel.IsValid);
            Assert.False(customerViewModel.IsSaved);
            Assert.Equal("Invalid input", customerViewModel.Message);
        }

        [Fact]
        public async Task Add_ValidCustomerDto_CustomerIsAdded()
        {
            // Arrange
            var _customerServiceMock = new Mock<ICustomerService>();

            var _customerController = new CustomerController(_customerServiceMock.Object);

            var customerViewModel = TestData.ValidCustomerViewModel();
            customerViewModel.CustomerDto = TestData.CustomerDto();

            // Act
            var result = await _customerController.Add(customerViewModel);

            // Assert
            Assert.True(customerViewModel.IsSaved);
            Assert.True(customerViewModel.IsValid);
            Assert.Equal("Customer is added to collection", customerViewModel.Message);
            Assert.Equal("Nazar", customerViewModel.CustomerDto.FirstName);
            Assert.Equal("Trukhan", customerViewModel.CustomerDto.LastName);
            Assert.Equal("email1@gmail.com", customerViewModel.CustomerDto.Email);
            Assert.Equal("0965097987", customerViewModel.CustomerDto.PhoneNumber);
            Assert.Equal("Ukraine, Lviv", customerViewModel.CustomerDto.Address);
        }
    }
}
