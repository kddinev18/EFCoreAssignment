using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.DataAccess.Models
{
    public class Sale
    {
        [Key]
        public int SaleId { get; set; }

        [ForeignKey(nameof(Customer))]
        [Required]
        public int CustomerId { get; set; }

        [ForeignKey(nameof(Product))]
        [Required]
        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public DateTime SaleDate { get; set; }

        [Required]
        public float TotalPrice { get; set; }

        public Customer? Customer { get; set; }
        public Product? Product { get; set; }
    }
}