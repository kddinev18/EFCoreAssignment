using Assignment.Domain.Models.ViewModels;
using Assignment.Domain.Models.InputModels;
using Assignment.Domain.Models.UpdateModels;

namespace Assignment.Infrastructure.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<ProductVm>> GetAllAsync();
        Task<ProductVm?> GetByIdAsync(int id);
        Task<ProductVm> CreateAsync(ProductIm inputModel);
        Task<ProductVm> UpdateAsync(int id, ProductUm updateModel);
        Task<bool> DeleteAsync(int id);
    }
}