using EFCoreAssignment.BusinessLogic.Contracts.Generic;
using EFCoreAssignment.Domain.Models.OrderDetail;

namespace EFCoreAssignment.BusinessLogic.Contracts;

public interface IOrderDetailService : IGenericCrudService<CreateOrderDetail, ResponseOrderDetail, UpdateOrderDetail>;
