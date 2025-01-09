using AutoMapper;
using json2_assignment.Domain.DTOs;
using json2_assignment.DM.Models;
using json2_assignment.DM.Models.Interfaces;

namespace json2_assignment.Domain.Services;

public class CustomerService : ICustomerService
{
    private readonly IRepository<Customer> _customerRepository;
    private readonly IMapper _mapper;

    public CustomerService(IRepository<Customer> customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CustomerDto>> GetAllCustomersAsync()
    {
        var customers = await _customerRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<CustomerDto>>(customers);
    }

    public async Task<CustomerDto> GetCustomerByIdAsync(int id)
    {
        var customer = await _customerRepository.GetByIdAsync(id);
        return _mapper.Map<CustomerDto>(customer);
    }

    public async Task<CustomerDto> CreateCustomerAsync(CustomerDto customerDto)
    {
        var customer = _mapper.Map<Customer>(customerDto);
        await _customerRepository.AddAsync(customer);
        return _mapper.Map<CustomerDto>(customer);
    }

    public async Task UpdateCustomerAsync(CustomerDto customerDto)
    {
        var customer = _mapper.Map<Customer>(customerDto);
        await _customerRepository.UpdateAsync(customer);
    }

    public async Task DeleteCustomerAsync(int id)
    {
        var customer = await _customerRepository.GetByIdAsync(id);
        if (customer != null)
        {
            await _customerRepository.DeleteAsync(customer);
        }
    }
}