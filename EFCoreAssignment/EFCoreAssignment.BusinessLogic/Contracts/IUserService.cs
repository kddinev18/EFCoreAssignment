using EFCoreAssignment.BusinessLogic.Contracts.Generic;
using EFCoreAssignment.Domain.Models.User;

namespace EFCoreAssignment.BusinessLogic.Contracts;

public interface IUserService : IGenericCrudService<CreateUser, ResponseUser, UpdateUser>;
