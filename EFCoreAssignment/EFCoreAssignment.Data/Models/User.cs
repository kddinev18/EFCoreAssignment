using System.ComponentModel.DataAnnotations;

namespace EFCoreAssignment.Data.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; } = null!;

        [Required]
        public string LastName { get; set; } = null!;

        [Required]
        public string Email { get; set; } = null!;

        [Required]
        public DateOnly DateCreatead { get; set; } = DateOnly.FromDateTime(DateTime.Now);

    }
}
