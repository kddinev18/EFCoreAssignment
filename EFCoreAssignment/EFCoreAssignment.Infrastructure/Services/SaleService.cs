using EFCoreAssignment.DataAccess.Data.Models;
using EFCoreAssignment.DataAccess.Repository;
using EFCoreAssignment.Domain.DTOs.Request;
using EFCoreAssignment.Domain.DTOs.Response;
using EFCoreAssignment.Infrastructure.Contracts;

namespace EFCoreAssignment.Infrastructure.Services;

public class SaleService : ISaleService
{
    private readonly SaleRepository _saleRepository;

    SaleService(SaleRepository saleRepository)
    {
        _saleRepository = saleRepository;
    }
    
    public SaleResponseDTO GetSale(int id)
    {
        return _saleRepository.GetById(id)
            .Select(sale => new SaleResponseDTO
            {
                Id = sale.Id,
                Quantity = sale.Quantity,
                SaleDate = sale.SaleDate,
                TotalPrice = sale.TotalPrice,
                Customer = sale.Customer,
                Product = sale.Product
            }).First();
    }

    public List<SaleResponseDTO> GetAllSales()  
    {
        return _saleRepository.GetAll()
        .Select(sale => new SaleResponseDTO
        {
            Id = sale.Id,
            Quantity = sale.Quantity,
            SaleDate = sale.SaleDate,
            TotalPrice = sale.TotalPrice,
            Customer = sale.Customer,
            Product = sale.Product
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