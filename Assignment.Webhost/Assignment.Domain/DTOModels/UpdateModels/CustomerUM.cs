using System.ComponentModel.DataAnnotations;

namespace Assignment.Domain.DTOModels.UpdateModels
{
    public class CustomerUm
    {
        public string? Name { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Address { get; set; }
    }
}