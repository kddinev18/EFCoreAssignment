using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreAssignment.DataAccess.Models;

public class OrderDetail
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int OrderDetailId { get; set; }
    
    [Required]
    public int OrderId { get; set; }
    
    [Required]
    public int ProductId { get; set; }
    
    [Required]
    public int Quantity { get; set; }
    
    [Required]
    public float PricePerUnit { get; set; }

    [Required]
    [ForeignKey(nameof(OrderId))]
    public Order Order { get; set; } = null!;

    [Required]
    [ForeignKey(nameof(ProductId))]
    public Order Product { get; set; } = null!;
}