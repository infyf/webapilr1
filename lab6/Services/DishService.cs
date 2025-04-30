using lr9.Interfaces;
using lr9.Models;

namespace lr9.Services
{
    public class DishData : IDishData
    {

        private static List<Dish> dishes = new List<Dish>
        {
            new Dish { Id = 1, Name = "Піца Маргарита", Description = "Смачна піца з сиром та помідорами", Price = 10.99 },
            new Dish { Id = 2, Name = "Паста Болоньєзе", Description = "Спагеті з м'ясним соусом", Price = 8.99 },
            new Dish { Id = 3, Name = "Борщ", Description = "Традиційний український борщ з пампушками", Price = 4.99 },
            new Dish { Id = 4, Name = "Гречка з котлетою", Description = "Гречка з смаженою котлетою", Price = 7.99 },
            new Dish { Id = 5, Name = "Шашлик", Description = "Соковитий шашлик з курки", Price = 12.99 },
            new Dish { Id = 6, Name = "Салат Олів'є", Description = "Класичний салат з ковбасою та майонезом", Price = 5.99 },
            new Dish { Id = 7, Name = "Чізкейк", Description = "Ніжний десерт з сиром", Price = 6.99 },
            new Dish { Id = 8, Name = "Котлета по-київськи", Description = "Класична котлета з куркою та маслом", Price = 11.99 },
            new Dish { Id = 9, Name = "Крем-брюле", Description = "Десерт з карамельною скоринкою", Price = 7.49 },
            new Dish { Id = 10, Name = "Торт Медовик", Description = "Медовий торт з кремом", Price = 8.49 }
        };

        public async Task<ApiResponse<List<Dish>>> GetAllAsync()
        {
            return await Task.FromResult(new ApiResponse<List<Dish>> { Success = true, Data = dishes });
        }

        public async Task<ApiResponse<Dish>> GetByIdAsync(int id)
        {
            var dish = dishes.FirstOrDefault(d => d.Id == id);
            if (dish == null)
                return new ApiResponse<Dish> { Success = false, Message = "Dish not found" };
            return await Task.FromResult(new ApiResponse<Dish> { Success = true, Data = dish });
        }

        public async Task<ApiResponse<Dish>> CreateAsync(Dish dish)
        {
            dish.Id = dishes.Max(d => d.Id) + 1;
            dishes.Add(dish);
            return await Task.FromResult(new ApiResponse<Dish> { Success = true, Data = dish });
        }

        public async Task<ApiResponse<Dish>> UpdateAsync(int id, Dish dish)
        {
            var existingDish = dishes.FirstOrDefault(d => d.Id == id);
            if (existingDish == null)
                return new ApiResponse<Dish> { Success = false, Message = "Dish not found" };

            existingDish.Name = dish.Name;
            existingDish.Description = dish.Description;
            existingDish.Price = dish.Price;

            return await Task.FromResult(new ApiResponse<Dish> { Success = true, Data = existingDish });
        }

        public async Task<ApiResponse<bool>> DeleteAsync(int id)
        {
            var dish = dishes.FirstOrDefault(d => d.Id == id);
            if (dish == null)
                return new ApiResponse<bool> { Success = false, Message = "Dish not found" };

            dishes.Remove(dish);
            return await Task.FromResult(new ApiResponse<bool> { Success = true, Data = true });
        }
    }
}
