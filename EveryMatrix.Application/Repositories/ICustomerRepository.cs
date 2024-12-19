using EveryMatrix.Application.DTOs;
using EveryMatrixApp.Domain.Entities;
using MongoDB.Bson;

namespace EveryMatrix.Application.Repositories
{
    public interface ICustomerRepository
    {
        public Task<List<Customer>> GetAllAsync();
        public Task AddAsync(Customer customer);
        public Task DeleteAsync(ObjectId id);
    }
}
