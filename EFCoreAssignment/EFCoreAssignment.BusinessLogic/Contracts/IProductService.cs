using EFCoreAssignment.BusinessLogic.Contracts.Generic;
using EFCoreAssignment.Domain.Models.Product;

namespace EFCoreAssignment.BusinessLogic.Contracts;

public interface IProductService : IGenericCrudService<CreateProduct, ResponseProduct, UpdateProduct>;
