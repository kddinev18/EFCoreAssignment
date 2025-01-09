using System.Text.Json.Serialization;

namespace EFCoreAssignment.DTOs
{
    public class OrderDTO
    {
        [JsonRequired]
        public int UserId { get; set; }

        [JsonRequired]
        public decimal TotalAmount { get; set; }

        [JsonRequired]
        public string Status { get; set; } = null!;
    }
}
