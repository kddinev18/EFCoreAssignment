namespace Domain.Models
{
    public class Assignment
    {
        public int AssignmentId { get; set; }
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }
        public int HoursWorked { get; set; }
        public string Role { get; set; }

        
        public Employee Employee { get; set; }
        public Project Project { get; set; }
    }
}