using AutoMapper;
using EFCoreAssignment.BusinessLogic.Contracts;
using EFCoreAssignment.BusinessLogic.Implementations.Base;
using EFCoreAssignment.DataAccess.Data;
using EFCoreAssignment.DataAccess.Models;
using EFCoreAssignment.Domain.Models.User;

namespace EFCoreAssignment.BusinessLogic.Implementations;

public class UserService(ApplicationDbContext dbContext, IMapper mapper)
    : BaseCrudService<User, CreateUser, ResponseUser, UpdateUser>(dbContext, mapper),
        IUserService;