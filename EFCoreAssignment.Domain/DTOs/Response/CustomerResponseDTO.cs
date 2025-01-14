namespace EFCoreAssignment.Domain.DTOs.Response;

public class CustomerResponseDTO
{
    public int Id { get; set; }
    
    public string Name { get; set; } = null!;
    
    public string Email { get; set; } = null!;
    
    public string Phone { get; set; } = null!;
    
    public string Address { get; set; } = null!;
    
    public DateTime DateRegistered { get; set; }
}