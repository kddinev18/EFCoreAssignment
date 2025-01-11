using System.ComponentModel.DataAnnotations;

namespace EFCoreAssignment.Domain.Models.OrderDetail;

public class CreateOrderDetail
{
    [Required]
    public int OrderId { get; set; }
    
    [Required]
    public int ProductId { get; set; }
    
    [Required]
    public int Quantity { get; set; }
    
    [Required]
    public float PricePerUnit { get; set; }
}
