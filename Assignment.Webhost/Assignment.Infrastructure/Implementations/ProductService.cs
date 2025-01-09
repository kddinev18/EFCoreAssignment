using Assignment.DataAccess.Data;
using Assignment.DataAccess.Models;
using Assignment.Domain.Models.InputModels;
using Assignment.Domain.Models.UpdateModels;
using Assignment.Domain.Models.ViewModels;
using Assignment.Infrastructure.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Infrastructure.Implementations
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductVm>> GetAllAsync()
        {
            return await _context.Products
                .Select(p => new ProductVm
                {
                    ProductId = p.ProductId,
                    CategoryId = p.CategoryId,
                    Name = p.Name,
                    Price = p.Price,
                    Stock = p.Stock,
                    Description = p.Description
                })
                .ToListAsync();
        }

        public async Task<ProductVm?> GetByIdAsync(int id)
        {
            return await _context.Products
                .Where(p => p.ProductId == id)
                .Select(p => new ProductVm
                {
                    ProductId = p.ProductId,
                    CategoryId = p.CategoryId,
                    Name = p.Name,
                    Price = p.Price,
                    Stock = p.Stock,
                    Description = p.Description
                })
                .FirstOrDefaultAsync();
        }

        public async Task<ProductVm> CreateAsync(ProductIm inputModel)
        {
            var product = new Product
            {
                CategoryId = inputModel.CategoryId,
                Name = inputModel.Name,
                Price = inputModel.Price,
                Stock = inputModel.Stock,
                Description = inputModel.Description
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return new ProductVm
            {
                ProductId = product.ProductId,
                CategoryId = product.CategoryId,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock,
                Description = product.Description
            };
        }

        public async Task<ProductVm> UpdateAsync(int id, ProductUm updateModel)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                throw new KeyNotFoundException("Product not found");
            }

            product.CategoryId = updateModel.CategoryId;
            product.Name = updateModel.Name;
            product.Price = updateModel.Price;
            product.Stock = updateModel.Stock;
            product.Description = updateModel.Description;

            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return new ProductVm
            {
                ProductId = product.ProductId,
                CategoryId = product.CategoryId,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock,
                Description = product.Description
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return false;
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}