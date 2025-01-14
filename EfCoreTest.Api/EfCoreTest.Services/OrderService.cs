using EfCoreTest.DataAccess;
using EfCoreTest.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EfCoreTest.Services
{
    public class OrderService
    {
        private readonly AppDbContext _context;

        public OrderService()
        {
            _context = new AppDbContext(new DbContextOptions<AppDbContext>());
        }

        public List<Order> GetAllOrders()
        {
            return _context.Orders.ToList();
        }

        public Order GetOrderById(int id)
        {
            return _context.Orders.FirstOrDefault(o => o.OrderId == id);
        }

        public Order AddOrder(Order newOrder)
        {
            _context.Orders.Add(newOrder);
            _context.SaveChanges();
            return newOrder;
        }

        public bool UpdateOrder(int id, Order updatedOrder)
        {
            var existingOrder = _context.Orders.FirstOrDefault(o => o.OrderId == id);
            if (existingOrder == null)
                return false;

            existingOrder.UserId = updatedOrder.UserId;
            existingOrder.OrderDate = updatedOrder.OrderDate;
            existingOrder.TotalAmount = updatedOrder.TotalAmount;
            existingOrder.Status = updatedOrder.Status;

            _context.SaveChanges();
            return true;
        }

        public bool DeleteOrder(int id)
        {
            var orderToRemove = _context.Orders.FirstOrDefault(o => o.OrderId == id);
            if (orderToRemove == null)
                return false;

            _context.Orders.Remove(orderToRemove);
            _context.SaveChanges();
            return true;
        }
    }
}
