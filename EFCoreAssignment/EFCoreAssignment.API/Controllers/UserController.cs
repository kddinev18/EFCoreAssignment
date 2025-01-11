using EFCoreAssignment.API.Controllers.Base;
using EFCoreAssignment.BusinessLogic.Contracts;
using EFCoreAssignment.Domain.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreAssignment.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(IUserService service)
    : BaseCrudController<IUserService, CreateUser, ResponseUser, UpdateUser>(service);
