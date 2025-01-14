using EfCoreTest.DataAccess;
using EfCoreTest.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EfCoreTest.Services
{
    public class ProductService
    {
        private readonly AppDbContext _context;

        public ProductService()
        {
            _context = new AppDbContext(new DbContextOptions<AppDbContext>());
        }

        public List<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.ProductId == id);
        }

        public Product AddProduct(Product newProduct)
        {
            _context.Products.Add(newProduct);
            _context.SaveChanges();
            return newProduct;
        }

        public bool UpdateProduct(int id, Product updatedProduct)
        {
            var existingProduct = _context.Products.FirstOrDefault(p => p.ProductId == id);
            if (existingProduct == null)
                return false;

            existingProduct.Name = updatedProduct.Name;
            existingProduct.Price = updatedProduct.Price;

            _context.SaveChanges();
            return true;
        }

        public bool DeleteProduct(int id)
        {
            var productToRemove = _context.Products.FirstOrDefault(p => p.ProductId == id);
            if (productToRemove == null)
                return false;

            _context.Products.Remove(productToRemove);
            _context.SaveChanges();
            return true;
        }
    }
}
