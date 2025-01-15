using EFCoreAssignment.Domain.DTOs.Request;
using EFCoreAssignment.Domain.DTOs.Response;

namespace EFCoreAssignment.Infrastructure.Contracts;

public interface ICategoryService
{
    public CategoryResponseDTO GetCategory(int id);
    
    public List<CategoryResponseDTO> GetAllCategories();
    
    public bool InsertCategory(CategoryRequestDTO entity);

    public bool UpdateCategory(CategoryRequestDTO entity);
    
    public bool DeleteCategory(int id);
}