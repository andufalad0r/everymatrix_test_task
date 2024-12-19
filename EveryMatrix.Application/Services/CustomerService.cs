using EveryMatrix.Application.DTOs;
using EveryMatrix.Application.Interfaces;
using EveryMatrix.Application.Mapper;
using EveryMatrix.Application.Repositories;
using EveryMatrixApp.Domain.Entities;
using MongoDB.Bson;

namespace EveryMatrix.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(
            ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            return await _customerRepository.GetAllAsync();
        }

        public async Task AddAsync(CustomerDto customerDto)
        {
            var customer = customerDto.FromDtoToEntity();
            await _customerRepository.AddAsync(customer);
        }

        public async Task DeleteAsync(ObjectId customerId)
        {
            await _customerRepository.DeleteAsync(customerId);
        }
    }
}
