using Assignment.DataAccess.Data;
using Assignment.DataAccess.Models;
using Assignment.Domain.Models.InputModels;
using Assignment.Domain.Models.UpdateModels;
using Assignment.Domain.Models.ViewModels;
using Assignment.Infrastructure.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Infrastructure.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext _context;

        public CustomerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CustomerVm>> GetAllAsync()
        {
            return await _context.Customers
                .Select(c => new CustomerVm
                {
                    CustomerId = c.CustomerId,
                    Name = c.Name,
                    Email = c.Email,
                    PhoneNumber = c.PhoneNumber,
                    Address = c.Address,
                    DateRegistered = c.DateRegistered
                })
                .ToListAsync();
        }

        public async Task<CustomerVm?> GetByIdAsync(int id)
        {
            return await _context.Customers
                .Where(c => c.CustomerId == id)
                .Select(c => new CustomerVm
                {
                    CustomerId = c.CustomerId,
                    Name = c.Name,
                    Email = c.Email,
                    PhoneNumber = c.PhoneNumber,
                    Address = c.Address,
                    DateRegistered = c.DateRegistered
                })
                .FirstOrDefaultAsync();
        }

        public async Task<CustomerVm> CreateAsync(CustomerIm inputModel)
        {
            var customer = new Customer
            {
                Name = inputModel.Name,
                Email = inputModel.Email,
                PhoneNumber = inputModel.PhoneNumber,
                Address = inputModel.Address,
                DateRegistered = DateTime.UtcNow
            };

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return new CustomerVm
            {
                CustomerId = customer.CustomerId,
                Name = customer.Name,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                Address = customer.Address,
                DateRegistered = customer.DateRegistered
            };
        }

        public async Task<CustomerVm> UpdateAsync(int id, CustomerUm updateModel)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                throw new KeyNotFoundException("Customer not found");
            }

            customer.Name = updateModel.Name;
            customer.Email = updateModel.Email;
            customer.PhoneNumber = updateModel.PhoneNumber;
            customer.Address = updateModel.Address;

            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();

            return new CustomerVm
            {
                CustomerId = customer.CustomerId,
                Name = customer.Name,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                Address = customer.Address,
                DateRegistered = customer.DateRegistered
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return false;
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}