using AutoMapper;
using EFCoreAssignment.BusinessLogic.Contracts;
using EFCoreAssignment.BusinessLogic.Implementations.Base;
using EFCoreAssignment.DataAccess.Data;
using EFCoreAssignment.DataAccess.Models;
using EFCoreAssignment.Domain.Models.OrderDetail;

namespace EFCoreAssignment.BusinessLogic.Implementations;

public class OrderDetailService(ApplicationDbContext dbContext, IMapper mapper)
    : BaseCrudService<OrderDetail, CreateOrderDetail, ResponseOrderDetail, UpdateOrderDetail>(dbContext, mapper),
        IOrderDetailService;
