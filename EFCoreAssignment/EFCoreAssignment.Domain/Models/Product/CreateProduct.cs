using System.ComponentModel.DataAnnotations;

namespace EFCoreAssignment.Domain.Models.Product;

public class CreateProduct
{
    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public string Category { get; set; } = null!;

    [Required]
    public float Price { get; set; }
    
    [Required]
    public int Stock { get; set; }
}
