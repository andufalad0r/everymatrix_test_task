using EveryMatrix.Application.DTOs;
using EveryMatrixApp.Domain.Entities;

namespace EveryMatrix.Application.Mapper
{
    internal static class Mapper
    {
        public static Customer FromDtoToEntity(this CustomerDto customerDto)
        {
            return new Customer
            {
                FirstName = customerDto.FirstName,
                LastName = customerDto.LastName,
                Email = customerDto.Email,
                PhoneNumber = customerDto.PhoneNumber,
                Address = customerDto.Address,
            };
        }
    }
}
