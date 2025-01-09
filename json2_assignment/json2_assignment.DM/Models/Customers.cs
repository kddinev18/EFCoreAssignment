using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace json2_assignment.DM.Models;

public class Customer : IBaseModel
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Phone]
    public string PhoneNumber { get; set; }

    [Required]
    [StringLength(200)]
    public string Address { get; set; }

    [Required]
    public DateTime DateRegistered { get; set; }
}