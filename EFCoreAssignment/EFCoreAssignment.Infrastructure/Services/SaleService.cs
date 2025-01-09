using EFCoreAssignment.DataAccess.Data.Models;
using EFCoreAssignment.DataAccess.Repository;
using EFCoreAssignment.Domain.DTOs.Request;
using EFCoreAssignment.Domain.DTOs.Response;
using EFCoreAssignment.Infrastructure.Contracts;

namespace EFCoreAssignment.Infrastructure.Services;

public class SaleService : ISaleService
{
    private readonly SaleRepository _saleRepository;
    private readonly ICustomerService _customerService;
    private readonly IProductService _productService;

    public SaleService(SaleRepository saleRepository, ICustomerService customerService, IProductService productService)
    {
        _saleRepository = saleRepository;
        _customerService = customerService;
        _productService = productService;
    }
    
    public SaleResponseDTO GetSale(int id)
    {
        var sale = _saleRepository.GetById(id).First();
        var customer = _customerService.GetCustomer(sale.CustomerId);
        var product = _productService.GetProduct(sale.ProductId);

        return new SaleResponseDTO
        {
            Id = sale.Id,
            Quantity = sale.Quantity,
            SaleDate = sale.SaleDate,
            TotalPrice = sale.TotalPrice,
            Customer = customer,
            Product = product,
        };
    }

    public List<SaleResponseDTO> GetAllSales()  
    {
        var sale = _saleRepository.GetAll().ToList();

        return sale
        .Select(sale => new SaleResponseDTO
        {
            Id = sale.Id,
            Quantity = sale.Quantity,
            SaleDate = sale.SaleDate,
            TotalPrice = sale.TotalPrice,
            Customer = _customerService.GetCustomer(sale.CustomerId),
            Product = _productService.GetProduct(sale.ProductId),
        }).ToList();
    }

    public bool InsertSale(SaleRequestDTO entity)
    {
        return _saleRepository.Add(new Sale()
        {
            Quantity = entity.Quantity,
            SaleDate = entity.SaleDate,
            TotalPrice = entity.TotalPrice,
            CustomerId = entity.CustomerId,
            ProductId = entity.ProductId
        });
    }

    public bool UpdateSale(SaleRequestDTO entity)
    {
        return _saleRepository.Update(new Sale()
        {
            Id = entity.Id,
            Quantity = entity.Quantity,
            SaleDate = entity.SaleDate,
            TotalPrice = entity.TotalPrice,
            CustomerId = entity.CustomerId,
            ProductId = entity.ProductId
        });
    }

    public bool DeleteSale(int id)
    {
        return _saleRepository.Delete(id);
    }
}