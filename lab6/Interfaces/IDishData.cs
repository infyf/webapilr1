using lr9.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace lr9.Interfaces
{
    public interface IDishData
    {
        Task<ApiResponse<List<Dish>>> GetAllAsync();
        Task<ApiResponse<Dish>> GetByIdAsync(int id);
        Task<ApiResponse<Dish>> CreateAsync(Dish dish);
        Task<ApiResponse<Dish>> UpdateAsync(int id, Dish dish);
        Task<ApiResponse<bool>> DeleteAsync(int id);
    }
}
