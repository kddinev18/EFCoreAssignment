using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreAssignment.DataAccess.Models;

public class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProductId { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public string Category { get; set; } = null!;

    [Required]
    public float Price { get; set; }
    
    [Required]
    public int Stock { get; set; }
}