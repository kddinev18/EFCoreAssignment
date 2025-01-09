using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace EFCoreAssignment.DTOs
{
    public class ProductDTO
    {
        [JsonRequired]
        [MinLength(3)]
        public string Name { get; set; } = null!;

        [JsonRequired]
        [MinLength(3)]
        public string Category { get; set; } = null!;

        [JsonRequired]
        public decimal Price { get; set; }

        [JsonRequired]
        public int Stock { get; set; }
    }
}
