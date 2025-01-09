using EFCoreAssignment.DataAccess.Data.Models;
using EFCoreAssignment.DataAccess.Repository;
using EFCoreAssignment.Domain.DTOs.Request;
using EFCoreAssignment.Domain.DTOs.Response;
using EFCoreAssignment.Infrastructure.Contracts;

namespace EFCoreAssignment.Infrastructure.Services;

public class ProductService : IProductService
{
    private readonly ProductRepository _productRepository;
    private readonly ICategoryService _categoryService;

    public ProductService(ProductRepository productRepository, ICategoryService categoryService)
    {
        _productRepository = productRepository;
        _categoryService = categoryService;
    }
    
    public ProductResponseDTO GetProduct(int id)
    {
        var product = _productRepository.GetById(id).First();

        var category = _categoryService.GetCategory(product.CategoryId);

        return new ProductResponseDTO
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Stock = product.Stock,
            Description = product.Description,
            Category = category
        };
    }

    public List<ProductResponseDTO> GetAllProducts()  
    {
        var products = _productRepository.GetAll().ToList();

        return products
        .Select(product => new ProductResponseDTO
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Stock = product.Stock,
            Description = product.Description,
            Category = _categoryService.GetCategory(product.CategoryId)
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