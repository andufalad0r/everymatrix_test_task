using EveryMatrix.Application.DTOs;
using EveryMatrixApp.Domain.Entities;
using EveryMatrixApp.Presentation.Models;
using MongoDB.Bson;

namespace EveryMatrix.Tests
{
    internal static class TestData
    {
        public static Customer Customer()
        {
            return new Customer
            {
                CustomerId = ObjectId.GenerateNewId(),
                FirstName = "Nazar",
                LastName = "Trukhan",
                Email = "email1@gmail.com",
                PhoneNumber = "0965097987",
                Address = "Ukraine, Lviv"
            };
        }

        public static List<Customer> Customers()
        {
            return new List<Customer>
            {
                new Customer
                {
                    CustomerId = ObjectId.GenerateNewId(),
                    FirstName = "Nazar",
                    LastName = "Trukhan",
                    Email = "email1@gmail.com",
                    PhoneNumber = "0965097987",
                    Address = "Ukraine, Lviv"
                },
                new Customer
                {
                    CustomerId = ObjectId.GenerateNewId(),
                    FirstName = "Oleh",
                    LastName = "Makar",
                    Email = "email2@gmail.com",
                    PhoneNumber = "0965097987",
                    Address = "Ukraine, Kyiv"
                },
                new Customer
                {
                    CustomerId = ObjectId.GenerateNewId(),
                    FirstName = "Olena",
                    LastName = "Mukha",
                    Email = "email3@gmail.com",
                    PhoneNumber = "0965045324",
                    Address = "Ukraine, Kharkiv"
                }
            };
        }

        public static CustomerViewModel ValidCustomerViewModel() => new CustomerViewModel();

        public static CustomerDto CustomerDto()
        {
            return new CustomerDto
            {
                FirstName = "Nazar",
                LastName = "Trukhan",
                Email = "email1@gmail.com",
                PhoneNumber = "0965097987",
                Address = "Ukraine, Lviv"
            };
        }

        public static CustomerDto InvalidCustomerDto()
        {
            return new CustomerDto
            {
                FirstName = "Nazar",
                LastName = "Trukhan",
                Email = "email1@gmail.com",
                PhoneNumber = "gdfgdfgfsdghfdsfdsfsg",
                Address = "Ukraine, Lviv"
            };
        }
    }
}
