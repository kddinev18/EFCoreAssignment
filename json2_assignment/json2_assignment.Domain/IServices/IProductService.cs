using json2_assignment.Domain.DTOs;

namespace json2_assignment.Domain.Services;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetAllProductsAsync();
    Task<ProductDto> GetProductByIdAsync(int id);
    Task<ProductDto> CreateProductAsync(ProductDto productDto);
    Task UpdateProductAsync(ProductDto productDto);
    Task DeleteProductAsync(int id);
    Task<IEnumerable<ProductDto>> GetProductsByCategoryAsync(int categoryId);
}