namespace Test.Domain.Models.Sale;

public class SaleUM
{
    public int SaleId { get; set; }
    public int CustomerId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public DateTime SaleDate { get; set; }
}