using System.ComponentModel.DataAnnotations;

namespace EfCoreTest.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public double TotalAmount { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; }
    }
}