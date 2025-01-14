using System.ComponentModel.DataAnnotations;

namespace EFCoreAssignment.DataAccess.Data.Models;

public class Customer : IBaseModel
{
    [Key]
    public int Id { get; set; }
    
    [StringLength(50)]
    public string Name { get; set; } = null!;

    [EmailAddress]
    [StringLength(100)]
    public string Email { get; set; } = null!;

    [Phone] 
    [StringLength(50)]
    public string PhoneNumber { get; set; } = null!;

    [StringLength(200)]
    public string Address { get; set; } = null!;

    [Required]
    [DataType(DataType.Date)]
    public DateTime DateRegistered { get; set; }
}