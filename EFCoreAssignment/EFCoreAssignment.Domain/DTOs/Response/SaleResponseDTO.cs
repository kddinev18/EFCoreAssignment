namespace EFCoreAssignment.Domain.DTOs.Response;

public class SaleResponseDTO
{
    public int Id { get; set; }
    
    public int Quantity { get; set; }
    
    public DateTime SaleDate { get; set; }
    
    public decimal TotalPrice { get; set; }

    public CustomerResponseDTO Customer { get; set; } = null!;

    public ProductResponseDTO Product { get; set; } = null!;
}