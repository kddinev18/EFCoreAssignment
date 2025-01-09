using EFCoreAssignment.DataAccess.Repositories;
using EFCoreAssignment.DataAccess;

namespace EFCoreAssignment.Logic
{
    public class CustomersService
    {
        private readonly CustomersRepository _customersRepository;

        public CustomersService(CustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }

        public async Task<IEnumerable<Customers>> GetAllCustomersAsync()
        {
            return await _customersRepository.GetAllAsync();
        }

        public async Task<Customers> GetCustomerByIdAsync(int id)
        {
            var customer = await _customersRepository.GetByIdAsync(id);
            if (customer == null)
            {
                throw new KeyNotFoundException($"Customer with ID {id} not found.");
            }
            return customer;
        }

        public async Task<Customers> CreateCustomerAsync(Customers customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer), "Customer cannot be null.");
            }

            await _customersRepository.AddAsync(customer);
            return customer;
        }

        public async Task<Customers> UpdateCustomerAsync(int id, Customers updatedCustomer)
        {
            var existingCustomer = await _customersRepository.GetByIdAsync(id);
            if (existingCustomer == null)
            {
                throw new KeyNotFoundException($"Customer with ID {id} not found.");
            }

            existingCustomer.Name = updatedCustomer.Name;
            existingCustomer.Email = updatedCustomer.Email;
            existingCustomer.PhoneNumber = updatedCustomer.PhoneNumber;
            existingCustomer.Address = updatedCustomer.Address;
            existingCustomer.DateRegistered = updatedCustomer.DateRegistered;

            _customersRepository.Update(existingCustomer);
            return existingCustomer;
        }

        public async Task DeleteCustomerAsync(int id)
        {
            var customer = await _customersRepository.GetByIdAsync(id);
            if (customer == null)
            {
                throw new KeyNotFoundException($"Customer with ID {id} not found.");
            }

            _customersRepository.Remove(customer);
        }
    }
}
