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
    public class SaleService : ISaleService
    {
        private readonly ApplicationDbContext _context;

        public SaleService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SaleVm>> GetAllAsync()
        {
            return await _context.Sales
                .Select(s => new SaleVm
                {
                    SaleId = s.SaleId,
                    CustomerId = s.CustomerId,
                    ProductId = s.ProductId,
                    Quantity = s.Quantity,
                    SaleDate = s.SaleDate,
                    TotalPrice = s.TotalPrice
                })
                .ToListAsync();
        }

        public async Task<SaleVm?> GetByIdAsync(int id)
        {
            return await _context.Sales
                .Where(s => s.SaleId == id)
                .Select(s => new SaleVm
                {
                    SaleId = s.SaleId,
                    CustomerId = s.CustomerId,
                    ProductId = s.ProductId,
                    Quantity = s.Quantity,
                    SaleDate = s.SaleDate,
                    TotalPrice = s.TotalPrice
                })
                .FirstOrDefaultAsync();
        }

        public async Task<SaleVm> CreateAsync(SaleIm inputModel)
        {
            var sale = new Sale
            {
                CustomerId = inputModel.CustomerId,
                ProductId = inputModel.ProductId,
                Quantity = inputModel.Quantity,
                SaleDate = DateTime.UtcNow,
                TotalPrice = inputModel.TotalPrice
            };

            _context.Sales.Add(sale);
            await _context.SaveChangesAsync();

            return new SaleVm
            {
                SaleId = sale.SaleId,
                CustomerId = sale.CustomerId,
                ProductId = sale.ProductId,
                Quantity = sale.Quantity,
                SaleDate = sale.SaleDate,
                TotalPrice = sale.TotalPrice
            };
        }

        public async Task<SaleVm> UpdateAsync(int id, SaleUm updateModel)
        {
            var sale = await _context.Sales.FindAsync(id);
            if (sale == null)
            {
                throw new KeyNotFoundException("Sale not found");
            }

            sale.CustomerId = updateModel.CustomerId;
            sale.ProductId = updateModel.ProductId;
            sale.Quantity = updateModel.Quantity;
            sale.TotalPrice = updateModel.TotalPrice;

            _context.Sales.Update(sale);
            await _context.SaveChangesAsync();

            return new SaleVm
            {
                SaleId = sale.SaleId,
                CustomerId = sale.CustomerId,
                ProductId = sale.ProductId,
                Quantity = sale.Quantity,
                SaleDate = sale.SaleDate,
                TotalPrice = sale.TotalPrice
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var sale = await _context.Sales.FindAsync(id);
            if (sale == null)
            {
                return false;
            }

            _context.Sales.Remove(sale);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}