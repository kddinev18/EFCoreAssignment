using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreAssignment.DataAccess.Data.Models;

public class Product : IBaseModel
{
    [Key]
    public int Id { get; set; }
    
    [StringLength(50)]
    public string Name { get; set; } = null!;

    [Required]
    [Precision(7,2)]
    public decimal Price { get; set; }

    [Required] 
    public int Stock { get; set; }

    [StringLength(500)]
    public string Description { get; set; } = null!;
    
    [Required]
    public int CategoryId { get; set; }

    [ForeignKey(nameof(CategoryId))]
    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}