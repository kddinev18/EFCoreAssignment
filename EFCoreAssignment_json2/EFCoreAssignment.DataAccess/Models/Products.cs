namespace EFCoreAssignment.DataAccess;

public class Products
{
    public int ProductId { get; set; }
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string Description { get; set; }
}