using AutoMapper;
using json2_assignment.DM.Models;
using json2_assignment.DM.Models.Interfaces;
using json2_assignment.Domain.DTOs;

namespace json2_assignment.Domain.Services;

public class ProductService : IProductService
{
    private readonly IRepository<Product> _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IRepository<Product> productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
    {
        var products = await _productRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<ProductDto>>(products);
    }

    public async Task<ProductDto> GetProductByIdAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        return _mapper.Map<ProductDto>(product);
    }

    public async Task<ProductDto> CreateProductAsync(ProductDto productDto)
    {
        var product = _mapper.Map<Product>(productDto);
        await _productRepository.AddAsync(product);
        return _mapper.Map<ProductDto>(product);
    }

    public async Task UpdateProductAsync(ProductDto productDto)
    {
        var product = _mapper.Map<Product>(productDto);
        await _productRepository.UpdateAsync(product);
    }

    public async Task DeleteProductAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product != null)
        {
            await _productRepository.DeleteAsync(product);
        }
    }

    public async Task<IEnumerable<ProductDto>> GetProductsByCategoryAsync(int categoryId)
    {
        var products = await _productRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<ProductDto>>(products.Where(p => p.CategoryId == categoryId));
    }
}