using System.ComponentModel.DataAnnotations;

namespace Assignment.Domain.DTOModels.UpdateModels
{
    public class ProductUm
    {
        public int CategoryId { get; set; }

        public string? Name { get; set; }

        public float Price { get; set; }

        public int Stock { get; set; }

        public string? Description { get; set; }
    }
}