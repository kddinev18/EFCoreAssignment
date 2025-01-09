using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace json2_assignment.DM.Models;

public class Product
{
    public int ProductId { get; set; }
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string Description { get; set; }
    public virtual Category Category { get; set; }
    public virtual ICollection<Sale> Sales { get; set; }
}