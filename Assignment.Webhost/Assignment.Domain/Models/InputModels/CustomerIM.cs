using System;
using System.ComponentModel.DataAnnotations;

namespace Assignment.Domain.DTOModels.InputModels
{
    public class CustomerIm
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? PhoneNumber { get; set; }

        [Required]
        public string? Address { get; set; }

        [Required]
        public DateTime DateRegistered { get; set; }
    }
}