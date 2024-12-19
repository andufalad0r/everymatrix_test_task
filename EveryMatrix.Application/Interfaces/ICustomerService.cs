using EveryMatrix.Application.DTOs;
using EveryMatrixApp.Domain.Entities;
using MongoDB.Bson;

namespace EveryMatrix.Application.Interfaces
{
    public interface ICustomerService
    {
        public Task<List<Customer>> GetAllAsync();
        public Task AddAsync(CustomerDto customer);
        public Task DeleteAsync(ObjectId id);
    }
}
