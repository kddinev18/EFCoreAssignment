using EFCoreAssignment.Domain.DTOs.Request;
using EFCoreAssignment.Domain.DTOs.Response;

namespace EFCoreAssignment.Infrastructure.Contracts;

public interface IProductService
{   
    public ProductResponseDTO GetProduct(int id);

    public List<ProductResponseDTO> GetAllProducts();
    
    public bool InsertProduct(ProductRequestDTO entity);

    public bool UpdateProduct(ProductRequestDTO entity);
    
    public bool DeleteProduct(int id);
}