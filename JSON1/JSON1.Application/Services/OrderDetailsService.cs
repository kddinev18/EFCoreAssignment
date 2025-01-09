using JSON1.Application.Services.Persistance;
using JSON1.Domain.Entities;
using JSON1.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON1.Application.Services
{
    public class OrderDetailsService : IOrderDetailsService
    {
        private readonly IOrderDetailsRepository _OrderDetailsRepository;

        public OrderDetailsService(IOrderDetailsRepository OrderDetailsRepository)
        {
            _OrderDetailsRepository = OrderDetailsRepository;
        }

        public async Task<IEnumerable<OrderDetails>> GetAllOrderDetailsAsync()
        {
            return await _OrderDetailsRepository.GetAllAsync();
        }

        public async Task<OrderDetails> GetOrderDetailsByIdAsync(int id)
        {
            return await _OrderDetailsRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<OrderDetails>> GetOrderDetailsByOrderIdAsync(int orderId)
        {
            return await _OrderDetailsRepository.GetByOrderIdAsync(orderId);
        }

        public async Task AddOrderDetailsAsync(OrderDetails OrderDetails)
        {
            await _OrderDetailsRepository.AddAsync(OrderDetails);
        }

        public async Task UpdateOrderDetailsAsync(OrderDetails OrderDetails)
        {
            await _OrderDetailsRepository.UpdateAsync(OrderDetails);
        }

        public async Task DeleteOrderDetailsAsync(int id)
        {
            await _OrderDetailsRepository.DeleteAsync(id);
        }
    }

}
