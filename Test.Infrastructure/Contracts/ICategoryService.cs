using System.Collections.Generic;
using System.Threading.Tasks;
using Test.Data.Models;
using Test.Domain.Models.Category;

namespace Test.Infrastructure.Contracts;

public interface ICategoryService
{
    Task<IEnumerable<CategoryVM>> GetAllCategoriesAsync();
    Task<CategoryVM> GetCategoryByIdAsync(int id);
    Task<CategoryVM> CreateCategoryAsync(CategoryIM categoryInputModel);
    Task<CategoryVM> UpdateCategoryAsync(int id, CategoryUM categoryUpdateModel);
    Task<bool> DeleteCategoryAsync(int id);
}