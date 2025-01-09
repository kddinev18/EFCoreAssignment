namespace EFCoreAssignment.Domain.DTOs.Request;

public class CategoryRequestDTO
{
    public int Id { get; set; }
    
    public string Name { get; set; } = null!;
    
    public string Description { get; set; } = null!;
}