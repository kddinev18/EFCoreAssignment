namespace Assignment.Domain.Models.ViewModels
{
    public class ProductVm
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string? Name { get; set; }
        public float Price { get; set; }
        public int Stock { get; set; }
        public string? Description { get; set; }
    }
}