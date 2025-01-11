using System.ComponentModel.DataAnnotations;

namespace EFCoreAssignment.Domain.Models.Product;

public class ResponseProduct : CreateProduct
{
    [Required]
    public int Id { get; set; }
}
