using System.ComponentModel.DataAnnotations;

namespace Assignment.Domain.Models.InputModels
{
    public class ProductIm
    {
        [Required]
        public int CategoryId { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        public int Stock { get; set; }

        [Required]
        public string? Description { get; set; }
    }
}