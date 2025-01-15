using EFCoreAssignment.DataAccess.Data.Models;

namespace EFCoreAssignment.Domain.DTOs.Request;

public class SaleRequestDTO
{
    public int Id { get; set; }
    
    public int Quantity { get; set; }
    
    public DateTime SaleDate { get; set; }
    
    public decimal TotalPrice { get; set; }
    
    public int CustomerId { get; set; }
    public virtual Customer Customer { get; set; } = null!;
    
    public int ProductId { get; set; }
    public virtual Product Product { get; set; } = null!;
}