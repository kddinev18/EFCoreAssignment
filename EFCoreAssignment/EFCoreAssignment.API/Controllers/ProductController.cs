using EFCoreAssignment.API.Controllers.Base;
using EFCoreAssignment.BusinessLogic.Contracts;
using EFCoreAssignment.Domain.Models.Product;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreAssignment.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController(IProductService service)
    : BaseCrudController<IProductService, CreateProduct, ResponseProduct, UpdateProduct>(service);
