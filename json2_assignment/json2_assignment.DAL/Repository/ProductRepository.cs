using Microsoft.EntityFrameworkCore;
using json2_assignment.DAL.Repository.Base;
using json2_assignment.DM.Models;

namespace json2_assignment.DAL.Repository;

public class ProductRepository : BaseRepository<Product>
{
    public ProductRepository(DbContext context) : base(context) { }

    protected override void UpdateEntity(Product oldEntity, Product newEntity)
    {
        oldEntity.Name = newEntity.Name;
        oldEntity.Price = newEntity.Price;
        oldEntity.Stock = newEntity.Stock;
        oldEntity.Description = newEntity.Description;
        oldEntity.CategoryId = newEntity.CategoryId;
    }
}