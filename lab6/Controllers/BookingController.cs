using lr9.Interfaces;
using lr9.Models;
using Microsoft.AspNetCore.Mvc;

namespace lr9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingData _bookingData;

        public BookingController(IBookingData bookingData)
        {
            _bookingData = bookingData;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBookings()
        {
            var result = await _bookingData.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBooking(int id)
        {
            var result = await _bookingData.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking([FromBody] Booking booking)
        {
            var result = await _bookingData.CreateAsync(booking);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBooking(int id, [FromBody] Booking booking)
        {
            var result = await _bookingData.UpdateAsync(id, booking);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var result = await _bookingData.DeleteAsync(id);
            return Ok(result);
        }
    }
}
