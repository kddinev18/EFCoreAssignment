﻿namespace Assignment.Domain.Models.ViewModels
{
    public class CustomerVm
    {
        public int CustomerId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public DateTime DateRegistered { get; set; }
    }
}