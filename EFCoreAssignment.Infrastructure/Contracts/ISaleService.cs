using EFCoreAssignment.Domain.DTOs.Request;
using EFCoreAssignment.Domain.DTOs.Response;

namespace EFCoreAssignment.Infrastructure.Contracts;

public interface ISaleService
{
    public SaleResponseDTO GetSale(int id);
    
    public List<SaleResponseDTO> GetAllSales();
    
    public bool InsertSale(SaleRequestDTO entity);

    public bool UpdateSale(SaleRequestDTO entity);
    
    public bool DeleteSale(int id);
}