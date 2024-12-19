using EveryMatrix.Application.DTOs;

namespace EveryMatrixApp.Presentation.Models
{
    public class CustomerViewModel
    {
        public CustomerDto CustomerDto { get; set; } = new();
        public bool IsValid { get; set; } = true;
        public bool IsSaved { get; set; } = false;
        public string? Message { get; set; } = "";
    }
}
