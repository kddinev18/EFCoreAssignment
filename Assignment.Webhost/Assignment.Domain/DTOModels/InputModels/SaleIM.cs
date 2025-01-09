using System;
using System.ComponentModel.DataAnnotations;

namespace Assignment.Domain.DTOModels.InputModels
{
    public class SaleIm
    {
        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public DateTime SaleDate { get; set; }

        [Required]
        public float TotalPrice { get; set; }
    }
}