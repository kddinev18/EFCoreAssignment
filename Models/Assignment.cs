using System;
using System.ComponentModel.DataAnnotations;

namespace YourNamespace.Models
{
    public class Assignment
    {
        [Key]
        public int AssignmentId { get; set; }

        [Required(ErrorMessage = "EmployeeId is required")]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "ProjectId is required")]
        public int ProjectId { get; set; }

        [Required(ErrorMessage = "Hours Worked is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Hours Worked must be greater than zero")]
        public int HoursWorked { get; set; }

        [Required(ErrorMessage = "Role is required")]
        [StringLength(50, ErrorMessage = "Role cannot exceed 50 characters")]
        public string Role { get; set; }
    }
}