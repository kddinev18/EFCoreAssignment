namespace EFCoreAssignment.Domain.DTOs.Response;

public class CustomerResponseDTO
{
    public int Id { get; set; }
    
    public string Name { get; set; } = null!;
    
    public string Email { get; set; } = null!;
    
    public string PhoneNumber { get; set; } = null!;
    
    public string Address { get; set; } = null!;
}