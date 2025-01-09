using System.Collections.Generic;
using System.Threading.Tasks;
using Test.Data.Models;
using Test.Domain.Models.Sale;

namespace Test.Infrastructure.Contracts;

public interface ISaleService
{
    Task<IEnumerable<SaleVM>> GetAllSalesAsync();
    Task<SaleVM> GetSaleByIdAsync(int id);
    Task<SaleVM> CreateSaleAsync(SaleIM saleInputModel);
    Task<SaleVM> UpdateSaleAsync(int id, SaleUM saleUpdateModel);
    Task<bool> DeleteSaleAsync(int id);
}