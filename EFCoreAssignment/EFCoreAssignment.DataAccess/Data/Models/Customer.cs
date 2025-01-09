using System.ComponentModel.DataAnnotations;

namespace EFCoreAssignment.DataAccess.Data.Models;

public class Customer : IBaseModel
{
    [Key]
    public int Id { get; set; }
    
    [StringLength(50)]
    public string Name { get; set; } = null!;

    [EmailAddress]
    public string Email { get; set; } = null!;

    [Phone] 
    public string PhoneNumber { get; set; } = null!;

    [StringLength(200)]
    public string Address { get; set; } = null!;

    [Required]
    [DataType(DataType.Date)]
    public DateTime DateRegistered { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}