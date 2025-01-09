using EFCoreAssignment.DataAccess.Data.Models;
using EFCoreAssignment.DataAccess.Repository;
using EFCoreAssignment.Domain.DTOs.Request;
using EFCoreAssignment.Domain.DTOs.Response;
using EFCoreAssignment.Infrastructure.Contracts;

namespace EFCoreAssignment.Infrastructure.Services;

public class CategoryService : ICategoryService
{
    private readonly CategoryRepository _categoryRepository;

    CategoryService(CategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    
    public CategoryResponseDTO GetCategory(int id)
    {
        return _categoryRepository.GetById(id)
            .Select(category => new CategoryResponseDTO
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
            }).First();
    }

    public List<CategoryResponseDTO> GetAllCategories()  
    {
        return _categoryRepository.GetAll()
            .Select(category => new CategoryResponseDTO
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
            }).ToList();
    }

    public bool InsertCategory(CategoryRequestDTO entity)
    {
        return _categoryRepository.Add(new Category()
        {
            Name = entity.Name,
            Description = entity.Description,
        });
    }

    public bool UpdateCategory(CategoryRequestDTO entity)
    {
        return _categoryRepository.Update(new Category()
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
        });
    }

    public bool DeleteCategory(int id)
    {
        return _categoryRepository.Delete(id);
    }
}