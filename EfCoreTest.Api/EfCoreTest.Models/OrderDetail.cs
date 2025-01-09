using System.ComponentModel.DataAnnotations;

namespace EfCoreTest.Models
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailId { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public double PricePerUnit { get; set; }
    }
}