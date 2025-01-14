using EFCoreAssignment.DataAccess;
using EFCoreAssignment.DataAccess.Data.Models;
using EFCoreAssignment.DataAccess.Data;
using EFCoreAssignment.Domain.DTOs.Request;
using EFCoreAssignment.Domain.DTOs.Response;
using EFCoreAssignment.Infrastructure.Contracts;
using Microsoft.EntityFrameworkCore;

namespace EFCoreAssignment.Infrastructure.Services;

public class SaleService : ISaleService
{
    private readonly ApplicationDbContext _context;

    public SaleService(ApplicationDbContext context)
    {
        _context = context;
    }

    public SaleResponseDTO GetSale(int id)
    {
        var sale = _context.Sales
            .AsNoTracking()
            .FirstOrDefault(s => s.Id == id);

        if (sale == null) return null;

        return new SaleResponseDTO
        {
            Id = sale.Id,
            CustomerId = sale.CustomerId,
            ProductId = sale.ProductId,
            Quantity = sale.Quantity,
            SaleDate = sale.SaleDate,
            TotalPrice = sale.TotalPrice
        };
    }

    public List<SaleResponseDTO> GetAllSales()
    {
        return _context.Sales
            .AsNoTracking()
            .Select(s => new SaleResponseDTO
            {
                Id = s.Id,
                CustomerId = s.CustomerId,
                ProductId = s.ProductId,
                Quantity = s.Quantity,
                SaleDate = s.SaleDate,
                TotalPrice = s.TotalPrice
            })
            .ToList();
    }

    public bool InsertSale(SaleRequestDTO entity)
    {
        var sale = new Sale
        {
            CustomerId = entity.CustomerId,
            ProductId = entity.ProductId,
            Quantity = entity.Quantity,
            SaleDate = entity.SaleDate,
            TotalPrice = entity.TotalPrice
        };

        _context.Sales.Add(sale);
        return _context.SaveChanges() > 0;
    }

    public bool UpdateSale(SaleRequestDTO entity)
    {
        var sale = _context.Sales.FirstOrDefault(s => s.Id == entity.Id);
        if (sale == null) return false;

        sale.CustomerId = entity.CustomerId;
        sale.ProductId = entity.ProductId;
        sale.Quantity = entity.Quantity;
        sale.SaleDate = entity.SaleDate;
        sale.TotalPrice = entity.TotalPrice;

        _context.Sales.Update(sale);
        return _context.SaveChanges() > 0;
    }

    public bool DeleteSale(int id)
    {
        var sale = _context.Sales.FirstOrDefault(s => s.Id == id);
        if (sale == null) return false;

        _context.Sales.Remove(sale);
        return _context.SaveChanges() > 0;
    }
}
