using EFCoreAssignment.Domain.DTOs.Request;
using EFCoreAssignment.Domain.DTOs.Response;

namespace EFCoreAssignment.Infrastructure.Contracts;

public interface ICustomerService
{   
    public CustomerResponseDTO GetCustomer(int id);

    public List<CustomerResponseDTO> GetAllCustomers();
    
    public bool InsertCustomer(CustomerRequestDTO entity);

    public bool UpdateCustomer(CustomerRequestDTO entity);
    
    public bool DeleteCustomer(int id);
}