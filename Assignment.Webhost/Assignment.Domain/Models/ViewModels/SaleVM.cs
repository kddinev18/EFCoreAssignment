﻿namespace Assignment.Domain.Models.ViewModels
{
    public class SaleVm
    {
        public int SaleId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime SaleDate { get; set; }
        public float TotalPrice { get; set; }
    }
}