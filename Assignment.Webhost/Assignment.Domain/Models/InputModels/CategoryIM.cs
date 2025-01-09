using System.ComponentModel.DataAnnotations;

namespace Assignment.Domain.Models.InputModels
{
    public class CategoryIm
    {
        [Required]
        public string? Name { get; set; }
        
        [Required]
        public string? Description { get; set; }
    }
}