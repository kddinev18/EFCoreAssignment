using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace json2_assignment.DM.Models;

public class Sale
{
    public int SaleId { get; set; }
    public int CustomerId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public DateTime SaleDate { get; set; }
    public decimal TotalPrice { get; set; }
    public virtual Customer Customer { get; set; }
    public virtual Product Product { get; set; }
}