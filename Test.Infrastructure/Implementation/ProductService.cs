using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Test.Data.Data;
using Test.Domain.Models.Product;
using Test.Infrastructure.Contracts;

namespace Test.Infrastructure.Implementation;

public class ProductService : IProductService
{
    private readonly ApplicationDbContext _context;

    public ProductService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ProductVM>> GetAllProductsAsync()
    {
        return await _context.Products
            .Include(p => p.Category)
            .Select(product => new ProductVM
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock,
                Description = product.Description,
                CategoryName = product.Category.Name
            })
            .ToListAsync();
    }

    public async Task<ProductVM> GetProductByIdAsync(int id)
    {
        var product = await _context.Products
            .Include(p => p.Category)
            .FirstOrDefaultAsync(p => p.ProductId == id);

        if (product == null) return null;

        return new ProductVM
        {
            ProductId = product.ProductId,
            Name = product.Name,
            Price = product.Price,
            Stock = product.Stock,
            Description = product.Description,
            CategoryName = product.Category.Name
        };
    }

    public async Task<ProductVM> CreateProductAsync(ProductIM productInputModel)
    {
        var product = new Test.Data.Models.Product
        {
            Name = productInputModel.Name,
            Price = productInputModel.Price,
            Stock = productInputModel.Stock,
            Description = productInputModel.Description,
            CategoryId = productInputModel.CategoryId
        };

        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        return new ProductVM
        {
            ProductId = product.ProductId,
            Name = product.Name,
            Price = product.Price,
            Stock = product.Stock,
            Description = product.Description,
            CategoryName = product.Category.Name
        };
    }

    public async Task<ProductVM> UpdateProductAsync(int id, ProductUM productUpdateModel)
    {
        var existingProduct = await _context.Products.FindAsync(id);
        if (existingProduct == null) return null;

        existingProduct.Name = productUpdateModel.Name;
        existingProduct.Price = productUpdateModel.Price;
        existingProduct.Stock = productUpdateModel.Stock;
        existingProduct.Description = productUpdateModel.Description;
        existingProduct.CategoryId = productUpdateModel.CategoryId;

        await _context.SaveChangesAsync();

        return new ProductVM
        {
            ProductId = existingProduct.ProductId,
            Name = existingProduct.Name,
            Price = existingProduct.Price,
            Stock = existingProduct.Stock,
            Description = existingProduct.Description,
            CategoryName = existingProduct.Category.Name
        };
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null) return false;

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return true;
    }
}
