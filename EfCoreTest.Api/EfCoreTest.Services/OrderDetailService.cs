using EfCoreTest.DataAccess;
using EfCoreTest.Models;

namespace EfCoreTest.Services
{
    public class OrderDetailService
    {
        private readonly JsonDataAccess _dataAccess;
        private readonly string _dataKey = "OrderDetails";

        public OrderDetailService(JsonDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public List<OrderDetail> GetAllOrderDetails()
        {
            var data = _dataAccess.ReadData<Dictionary<string, List<OrderDetail>>>();
            return data?[_dataKey] ?? new List<OrderDetail>();
        }

        public List<OrderDetail> GetOrderDetailsByOrderId(int orderId)
        {
            return GetAllOrderDetails().Where(od => od.OrderId == orderId).ToList();
        }

        public OrderDetail AddOrderDetail(OrderDetail newDetail)
        {
            var details = GetAllOrderDetails();
            newDetail.OrderDetailId = details.Any() ? details.Max(od => od.OrderDetailId) + 1 : 1;
            details.Add(newDetail);

            SaveOrderDetails(details);
            return newDetail;
        }

        public bool UpdateOrderDetail(int id, OrderDetail updatedDetail)
        {
            var details = GetAllOrderDetails();
            var existingDetail = details.FirstOrDefault(od => od.OrderDetailId == id);
            if (existingDetail == null)
                return false;

            existingDetail.OrderId = updatedDetail.OrderId;
            existingDetail.ProductId = updatedDetail.ProductId;
            existingDetail.Quantity = updatedDetail.Quantity;
            existingDetail.PricePerUnit = updatedDetail.PricePerUnit;

            SaveOrderDetails(details);
            return true;
        }

        public bool DeleteOrderDetail(int id)
        {
            var details = GetAllOrderDetails();
            var detailToRemove = details.FirstOrDefault(od => od.OrderDetailId == id);
            if (detailToRemove == null)
                return false;

            details.Remove(detailToRemove);
            SaveOrderDetails(details);
            return true;
        }

        private void SaveOrderDetails(List<OrderDetail> details)
        {
            var data = _dataAccess.ReadData<Dictionary<string, object>>() ?? new Dictionary<string, object>();
            data[_dataKey] = details;
            _dataAccess.WriteData(data);
        }
    }
}
