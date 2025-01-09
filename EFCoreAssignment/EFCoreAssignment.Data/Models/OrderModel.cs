using EFCoreAssignment.Data.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EFCoreAssignment.Data.Models
{
    public class Order : IBaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }
        public virtual User User { get; set; } = null!;

        [Required]
        public DateOnly DateCreated { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalAmount { get; set; }

        [Required]
        public string Status { get; set; } = null!;

        [JsonIgnore]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = null!;
    }
}
