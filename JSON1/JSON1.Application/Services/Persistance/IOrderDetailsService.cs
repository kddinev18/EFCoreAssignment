using JSON1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON1.Application.Services.Persistance
{
    public interface IOrderDetailsService
    {
        Task<IEnumerable<OrderDetails>> GetAllOrderDetailsAsync();
        Task<OrderDetails> GetOrderDetailsByIdAsync(int id);
        Task<IEnumerable<OrderDetails>> GetOrderDetailsByOrderIdAsync(int orderId);
        Task AddOrderDetailsAsync(OrderDetails orderDetail);
        Task UpdateOrderDetailsAsync(OrderDetails orderDetail);
        Task DeleteOrderDetailsAsync(int id);
    }
}
