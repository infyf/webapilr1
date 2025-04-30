using lr9.Interfaces;
using lr9.Models;
using Microsoft.AspNetCore.Mvc;

namespace lr9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishController : ControllerBase
    {
        private readonly IDishData _dishData;

        public DishController(IDishData dishData)
        {
            _dishData = dishData;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDishes()
        {
            var result = await _dishData.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDish(int id)
        {
            var result = await _dishData.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDish([FromBody] Dish dish)
        {
            var result = await _dishData.CreateAsync(dish);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDish(int id, [FromBody] Dish dish)
        {
            var result = await _dishData.UpdateAsync(id, dish);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDish(int id)
        {
            var result = await _dishData.DeleteAsync(id);
            return Ok(result);
        }
    }
}
