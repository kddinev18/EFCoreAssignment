using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Test.Data.Data;
using Test.Data.Models;
using Test.Domain.Models.Customer;
using Test.Infrastructure.Contracts;

namespace Test.Infrastructure.Implementation;

public class CustomerService : ICustomerService
{
    private readonly ApplicationDbContext _context;

    public CustomerService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<CustomerVM>> GetAllCustomersAsync()
    {
        return await _context.Customers
            .Select(customer => new CustomerVM
            {
                CustomerId = customer.CustomerId,
                Name = customer.Name,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                Address = customer.Address,
                DateRegistered = customer.DateRegistered
            })
            .ToListAsync();
    }

    public async Task<CustomerVM> GetCustomerByIdAsync(int id)
    {
        var customer = await _context.Customers.FindAsync(id);
        if (customer == null) return null;

        return new CustomerVM
        {
            CustomerId = customer.CustomerId,
            Name = customer.Name,
            Email = customer.Email,
            PhoneNumber = customer.PhoneNumber,
            Address = customer.Address,
            DateRegistered = customer.DateRegistered
        };
    }

    public async Task<CustomerVM> CreateCustomerAsync(CustomerIM customerInputModel)
    {
        var customer = new Customer
        {
            Name = customerInputModel.Name,
            Email = customerInputModel.Email,
            PhoneNumber = customerInputModel.PhoneNumber,
            Address = customerInputModel.Address,
        };

        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();

        return new CustomerVM
        {
            CustomerId = customer.CustomerId,
            Name = customer.Name,
            Email = customer.Email,
            PhoneNumber = customer.PhoneNumber,
            Address = customer.Address,
            DateRegistered = customer.DateRegistered
        };
    }

    public async Task<CustomerVM> UpdateCustomerAsync(int id, CustomerUM customerUpdateModel)
    {
        var existingCustomer = await _context.Customers.FindAsync(id);
        if (existingCustomer == null) return null;

        existingCustomer.Name = customerUpdateModel.Name;
        existingCustomer.Email = customerUpdateModel.Email;
        existingCustomer.PhoneNumber = customerUpdateModel.PhoneNumber;
        existingCustomer.Address = customerUpdateModel.Address;

        await _context.SaveChangesAsync();

        return new CustomerVM
        {
            CustomerId = existingCustomer.CustomerId,
            Name = existingCustomer.Name,
            Email = existingCustomer.Email,
            PhoneNumber = existingCustomer.PhoneNumber,
            Address = existingCustomer.Address,
            DateRegistered = existingCustomer.DateRegistered
        };
    }

    public async Task<bool> DeleteCustomerAsync(int id)
    {
        var customer = await _context.Customers.FindAsync(id);
        if (customer == null) return false;

        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();
        return true;
    }
}
