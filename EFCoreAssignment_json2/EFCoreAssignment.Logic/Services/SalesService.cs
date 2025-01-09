using EFCoreAssignment.DataAccess.Repositories;
using EFCoreAssignment.DataAccess;

namespace EFCoreAssignment.Logic
{
    public class SalesService
    {
        private readonly SalesRepository _salesRepository;

        public SalesService(SalesRepository salesRepository)
        {
            _salesRepository = salesRepository;
        }

        public async Task<IEnumerable<Sales>> GetAllSalesAsync()
        {
            return await _salesRepository.GetAllAsync();
        }

        public async Task<Sales> GetSaleByIdAsync(int id)
        {
            var sale = await _salesRepository.GetByIdAsync(id);
            if (sale == null)
            {
                throw new KeyNotFoundException($"Sale with ID {id} not found.");
            }
            return sale;
        }

        public async Task<Sales> CreateSaleAsync(Sales sale)
        {
            if (sale == null)
            {
                throw new ArgumentNullException(nameof(sale), "Sale cannot be null.");
            }

            await _salesRepository.AddAsync(sale);
            return sale;
        }

        public async Task<Sales> UpdateSaleAsync(int id, Sales updatedSale)
        {
            var existingSale = await _salesRepository.GetByIdAsync(id);
            if (existingSale == null)
            {
                throw new KeyNotFoundException($"Sale with ID {id} not found.");
            }

            existingSale.Quantity = updatedSale.Quantity;
            existingSale.TotalPrice = updatedSale.TotalPrice;

            _salesRepository.Update(existingSale);
            return existingSale;
        }

        public async Task DeleteSaleAsync(int id)
        {
            var sale = await _salesRepository.GetByIdAsync(id);
            if (sale == null)
            {
                throw new KeyNotFoundException($"Sale with ID {id} not found.");
            }

            _salesRepository.Remove(sale);
        }
    }
}
