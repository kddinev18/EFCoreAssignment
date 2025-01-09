using EFCoreAssignment.Data.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreAssignment.Data.Models
{
    public class User : IBaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; } = null!;

        [Required]
        public string LastName { get; set; } = null!;

        [Required]
        public string Email { get; set; } = null!;

        [Required]
        public DateOnly DateCreatead { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        public ICollection<Order> Orders { get; set; } = null!;

    }
}
