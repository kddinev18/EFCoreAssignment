using EFCoreAssignment.BusinessLogic.Contracts.Generic;
using EFCoreAssignment.Domain.Models.Order;

namespace EFCoreAssignment.BusinessLogic.Contracts;

public interface IOrderService : IGenericCrudService<CreateOrder, ResponseOrder, UpdateOrder>;
