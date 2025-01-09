using Assignment.Domain.Models.ViewModels;
using Assignment.Domain.Models.InputModels;
using Assignment.Domain.Models.UpdateModels;

namespace Assignment.Infrastructure.Contracts
{
    public interface ISaleService
    {
        Task<IEnumerable<SaleVm>> GetAllAsync();
        Task<SaleVm?> GetByIdAsync(int id);
        Task<SaleVm> CreateAsync(SaleIm inputModel);
        Task<SaleVm> UpdateAsync(int id, SaleUm updateModel);
        Task<bool> DeleteAsync(int id);
    }
}