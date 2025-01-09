using json2_assignment.Domain.DTOs;

namespace json2_assignment.Domain.Services;

public interface ISaleService
{
    Task<IEnumerable<SaleDto>> GetAllSalesAsync();
    Task<SaleDto> GetSaleByIdAsync(int id);
    Task<SaleDto> CreateSaleAsync(SaleDto saleDto);
    Task UpdateSaleAsync(SaleDto saleDto);
    Task DeleteSaleAsync(int id);
    Task<IEnumerable<SaleDto>> GetSalesByCustomerAsync(int customerId);
}