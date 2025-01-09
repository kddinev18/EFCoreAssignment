namespace EFCoreAssignment.Domain.DTOs.Request;

public class CustomerRequestDTO
{ 
    public int Id { get; set; }
    
    public string Name { get; set; } = null!;
    
    public string Email { get; set; } = null!;
    
    public string PhoneNumber { get; set; } = null!;
    
    public string Address { get; set; } = null!;
    
    public DateTime DateRegistered { get; set; }
}