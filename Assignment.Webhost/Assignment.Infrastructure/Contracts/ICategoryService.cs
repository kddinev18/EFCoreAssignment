using Assignment.Domain.Models.ViewModels;
using Assignment.Domain.Models.InputModels;
using Assignment.Domain.Models.UpdateModels;

namespace Assignment.Infrastructure.Contracts
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryVm>> GetAllAsync();
        Task<CategoryVm?> GetByIdAsync(int id);
        Task<CategoryVm> CreateAsync(CategoryIm inputModel);
        Task<CategoryVm> UpdateAsync(int id, CategoryUm updateModel);
        Task<bool> DeleteAsync(int id);
    }
}