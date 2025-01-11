using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreAssignment.DataAccess.Models;

public class User : BaseEntity
{
    [Required]
    public string FirstName { get; set; } = null!;

    [Required]
    public string LastName { get; set; } = null!;

    [Required]
    public string Email { get; set; } = null!;
    
    [Required]
    public DateTime DateCreated { get; set; } = DateTime.Now;
}