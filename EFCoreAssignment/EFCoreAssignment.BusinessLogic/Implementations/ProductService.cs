using AutoMapper;
using EFCoreAssignment.BusinessLogic.Contracts;
using EFCoreAssignment.BusinessLogic.Implementations.Base;
using EFCoreAssignment.DataAccess.Data;
using EFCoreAssignment.DataAccess.Models;
using EFCoreAssignment.Domain.Models.Product;

namespace EFCoreAssignment.BusinessLogic.Implementations;

public class ProductService(ApplicationDbContext dbContext, IMapper mapper)
    : BaseCrudService<Product, CreateProduct, ResponseProduct, UpdateProduct>(dbContext, mapper),
        IProductService;