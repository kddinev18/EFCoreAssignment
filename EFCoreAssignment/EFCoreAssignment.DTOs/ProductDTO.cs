using System.Text.Json.Serialization;

namespace EFCoreAssignment.DTOs
{
    public class ProductDTO
    {
        [JsonRequired]
        public string Name { get; set; } = null!;

        [JsonRequired]
        public string Category { get; set; } = null!;

        [JsonRequired]
        public decimal Price { get; set; }

        [JsonRequired]
        public int Stock { get; set; }
    }
}
