using System;
using System.ComponentModel.DataAnnotations;

namespace Assignment.Domain.DTOModels.UpdateModels
{
    public class SaleUm
    {
        public int CustomerId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public DateTime SaleDate { get; set; }

        public float TotalPrice { get; set; }
    }
}