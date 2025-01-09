using EFCoreAssignment.API.Controllers.Base;
using EFCoreAssignment.BusinessLogic.Contracts;
using EFCoreAssignment.Domain.Models.OrderDetail;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreAssignment.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderDetailController(IOrderDetailService service)
    : BaseCrudController<IOrderDetailService, CreateOrderDetail, ResponseOrderDetail, UpdateOrderDetail>(service);
