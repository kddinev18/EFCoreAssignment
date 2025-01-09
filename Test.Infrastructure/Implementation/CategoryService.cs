using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Test.Domain.Models.Category;
using Test.Data.Data;
using Test.Domain.Models.Customer;
using Test.Infrastructure.Contracts;

namespace Test.Infrastructure.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CategoryVM>> GetAllCategoriesAsync()
        {
            return await _context.Categories
                .Select(category => new CategoryVM
                {
                    CategoryId = category.CategoryId,
                    Name = category.Name,
                    Description = category.Description
                })
                .ToListAsync();
        }

        public async Task<CategoryVM> GetCategoryByIdAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null) return null;

            return new CategoryVM
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
                Description = category.Description
            };
        }

        public async Task<CategoryVM> CreateCategoryAsync(CategoryIM categoryInputModel)
        {
            var category = new Test.Data.Models.Category
            {
                Name = categoryInputModel.Name,
                Description = categoryInputModel.Description
            };

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return new CategoryVM
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
                Description = category.Description
            };
        }

        public async Task<CategoryVM> UpdateCategoryAsync(int id, CategoryUM categoryUpdateModel)
        {
            var existingCategory = await _context.Categories.FindAsync(id);
            if (existingCategory == null) return null;

            existingCategory.Name = categoryUpdateModel.Name;
            existingCategory.Description = categoryUpdateModel.Description;

            await _context.SaveChangesAsync();

            return new CategoryVM
            {
                CategoryId = existingCategory.CategoryId,
                Name = existingCategory.Name,
                Description = existingCategory.Description
            };
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null) return false;

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
