using lr9.Interfaces;
using lr9.Models;

namespace lr9.Services
{
    public class BookingData : IBookingData
    {
        private static List<Booking> bookings = new List<Booking>
        {
            new Booking { Id = 1, CustomerName = "Іван", NumberOfPeople = 4, BookingTime = DateTime.Now.AddDays(1) },
            new Booking { Id = 2, CustomerName = "Марія", NumberOfPeople = 2, BookingTime = DateTime.Now.AddDays(2) },
            new Booking { Id = 3, CustomerName = "Олег", NumberOfPeople = 3, BookingTime = DateTime.Now.AddDays(3) },
            new Booking { Id = 4, CustomerName = "Тетяна", NumberOfPeople = 5, BookingTime = DateTime.Now.AddDays(4) },
            new Booking { Id = 5, CustomerName = "Андрій", NumberOfPeople = 2, BookingTime = DateTime.Now.AddDays(5) },
            new Booking { Id = 6, CustomerName = "Катерина", NumberOfPeople = 4, BookingTime = DateTime.Now.AddDays(6) },
            new Booking { Id = 7, CustomerName = "Володимир", NumberOfPeople = 6, BookingTime = DateTime.Now.AddDays(7) },
            new Booking { Id = 8, CustomerName = "Наталія", NumberOfPeople = 3, BookingTime = DateTime.Now.AddDays(8) },
            new Booking { Id = 9, CustomerName = "Петро Д", NumberOfPeople = 7, BookingTime = DateTime.Now.AddDays(9) },
            new Booking { Id = 10, CustomerName = "Оксана", NumberOfPeople = 5, BookingTime = DateTime.Now.AddDays(10) }
        };

        public async Task<ApiResponse<List<Booking>>> GetAllAsync()
        {
            return await Task.FromResult(new ApiResponse<List<Booking>> { Success = true, Data = bookings });
        }

        public async Task<ApiResponse<Booking>> GetByIdAsync(int id)
        {
            var booking = bookings.FirstOrDefault(b => b.Id == id);
            if (booking == null)
                return new ApiResponse<Booking> { Success = false, Message = "Booking not found" };
            return await Task.FromResult(new ApiResponse<Booking> { Success = true, Data = booking });
        }

        public async Task<ApiResponse<Booking>> CreateAsync(Booking booking)
        {
            booking.Id = bookings.Max(b => b.Id) + 1;
            bookings.Add(booking);
            return await Task.FromResult(new ApiResponse<Booking> { Success = true, Data = booking });
        }

        public async Task<ApiResponse<Booking>> UpdateAsync(int id, Booking booking)
        {
            var existingBooking = bookings.FirstOrDefault(b => b.Id == id);
            if (existingBooking == null)
                return new ApiResponse<Booking> { Success = false, Message = "Booking not found" };

            existingBooking.CustomerName = booking.CustomerName;
            existingBooking.NumberOfPeople = booking.NumberOfPeople;
            existingBooking.BookingTime = booking.BookingTime;

            return await Task.FromResult(new ApiResponse<Booking> { Success = true, Data = existingBooking });
        }

        public async Task<ApiResponse<bool>> DeleteAsync(int id)
        {
            var booking = bookings.FirstOrDefault(b => b.Id == id);
            if (booking == null)
                return new ApiResponse<bool> { Success = false, Message = "Booking not found" };

            bookings.Remove(booking);
            return await Task.FromResult(new ApiResponse<bool> { Success = true, Data = true });
        }
    }
}
