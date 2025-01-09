using EFCoreAssignment.DataAccess.Data.Models;
using EFCoreAssignment.DataAccess.Repository;
using EFCoreAssignment.Domain.DTOs.Request;
using EFCoreAssignment.Domain.DTOs.Response;
using EFCoreAssignment.Infrastructure.Contracts;

namespace EFCoreAssignment.Infrastructure.Services;

public class ProductService : IProductService
{
    private readonly ProductRepository _productRepository;

    ProductService(ProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    
    public ProductResponseDTO GetProduct(int id)
    {
        return _productRepository.GetById(id)
        .Select(product => new ProductResponseDTO
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Stock = product.Stock,
            Description = product.Description,
            Category = product.Category,
        }).First();
    }

    public List<ProductResponseDTO> GetAllProducts()  
    {
        return _productRepository.GetAll()
        .Select(product => new ProductResponseDTO
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Stock = product.Stock,
            Description = product.Description,
            Category = product.Category,
        }).ToList();
    }

    public bool InsertProduct(ProductRequestDTO entity)
    {
        return _productRepository.Add(new Product()
        {
            Name = entity.Name,
            Price = entity.Price,
            Stock = entity.Stock,
            Description = entity.Description,
            CategoryId = entity.CategoryId,
        });
    }

    public bool UpdateProduct(ProductRequestDTO entity)
    {
        return _productRepository.Update(new Product()
        {
            Id = entity.Id,
            Name = entity.Name,
            Price = entity.Price,
            Stock = entity.Stock,
            Description = entity.Description,
            CategoryId = entity.CategoryId,
        });
    }

    public bool DeleteProduct(int id)
    {
        return _productRepository.Delete(id);
    }
}