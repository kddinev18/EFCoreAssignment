using AutoMapper;
using EFCoreAssignment.BusinessLogic.Contracts;
using EFCoreAssignment.BusinessLogic.Implementations.Base;
using EFCoreAssignment.DataAccess.Data;
using EFCoreAssignment.DataAccess.Models;
using EFCoreAssignment.Domain.Models.Order;

namespace EFCoreAssignment.BusinessLogic.Implementations;

public class OrderService(ApplicationDbContext dbContext, IMapper mapper)
    : BaseCrudService<Order, CreateOrder, ResponseOrder, UpdateOrder>(dbContext, mapper),
        IOrderService;