using EfCoreTest.DataAccess;
using EfCoreTest.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EfCoreTest.Services
{
    public class OrderDetailService
    {
        private readonly AppDbContext _context;

        public OrderDetailService()
        {
            _context = new AppDbContext(new DbContextOptions<AppDbContext>());
        }

        public List<OrderDetail> GetAllOrderDetails()
        {
            return _context.OrderDetails.ToList();
        }

        public List<OrderDetail> GetOrderDetailsByOrderId(int orderId)
        {
            return _context.OrderDetails.Where(od => od.OrderId == orderId).ToList();
        }

        public OrderDetail AddOrderDetail(OrderDetail newOrderDetail)
        {
            _context.OrderDetails.Add(newOrderDetail);
            _context.SaveChanges();
            return newOrderDetail;
        }

        public bool UpdateOrderDetail(int id, OrderDetail updatedOrderDetail)
        {
            var existingDetail = _context.OrderDetails.FirstOrDefault(od => od.OrderDetailId == id);
            if (existingDetail == null)
                return false;

            existingDetail.ProductId = updatedOrderDetail.ProductId;
            existingDetail.Quantity = updatedOrderDetail.Quantity;
            existingDetail.PricePerUnit = updatedOrderDetail.PricePerUnit;

            _context.SaveChanges();
            return true;
        }

        public bool DeleteOrderDetail(int id)
        {
            var orderDetailToRemove = _context.OrderDetails.FirstOrDefault(od => od.OrderDetailId == id);
            if (orderDetailToRemove == null)
                return false;

            _context.OrderDetails.Remove(orderDetailToRemove);
            _context.SaveChanges();
            return true;
        }
    }
}
