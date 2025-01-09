using System.ComponentModel.DataAnnotations;

namespace EFCoreAssignment.Domain.Models.User;

public class ResponseUser : CreateUser
{
    [Required]
    public int Id { get; set; }
};
