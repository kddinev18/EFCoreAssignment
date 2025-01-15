using EFCoreAssignment.DataAccess.Data;
using EFCoreAssignment.DataAccess.Data.Models;
using EFCoreAssignment.DataAccess.Repository.Base;

namespace EFCoreAssignment.DataAccess.Repository;

public class CategoryRepository : GenericRepository<Category>
{
    public CategoryRepository(ApplicationDbContext context) : base(context)
    {
        
    }

    protected override void UpdateEntity(Category oldEntity, Category newEntity)
    {
        oldEntity.Name = newEntity.Name;
        oldEntity.Description = newEntity.Description;
    }
}