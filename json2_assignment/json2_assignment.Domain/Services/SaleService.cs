using AutoMapper;
using json2_assignment.DM.Models;
using json2_assignment.DM.Models.Interfaces;
using json2_assignment.Domain.DTOs;

namespace json2_assignment.Domain.Services;

public class SaleService : ISaleService
{
    private readonly IRepository<Sale> _saleRepository;
    private readonly IMapper _mapper;

    public SaleService(IRepository<Sale> saleRepository, IMapper mapper)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<SaleDto>> GetAllSalesAsync()
    {
        var sales = await _saleRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<SaleDto>>(sales);
    }

    public async Task<SaleDto> GetSaleByIdAsync(int id)
    {
        var sale = await _saleRepository.GetByIdAsync(id);
        return _mapper.Map<SaleDto>(sale);
    }

    public async Task<SaleDto> CreateSaleAsync(SaleDto saleDto)
    {
        var sale = _mapper.Map<Sale>(saleDto);
        await _saleRepository.AddAsync(sale);
        return _mapper.Map<SaleDto>(sale);
    }

    public async Task UpdateSaleAsync(SaleDto saleDto)
    {
        var sale = _mapper.Map<Sale>(saleDto);
        await _saleRepository.UpdateAsync(sale);
    }

    public async Task DeleteSaleAsync(int id)
    {
        var sale = await _saleRepository.GetByIdAsync(id);
        if (sale != null)
        {
            await _saleRepository.DeleteAsync(sale);
        }
    }

    public async Task<IEnumerable<SaleDto>> GetSalesByCustomerAsync(int customerId)
    {
        var sales = await _saleRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<SaleDto>>(sales.Where(s => s.CustomerId == customerId));
    }
}