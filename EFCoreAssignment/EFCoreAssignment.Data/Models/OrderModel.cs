using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreAssignment.Data.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        [Required]
        public DateOnly DateCreated { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalAmount { get; set; }

        [Required]
        public string Status { get; set; } = null!;

        public ICollection<OrderDetail> OrderDetails { get; set; } = null!;
    }
}
