using EFCoreAssignment.DataAccess;
using EFCoreAssignment.DataAccess.Data.Models;
using EFCoreAssignment.DataAccess.Data;
using EFCoreAssignment.Domain.DTOs.Request;
using EFCoreAssignment.Domain.DTOs.Response;
using EFCoreAssignment.Infrastructure.Contracts;
using Microsoft.EntityFrameworkCore;

namespace EFCoreAssignment.Infrastructure.Services;

public class CategoryService : ICategoryService
{
    private readonly ApplicationDbContext _context;

    public CategoryService(ApplicationDbContext context)
    {
        _context = context;
    }

    public CategoryResponseDTO GetCategory(int id)
    {
        var category = _context.Categories
            .AsNoTracking()
            .FirstOrDefault(c => c.Id == id);

        if (category == null) return null;

        return new CategoryResponseDTO
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description
        };
    }

    public List<CategoryResponseDTO> GetAllCategories()
    {
        return _context.Categories
            .AsNoTracking()
            .Select(c => new CategoryResponseDTO
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description
            })
            .ToList();
    }

    public bool InsertCategory(CategoryRequestDTO entity)
    {
        var category = new Category
        {
            Name = entity.Name,
            Description = entity.Description
        };

        _context.Categories.Add(category);
        return _context.SaveChanges() > 0;
    }

    public bool UpdateCategory(CategoryRequestDTO entity)
    {
        var category = _context.Categories.FirstOrDefault(c => c.Id == entity.Id);
        if (category == null) return false;

        category.Name = entity.Name;
        category.Description = entity.Description;

        _context.Categories.Update(category);
        return _context.SaveChanges() > 0;
    }

    public bool DeleteCategory(int id)
    {
        var category = _context.Categories.FirstOrDefault(c => c.Id == id);
        if (category == null) return false;

        _context.Categories.Remove(category);
        return _context.SaveChanges() > 0;
    }
}
