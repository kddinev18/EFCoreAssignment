using System.Text.Json.Serialization;

namespace EFCoreAssignment.DTOs
{
    public class OrderDetailDTO
    {
        [JsonRequired]
        public int OrderId { get; set; }

        [JsonRequired]
        public int ProductId { get; set; }

        [JsonRequired]
        public int Quantity { get; set; }

        [JsonRequired]
        public decimal PricePerUnit { get; set; }
    }
}
