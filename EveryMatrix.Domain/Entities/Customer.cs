using MongoDB.Bson;
using MongoDB.EntityFrameworkCore;

namespace EveryMatrixApp.Domain.Entities
{
    [Collection("customers")]
    public class Customer
    {
        public ObjectId CustomerId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Address { get; set; }
    }
}
