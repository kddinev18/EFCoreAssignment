using System.ComponentModel.DataAnnotations;

namespace EFCoreAssignment.DataAccess.Data.Models;

public class Category : IBaseModel
{
    [Key]
    public int Id { get; set; }
    
    [StringLength(50)]
    public string Name { get; set; } = null!;

    [StringLength(200)]
    public string Description { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}