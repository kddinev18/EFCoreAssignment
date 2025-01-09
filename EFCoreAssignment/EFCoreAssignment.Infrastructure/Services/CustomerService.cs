using EFCoreAssignment.DataAccess.Data.Models;
using EFCoreAssignment.DataAccess.Repository;
using EFCoreAssignment.Domain.DTOs.Request;
using EFCoreAssignment.Domain.DTOs.Response;
using EFCoreAssignment.Infrastructure.Contracts;

namespace EFCoreAssignment.Infrastructure.Services;

public class CustomerService : ICustomerService
{
    private readonly CustomerRepository _customerRepository;

    public CustomerService(CustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }
    
    public CustomerResponseDTO GetCustomer(int id)
    {
        return _customerRepository.GetById(id)
            .Select(customer => new CustomerResponseDTO
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                Address = customer.Address,
            }).First();
    }

    public List<CustomerResponseDTO> GetAllCustomers()  
    {
        return _customerRepository.GetAll()
            .Select(customer => new CustomerResponseDTO
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                Address = customer.Address,
            }).ToList();
    }

    public bool InsertCustomer(CustomerRequestDTO entity)
    {
        return _customerRepository.Add(new Customer()
        {
            Name = entity.Name,
            Email = entity.Email,
            PhoneNumber = entity.PhoneNumber,
            Address = entity.Address,
            DateRegistered = entity.DateRegistered
        });
    }

    public bool UpdateCustomer(CustomerRequestDTO entity)
    {
        return _customerRepository.Update(new Customer()
        {
            Id = entity.Id,
            Name = entity.Name,
            Email = entity.Email,
            PhoneNumber = entity.PhoneNumber,
            Address = entity.Address,
            DateRegistered = entity.DateRegistered
        });
    }

    public bool DeleteCustomer(int id)
    {
        return _customerRepository.Delete(id);
    }
}