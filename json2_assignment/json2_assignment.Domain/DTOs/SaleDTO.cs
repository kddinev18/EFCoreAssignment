namespace json2_assignment.Domain.DTOs;

public class SaleDto
{
    public int SaleId { get; set; }
    public int CustomerId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public DateTime SaleDate { get; set; }
    public decimal TotalPrice { get; set; }
}