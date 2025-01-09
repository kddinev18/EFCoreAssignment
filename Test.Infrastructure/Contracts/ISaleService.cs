using System.Collections.Generic;
using System.Threading.Tasks;
using Test.Data.Models;

namespace Test.Infrastructure.Contracts;

public interface ISaleService
{
    Task<IEnumerable<Sale>> GetAllSalesAsync();
    Task<Sale> GetSaleByIdAsync(int id);
    Task<Sale> CreateSaleAsync(Sale sale);
    Task<Sale> UpdateSaleAsync(int id, Sale sale);
    Task<bool> DeleteSaleAsync(int id);
}