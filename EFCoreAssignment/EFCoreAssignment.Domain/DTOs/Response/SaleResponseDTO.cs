using EFCoreAssignment.DataAccess.Data.Models;

namespace EFCoreAssignment.Domain.DTOs.Response;

public class SaleResponseDTO
{
    public int Id { get; set; }
    
    public int Quantity { get; set; }
    
    public DateTime SaleDate { get; set; }
    
    public decimal TotalPrice { get; set; }

    public Customer Customer { get; set; } = null!;

    public Product Product { get; set; } = null!;
}