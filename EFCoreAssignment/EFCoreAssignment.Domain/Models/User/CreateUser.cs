using System.ComponentModel.DataAnnotations;

namespace EFCoreAssignment.Domain.Models.User;

public class CreateUser
{
    [Required]
    public string FirstName { get; set; } = null!;

    [Required]
    public string LastName { get; set; } = null!;

    [Required]
    public string Email { get; set; } = null!;
}
