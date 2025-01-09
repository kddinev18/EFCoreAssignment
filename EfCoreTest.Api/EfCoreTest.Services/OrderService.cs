using EfCoreTest.DataAccess;
using EfCoreTest.Models;

namespace EfCoreTest.Services
{
    public class OrderService
    {
        private readonly JsonDataAccess _dataAccess;
        private readonly string _dataKey = "Orders";

        public OrderService(JsonDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public List<Order> GetAllOrders()
        {
            var data = _dataAccess.ReadData<Dictionary<string, List<Order>>>();
            return data?[_dataKey] ?? new List<Order>();
        }

        public Order? GetOrderById(int id)
        {
            return GetAllOrders().FirstOrDefault(o => o.OrderId == id);
        }

        public Order AddOrder(Order newOrder)
        {
            var orders = GetAllOrders();
            newOrder.OrderId = orders.Any() ? orders.Max(o => o.OrderId) + 1 : 1;
            orders.Add(newOrder);

            SaveOrders(orders);
            return newOrder;
        }

        public bool UpdateOrder(int id, Order updatedOrder)
        {
            var orders = GetAllOrders();
            var existingOrder = orders.FirstOrDefault(o => o.OrderId == id);
            if (existingOrder == null)
                return false;

            existingOrder.UserId = updatedOrder.UserId;
            existingOrder.OrderDate = updatedOrder.OrderDate;
            existingOrder.TotalAmount = updatedOrder.TotalAmount;
            existingOrder.Status = updatedOrder.Status;

            SaveOrders(orders);
            return true;
        }

        public bool DeleteOrder(int id)
        {
            var orders = GetAllOrders();
            var orderToRemove = orders.FirstOrDefault(o => o.OrderId == id);
            if (orderToRemove == null)
                return false;

            orders.Remove(orderToRemove);
            SaveOrders(orders);
            return true;
        }

        private void SaveOrders(List<Order> orders)
        {
            var data = _dataAccess.ReadData<Dictionary<string, object>>() ?? new Dictionary<string, object>();
            data[_dataKey] = orders;
            _dataAccess.WriteData(data);
        }
    }
}
