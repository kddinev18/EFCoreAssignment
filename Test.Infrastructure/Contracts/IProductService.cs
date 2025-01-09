using System.Collections.Generic;
using System.Threading.Tasks;
using Test.Data.Models;
using Test.Domain.Models.Product;

namespace Test.Infrastructure.Contracts;

public interface IProductService
{
    Task<IEnumerable<ProductVM>> GetAllProductsAsync();
    Task<ProductVM> GetProductByIdAsync(int id);
    Task<ProductVM> CreateProductAsync(ProductIM productInputModel);
    Task<ProductVM> UpdateProductAsync(int id, ProductUM productUpdateModel);
    Task<bool> DeleteProductAsync(int id);
}