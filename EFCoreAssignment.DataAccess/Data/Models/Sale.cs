using System.ComponentModel.DataAnnotations;

namespace EFCoreAssignment.DataAccess.Data.Models;

public class Sale : IBaseModel
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public int Quantity { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime SaleDate { get; set; }

    [Required] 
    public decimal TotalPrice { get; set; }
    
    [Required]
    public int CustomerId { get; set; }
    public virtual Customer Customer { get; set; } = null!;
    
    [Required]
    public int ProductId { get; set; }
    public virtual Product Product { get; set; } = null!;
}