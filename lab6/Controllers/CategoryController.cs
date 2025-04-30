using lr9.Interfaces;
using lr9.Models;
using Microsoft.AspNetCore.Mvc;

namespace lr9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryData _categoryData;

        public CategoryController(ICategoryData categoryData)
        {
            _categoryData = categoryData;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var result = await _categoryData.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var result = await _categoryData.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] Category category)
        {
            var result = await _categoryData.CreateAsync(category);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] Category category)
        {
            var result = await _categoryData.UpdateAsync(id, category);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _categoryData.DeleteAsync(id);
            return Ok(result);
        }
    }
}
