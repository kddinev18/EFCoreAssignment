using EFCoreAssignment.DataAccess;
using EFCoreAssignment.DataAccess.Data.Models;
using EFCoreAssignment.DataAccess.Data;
using EFCoreAssignment.Domain.DTOs.Request;
using EFCoreAssignment.Domain.DTOs.Response;
using EFCoreAssignment.Infrastructure.Contracts;
using Microsoft.EntityFrameworkCore;

namespace EFCoreAssignment.Infrastructure.Services;

public class ProductService : IProductService
{
    private readonly ApplicationDbContext _context;

    public ProductService(ApplicationDbContext context)
    {
        _context = context;
    }

    public ProductResponseDTO GetProduct(int id)
    {
        var product = _context.Products
            .AsNoTracking()
            .FirstOrDefault(p => p.Id == id);

        if (product == null) return null;

        return new ProductResponseDTO
        {
            Id = product.Id,
            CategoryId = product.CategoryId,
            Name = product.Name,
            Price = product.Price,
            Stock = product.Stock,
            Description = product.Description
        };
    }

    public List<ProductResponseDTO> GetAllProducts()
    {
        return _context.Products
            .AsNoTracking()
            .Select(p => new ProductResponseDTO
            {
                Id = p.Id,
                CategoryId = p.CategoryId,
                Name = p.Name,
                Price = p.Price,
                Stock = p.Stock,
                Description = p.Description
            })
            .ToList();
    }

    public bool InsertProduct(ProductRequestDTO entity)
    {
        var product = new Product
        {
            CategoryId = entity.CategoryId,
            Name = entity.Name,
            Price = entity.Price,
            Stock = entity.Stock,
            Description = entity.Description
        };

        _context.Products.Add(product);
        return _context.SaveChanges() > 0;
    }

    public bool UpdateProduct(ProductRequestDTO entity)
    {
        var product = _context.Products.FirstOrDefault(p => p.Id == entity.Id);
        if (product == null)
            throw new KeyNotFoundException($"Product with ID {entity.Id} not found.");

        // Validate the category exists
        if (!_context.Categories.Any(c => c.Id == entity.CategoryId))
            throw new KeyNotFoundException($"Category with ID {entity.CategoryId} does not exist.");

        product.CategoryId = entity.CategoryId;
        product.Name = entity.Name;
        product.Price = entity.Price;
        product.Stock = entity.Stock;
        product.Description = entity.Description;

        _context.Products.Update(product);
        return _context.SaveChanges() > 0;
    }
    public bool DeleteProduct(int id)
    {
        var product = _context.Products.FirstOrDefault(p => p.Id == id);
        if (product == null) return false;

        _context.Products.Remove(product);
        return _context.SaveChanges() > 0;
    }
}