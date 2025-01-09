using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace EFCoreAssignment.DTOs
{
    public class OrderDTO
    {
        [JsonRequired]
        public int UserId { get; set; }

        [JsonRequired]
        public decimal TotalAmount { get; set; }

        [JsonRequired]
        [MinLength(3)]
        public string Status { get; set; } = null!;
    }
}
