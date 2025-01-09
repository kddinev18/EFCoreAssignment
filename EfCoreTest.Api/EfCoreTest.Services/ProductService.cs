using EfCoreTest.DataAccess;
using EfCoreTest.Models;

namespace EfCoreTest.Services
{
    public class ProductService
    {
        private readonly JsonDataAccess _dataAccess;
        private readonly string _dataKey = "Products";

        public ProductService(JsonDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public List<Product> GetAllProducts()
        {
            var data = _dataAccess.ReadData<Dictionary<string, List<Product>>>();
            return data?[_dataKey] ?? new List<Product>();
        }

        public Product? GetProductById(int id)
        {
            return GetAllProducts().FirstOrDefault(p => p.ProductId == id);
        }

        public Product AddProduct(Product newProduct)
        {
            var products = GetAllProducts();
            newProduct.ProductId = products.Any() ? products.Max(p => p.ProductId) + 1 : 1;
            products.Add(newProduct);

            SaveProducts(products);
            return newProduct;
        }

        public bool UpdateProduct(int id, Product updatedProduct)
        {
            var products = GetAllProducts();
            var existingProduct = products.FirstOrDefault(p => p.ProductId == id);
            if (existingProduct == null)
                return false;

            existingProduct.Name = updatedProduct.Name;
            existingProduct.Category = updatedProduct.Category;
            existingProduct.Price = updatedProduct.Price;
            existingProduct.Stock = updatedProduct.Stock;

            SaveProducts(products);
            return true;
        }

        public bool DeleteProduct(int id)
        {
            var products = GetAllProducts();
            var productToRemove = products.FirstOrDefault(p => p.ProductId == id);
            if (productToRemove == null)
                return false;

            products.Remove(productToRemove);
            SaveProducts(products);
            return true;
        }

        private void SaveProducts(List<Product> products)
        {
            var data = _dataAccess.ReadData<Dictionary<string, object>>() ?? new Dictionary<string, object>();
            data[_dataKey] = products;
            _dataAccess.WriteData(data);
        }
    }
}
