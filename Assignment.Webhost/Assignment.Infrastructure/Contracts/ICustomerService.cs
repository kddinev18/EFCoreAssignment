using Assignment.Domain.Models.ViewModels;
using Assignment.Domain.Models.InputModels;
using Assignment.Domain.Models.UpdateModels;

namespace Assignment.Infrastructure.Contracts
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerVm>> GetAllAsync();
        Task<CustomerVm?> GetByIdAsync(int id);
        Task<CustomerVm> CreateAsync(CustomerIm inputModel);
        Task<CustomerVm> UpdateAsync(int id, CustomerUm updateModel);
        Task<bool> DeleteAsync(int id);
    }
}