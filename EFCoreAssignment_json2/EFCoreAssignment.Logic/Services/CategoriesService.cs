using EFCoreAssignment.DataAccess.Repositories;
using EFCoreAssignment.DataAccess;

namespace EFCoreAssignment.Logic
{
    public class CategoriesService
    {
        private readonly CategoriesRepository _categoriesRepository;
        
        public CategoriesService(CategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }
        
        public async Task<IEnumerable<Categories>> GetAllCategoriesAsync()
        {
            return await _categoriesRepository.GetAllAsync();
        }
        
        public async Task<Categories> GetCategoryByIdAsync(int id)
        {
            var category = await _categoriesRepository.GetByIdAsync(id);
            if (category == null)
            {
                throw new KeyNotFoundException($"Category with ID {id} not found.");
            }
            return category;
        }
        
        public async Task<Categories> CreateCategoryAsync(Categories category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category), "Category cannot be null.");
            }

            await _categoriesRepository.AddAsync(category);
            return category;
        }
        
        public async Task<Categories> UpdateCategoryAsync(int id, Categories updatedCategory)
        {
            var existingCategory = await _categoriesRepository.GetByIdAsync(id);
            if (existingCategory == null)
            {
                throw new KeyNotFoundException($"Category with ID {id} not found.");
            }

            existingCategory.Name = updatedCategory.Name;
            existingCategory.Description = updatedCategory.Description;

            _categoriesRepository.Update(existingCategory);
            return existingCategory;
        }
        
        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _categoriesRepository.GetByIdAsync(id);
            if (category == null)
            {
                throw new KeyNotFoundException($"Category with ID {id} not found.");
            }

            _categoriesRepository.Remove(category);
        }
    }
}
