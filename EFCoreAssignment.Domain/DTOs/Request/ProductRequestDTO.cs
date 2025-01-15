using EFCoreAssignment.DataAccess.Data.Models;

namespace EFCoreAssignment.Domain.DTOs.Request;

public class ProductRequestDTO
{
    public int Id { get; set; }
    
    public string Name { get; set; } = null!;
    
    public decimal Price { get; set; }
    
    public int Stock { get; set; }
    
    public string Description { get; set; } = null!;
    
    public int CategoryId { get; set; }
    public virtual Category Category { get; set; } = null!;
}