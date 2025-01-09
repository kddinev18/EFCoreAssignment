using Assignment.DataAccess.Data;
using Assignment.DataAccess.Models;
using Assignment.Domain.Models.InputModels;
using Assignment.Domain.Models.UpdateModels;
using Assignment.Domain.Models.ViewModels;
using Assignment.Infrastructure.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Infrastructure.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CategoryVm>> GetAllAsync()
        {
            return await _context.Categories
                .Select(c => new CategoryVm
                {
                    CategoryId = c.CategoryId,
                    Name = c.Name,
                    Description = c.Description
                })
                .ToListAsync();
        }

        public async Task<CategoryVm?> GetByIdAsync(int id)
        {
            return await _context.Categories
                .Where(c => c.CategoryId == id)
                .Select(c => new CategoryVm
                {
                    CategoryId = c.CategoryId,
                    Name = c.Name,
                    Description = c.Description
                })
                .FirstOrDefaultAsync();
        }

        public async Task<CategoryVm> CreateAsync(CategoryIm inputModel)
        {
            var category = new Category
            {
                Name = inputModel.Name,
                Description = inputModel.Description
            };

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return new CategoryVm
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
                Description = category.Description
            };
        }

        public async Task<CategoryVm> UpdateAsync(int id, CategoryUm updateModel)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                throw new KeyNotFoundException("Category not found");
            }

            category.Name = updateModel.Name;
            category.Description = updateModel.Description;

            _context.Categories.Update(category);
            await _context.SaveChangesAsync();

            return new CategoryVm
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
                Description = category.Description
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return false;
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}