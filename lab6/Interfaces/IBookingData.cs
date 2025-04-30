using lr9.Models;

namespace lr9.Interfaces
{
    public interface IBookingData
    {
        Task<ApiResponse<List<Booking>>> GetAllAsync();
        Task<ApiResponse<Booking>> GetByIdAsync(int id);
        Task<ApiResponse<Booking>> CreateAsync(Booking booking);
        Task<ApiResponse<Booking>> UpdateAsync(int id, Booking booking);
        Task<ApiResponse<bool>> DeleteAsync(int id);
    }
}
