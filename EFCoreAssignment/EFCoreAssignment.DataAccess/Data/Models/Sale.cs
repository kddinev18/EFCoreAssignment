using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
    [Precision(7,2)]
    public decimal TotalPrice { get; set; }
    
    [Required]
    public int CustomerId { get; set; }

    [ForeignKey(nameof(CustomerId))]
    public virtual Customer Customer { get; set; } = null!;
    
    [Required]
    public int ProductId { get; set; }

    [ForeignKey(nameof(ProductId))]
    public virtual Product Product { get; set; } = null!;
}