using EFCoreAssignment.DataAccess;
using EFCoreAssignment.DataAccess.Data.Models;
using EFCoreAssignment.DataAccess.Data;
using EFCoreAssignment.Domain.DTOs.Request;
using EFCoreAssignment.Domain.DTOs.Response;
using EFCoreAssignment.Infrastructure.Contracts;
using Microsoft.EntityFrameworkCore;

namespace EFCoreAssignment.Infrastructure.Services;

public class CustomerService : ICustomerService
{
    private readonly ApplicationDbContext _context;

    public CustomerService(ApplicationDbContext context)
    {
        _context = context;
    }

    public CustomerResponseDTO GetCustomer(int id)
    {
        var customer = _context.Customers
            .AsNoTracking()
            .FirstOrDefault(c => c.Id == id);

        if (customer == null) return null;

        return new CustomerResponseDTO
        {
            Id = customer.Id,
            Name = customer.Name,
            Email = customer.Email,
            Phone = customer.PhoneNumber,
            Address = customer.Address,
            DateRegistered = customer.DateRegistered
        };
    }

    public List<CustomerResponseDTO> GetAllCustomers()
    {
        return _context.Customers
            .AsNoTracking()
            .Select(c => new CustomerResponseDTO
            {
                Id = c.Id,
                Name = c.Name,
                Email = c.Email,
                Phone = c.PhoneNumber,
                Address = c.Address,
                DateRegistered = c.DateRegistered
            })
            .ToList();
    }

    public bool InsertCustomer(CustomerRequestDTO entity)
    {
        var customer = new Customer
        {
            Name = entity.Name,
            Email = entity.Email,
            PhoneNumber = entity.Phone,
            Address = entity.Address,
            DateRegistered = entity.DateRegistered
        };

        _context.Customers.Add(customer);
        return _context.SaveChanges() > 0;
    }

    public bool UpdateCustomer(CustomerRequestDTO entity)
    {
        var customer = _context.Customers.FirstOrDefault(c => c.Id == entity.Id);
        if (customer == null) return false;

        customer.Name = entity.Name;
        customer.Email = entity.Email;
        customer.PhoneNumber = entity.Phone;
        customer.Address = entity.Address;
        customer.DateRegistered = entity.DateRegistered;

        _context.Customers.Update(customer);
        return _context.SaveChanges() > 0;
    }

    public bool DeleteCustomer(int id)
    {
        var customer = _context.Customers.FirstOrDefault(c => c.Id == id);
        if (customer == null) return false;

        _context.Customers.Remove(customer);
        return _context.SaveChanges() > 0;
    }
}
