using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace json2_assignment.DAL.Models;

public class Sale
{
    [Key]
    public int SaleId { get; set; }

    [ForeignKey("Customer")]
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }

    [ForeignKey("Product")]
    public int ProductId { get; set; }
    public Product Product { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int Quantity { get; set; }

    [Required]
    public DateTime SaleDate { get; set; }

    [Required]
    [Range(0.01, double.MaxValue)]
    public decimal TotalPrice { get; set; }
}