namespace Task.Domain.DTO
{
    public class AssignmentDTO
    {
        public int AssignmentId { get; set; }
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }
        public decimal HoursWorked { get; set; }
        public string Role { get; set; }
    }
}