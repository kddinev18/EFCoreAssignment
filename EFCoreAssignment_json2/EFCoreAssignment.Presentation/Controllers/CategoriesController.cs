using Microsoft.AspNetCore.Mvc;
using EFCoreAssignment.Logic;
using EFCoreAssignment.DataAccess;

namespace EFCoreAssignment.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoriesService _categoryService;

        public CategoriesController(CategoriesService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/Category
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categories>>> GetCategories()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return Ok(categories);
        }

        // GET: api/Category/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Categories>> GetCategory(int id)
        {
            try
            {
                var category = await _categoryService.GetCategoryByIdAsync(id);
                return Ok(category);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // POST: api/Category
        [HttpPost]
        public async Task<ActionResult<Categories>> CreateCategory([FromBody] Categories category)
        {
            if (category == null)
            {
                return BadRequest("Category data is invalid.");
            }

            var createdCategory = await _categoryService.CreateCategoryAsync(category);
            return CreatedAtAction(nameof(GetCategory), new { id = createdCategory.CategoryId }, createdCategory);
        }

        // PUT: api/Category/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<Categories>> UpdateCategory(int id, [FromBody] Categories category)
        {
            if (category == null)
            {
                return BadRequest("Category data is invalid.");
            }

            try
            {
                var updatedCategory = await _categoryService.UpdateCategoryAsync(id, category);
                return Ok(updatedCategory);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // DELETE: api/Category/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                await _categoryService.DeleteCategoryAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
