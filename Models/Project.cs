using System;
using System.ComponentModel.DataAnnotations;

namespace YourNamespace.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Start Date is required")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End Date is required")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Budget is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Budget must be greater than zero")]
        public decimal Budget { get; set; }
    }
}