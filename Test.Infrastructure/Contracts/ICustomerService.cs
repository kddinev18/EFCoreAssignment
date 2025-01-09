using System.Collections.Generic;
using System.Threading.Tasks;
using Test.Data.Models;
using Test.Domain.Models.Category;
using Test.Domain.Models.Customer;

namespace Test.Infrastructure.Contracts;

public interface ICustomerService
{
    Task<IEnumerable<CustomerVM>> GetAllCustomersAsync();
    Task<CustomerVM> GetCustomerByIdAsync(int id);
    Task<CustomerVM> CreateCustomerAsync(CustomerIM customerInputModel);
    Task<CustomerVM> UpdateCustomerAsync(int id, CustomerUM customerUpdateModel);
    Task<bool> DeleteCustomerAsync(int id);
}
