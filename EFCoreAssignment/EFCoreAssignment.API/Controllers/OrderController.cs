using EFCoreAssignment.API.Controllers.Base;
using EFCoreAssignment.BusinessLogic.Contracts;
using EFCoreAssignment.Domain.Models.Order;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreAssignment.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController(IOrderService service)
    : BaseCrudController<IOrderService, CreateOrder, ResponseOrder, UpdateOrder>(service);
