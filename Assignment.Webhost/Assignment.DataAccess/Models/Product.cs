using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.DataAccess.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [ForeignKey(nameof(Category))]
        [Required]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(100)]
        public string? Name { get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        public int Stock { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        public Category? Category { get; set; }
    }
}