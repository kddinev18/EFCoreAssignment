using System.ComponentModel.DataAnnotations;

namespace EFCoreAssignment.DataAccess.Data.Models;

public class Product
{
    [StringLength(50)]
    public string Name { get; set; } = null!;

    [Required]
    public decimal Price { get; set; }

    [Required] 
    public int Stock { get; set; }

    [StringLength(500)]
    public string Description { get; set; } = null!;
    
    [Required]
    public int CategoryId { get; set; }
    public virtual Category Category { get; set; } = null!;
}