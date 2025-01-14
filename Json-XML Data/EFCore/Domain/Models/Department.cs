﻿namespace Domain.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public decimal Budget { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}