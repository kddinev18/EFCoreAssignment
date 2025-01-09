using Microsoft.EntityFrameworkCore;
using json2_assignment.DAL.Repository.Base;
using json2_assignment.DM.Models;

namespace json2_assignment.DAL.Repository;

public class CategoryRepository : BaseRepository<Category>
{
    public CategoryRepository(DbContext context) : base(context) { }

    protected override void UpdateEntity(Category oldEntity, Category newEntity)
    {
        oldEntity.Name = newEntity.Name;
        oldEntity.Description = newEntity.Description;
    }
}