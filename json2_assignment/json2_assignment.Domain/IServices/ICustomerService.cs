using json2_assignment.Domain.DTOs;

namespace json2_assignment.Domain.Services;

public interface ICustomerService
{
    Task<IEnumerable<CustomerDto>> GetAllCustomersAsync();
    Task<CustomerDto> GetCustomerByIdAsync(int id);
    Task<CustomerDto> CreateCustomerAsync(CustomerDto customerDto);
    Task UpdateCustomerAsync(CustomerDto customerDto);
    Task DeleteCustomerAsync(int id);
}