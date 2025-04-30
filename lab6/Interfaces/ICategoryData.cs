using lr9.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace lr9.Interfaces
{
    public interface ICategoryData
    {
        Task<ApiResponse<List<Category>>> GetAllAsync();
        Task<ApiResponse<Category>> GetByIdAsync(int id);
        Task<ApiResponse<Category>> CreateAsync(Category category);
        Task<ApiResponse<Category>> UpdateAsync(int id, Category category);
        Task<ApiResponse<bool>> DeleteAsync(int id);
    }
}
