using json2_assignment.Domain.DTOs;

namespace json2_assignment.Domain.Services;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
    Task<CategoryDto> GetCategoryByIdAsync(int id);
    Task<CategoryDto> CreateCategoryAsync(CategoryDto categoryDto);
    Task UpdateCategoryAsync(CategoryDto categoryDto);
    Task DeleteCategoryAsync(int id);
}