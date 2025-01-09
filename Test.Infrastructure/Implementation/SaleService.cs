using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Test.Data.Data;
using Test.Data.Models;
using Test.Infrastructure.Contracts;

namespace Test.Infrastructure.Implementation;

public class SaleService : ISaleService
{
    private readonly ApplicationDbContext _context;

    public SaleService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Sale>> GetAllSalesAsync()
    {
        return await _context.Sales
            .Include(s => s.Customer)
            .Include(s => s.Product)
            .ToListAsync();
    }

    public async Task<Sale> GetSaleByIdAsync(int id)
    {
        return await _context.Sales
            .Include(s => s.Customer)
            .Include(s => s.Product)
            .FirstOrDefaultAsync(s => s.SaleId == id);
    }

    public async Task<Sale> CreateSaleAsync(Sale sale)
    {
        _context.Sales.Add(sale);
        await _context.SaveChangesAsync();
        return sale;
    }

    public async Task<Sale> UpdateSaleAsync(int id, Sale sale)
    {
        var existingSale = await _context.Sales.FindAsync(id);
        if (existingSale == null) return null;

        existingSale.CustomerId = sale.CustomerId;
        existingSale.ProductId = sale.ProductId;
        existingSale.Quantity = sale.Quantity;
        existingSale.SaleDate = sale.SaleDate;
        existingSale.TotalPrice = sale.TotalPrice;

        await _context.SaveChangesAsync();
        return existingSale;
    }

    public async Task<bool> DeleteSaleAsync(int id)
    {
        var sale = await _context.Sales.FindAsync(id);
        if (sale == null) return false;

        _context.Sales.Remove(sale);
        await _context.SaveChangesAsync();
        return true;
    }
}