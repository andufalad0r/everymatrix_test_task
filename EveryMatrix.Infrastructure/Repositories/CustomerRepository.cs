using EveryMatrix.Application.Repositories;
using EveryMatrixApp.Domain.Entities;
using EveryMatrixApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;

namespace EveryMatrix.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<CustomerRepository> _logger;

        public CustomerRepository(
            AppDbContext dbContext,
            ILogger<CustomerRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            var customers = await _dbContext.Customers
                .AsNoTracking()
                .ToListAsync();

            if(customers.Count == 0)
                _logger.LogWarning("The 'customers' collection in the database is empty.");
            
            return customers;
        }

        public async Task AddAsync(Customer customer)
        {
            await _dbContext.Customers.AddAsync(customer);
            await _dbContext.SaveChangesAsync();

            _logger.LogInformation($"New customer with Id: {customer.CustomerId} was succesfully created.", customer);
        }

        public async Task DeleteAsync(ObjectId customerId)
        {
            var customer = await _dbContext.Customers.FirstOrDefaultAsync(customer => customer.CustomerId == customerId);
            if (customer == null)
            {
                _logger.LogWarning($"Customer with Id: {customerId} was not found.", customerId);

                return;
            }
            _dbContext.Customers.Remove(customer);
            await _dbContext.SaveChangesAsync();

            _logger.LogInformation($"Customer with Id: {customerId} was succesfully deleted.", customerId);
        }
    }
}
