using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EFCoreAssignment.DataAccess.Repositories;
using EFCoreAssignment.DataAccess;

namespace EFCoreAssignment.Logic
{
    public class ProductsService
    {
        private readonly ProductsRepository _productsRepository;

        public ProductsService(ProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task<IEnumerable<Products>> GetAllProductsAsync()
        {
            return await _productsRepository.GetAllAsync();
        }

        public async Task<Products> GetProductByIdAsync(int id)
        {
            var product = await _productsRepository.GetByIdAsync(id);
            if (product == null)
            {
                throw new KeyNotFoundException($"Product with ID {id} not found.");
            }
            return product;
        }

        public async Task<Products> CreateProductAsync(Products product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product), "Product cannot be null.");
            }

            await _productsRepository.AddAsync(product);
            return product;
        }

        public async Task<Products> UpdateProductAsync(int id, Products updatedProduct)
        {
            var existingProduct = await _productsRepository.GetByIdAsync(id);
            if (existingProduct == null)
            {
                throw new KeyNotFoundException($"Product with ID {id} not found.");
            }

            existingProduct.Name = updatedProduct.Name;
            existingProduct.Description = updatedProduct.Description;
            existingProduct.Price = updatedProduct.Price;
            existingProduct.Stock = updatedProduct.Stock;

            _productsRepository.Update(existingProduct);
            return existingProduct;
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _productsRepository.GetByIdAsync(id);
            if (product == null)
            {
                throw new KeyNotFoundException($"Product with ID {id} not found.");
            }

            _productsRepository.Remove(product);
        }
    }
}
