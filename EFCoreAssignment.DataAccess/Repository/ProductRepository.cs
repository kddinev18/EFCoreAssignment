using EFCoreAssignment.DataAccess.Data;
using EFCoreAssignment.DataAccess.Data.Models;
using EFCoreAssignment.DataAccess.Repository.Base;

namespace EFCoreAssignment.DataAccess.Repository;

public class ProductRepository : GenericRepository<Product>
{
    public ProductRepository(ApplicationDbContext context) : base(context)
    {
        
    }

    protected override void UpdateEntity(Product oldEntity, Product newEntity)
    {
        oldEntity.Name = newEntity.Name;
        oldEntity.Price = newEntity.Price;
        oldEntity.Stock = newEntity.Stock;
        oldEntity.Description = newEntity.Description;
        oldEntity.CategoryId = newEntity.CategoryId;
        oldEntity.Category = newEntity.Category;
    }
}