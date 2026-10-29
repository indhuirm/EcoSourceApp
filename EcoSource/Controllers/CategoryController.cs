using EcoSource.Model;
using EcoSource.Services;

using Microsoft.AspNetCore.Mvc;

namespace EcoSource.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {

        private readonly ICategoryservice _categoryService;
        public CategoryController(ICategoryservice categoryservice)
        {
            _categoryService = categoryservice;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var result = await _categoryService.GetCategories();
            return Ok(result);
        }
        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetCategoryById(int categoryId)
        {
            var result = await _categoryService.GetCategoryById(categoryId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            _categoryService.AddCategory(category);
            return Ok();
        }
        [HttpPut("{CategoryId}")]
        public IActionResult UpdateCategory(int CategoryId, Category category)
        {
            if (CategoryId != category.CategoryId)
            {
                return BadRequest();
            }
            _categoryService.UpdateCategory(category);
            return Ok();
        }
        [HttpDelete("{CategoryId}")]
        public IActionResult DeleteCategory(int CategoryId)
        {
            _categoryService.DeleteCategory(CategoryId);
            return Ok();
        }
    }
}
