using System.ComponentModel.DataAnnotations;

namespace EveryMatrix.Application.DTOs
{
    public class CustomerDto
    {
        [Required]
        [MinLength(1)]
        [MaxLength(30)]
        public string FirstName { get; set; } = null!;
        [Required]
        [MinLength(1)]
        [MaxLength(30)]
        public string LastName { get; set; } = null!;
        [Required]
        [Phone] 
        [MinLength(1)]
        [MaxLength(15)]
        public string PhoneNumber { get; set; } = null!;
        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [MinLength(1)]
        [MaxLength(30)]
        public string Email { get; set; } = null!;
        [StringLength(40)]
        public string? Address { get; set; }
    }
}
