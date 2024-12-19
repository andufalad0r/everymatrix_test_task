using EveryMatrix.Infrastructure.Repositories;
using EveryMatrixApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;

namespace EveryMatrix.Tests.RepositoriesTests
{
    public class CustomerRepositoryTests
    {

        private readonly DbContextOptions<AppDbContext> _dbContextOptions;
        private readonly Mock<ILogger<CustomerRepository>> _loggerMock;

        public CustomerRepositoryTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _loggerMock = new Mock<ILogger<CustomerRepository>>();
        }

        [Fact]
        public async Task GetAllAsync_Nothing_ReturnsAllImages()
        {
            // Arrange
            using var _dbContext = new AppDbContext(_dbContextOptions);

            var customerRepository = new CustomerRepository(_dbContext, _loggerMock.Object);

            _dbContext.Customers.AddRange(TestData.Customers());
            _dbContext.SaveChanges();

            // Act
            var result = await customerRepository.GetAllAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Count);
            Assert.Contains(result, customer => customer.FirstName == "Nazar");
            Assert.Contains(result, customer => customer.FirstName == "Oleh");
            Assert.Contains(result, customer => customer.FirstName == "Olena");
        }

        [Fact]
        public async Task AddAsync_CustomerEntity_AddsCustomerToDatabase()
        {
            // Arrange
            using var _dbContext = new AppDbContext(_dbContextOptions);

            var customerRepository = new CustomerRepository(_dbContext, _loggerMock.Object);

            // Act
            await customerRepository.AddAsync(TestData.Customer());

            // Assert
            var result = _dbContext.Customers.FirstOrDefault(customer => customer.CustomerId == customer.CustomerId);
            Assert.NotNull(result);
            Assert.Equal("Nazar", result.FirstName);
        }

        [Fact]
        public async Task DeleteAsync_CustomerId_DeletesCustomerFromDatabase()
        {
            // Arrange
            using var _dbContext = new AppDbContext(_dbContextOptions);

            var customerRepository = new CustomerRepository(_dbContext, _loggerMock.Object);

            var customer = TestData.Customer();
            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();

            // Assert 1
            var result = _dbContext.Customers.FirstOrDefault(customer => customer.CustomerId == customer.CustomerId);
            Assert.NotNull(result);

            // Act
            await customerRepository.DeleteAsync(customer.CustomerId);

            // Assert 2
            result = _dbContext.Customers.FirstOrDefault(customer => customer.CustomerId == customer.CustomerId);
            Assert.Null(result);
        }
    }
}