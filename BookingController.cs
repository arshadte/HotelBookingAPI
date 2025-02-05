using HotelBookingAPI.Models;
using HotelBookingAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        /// <summary>
        /// Books a room based on the given request.
        /// </summary>
        /// <param name="request">Booking request</param>
        /// <returns>Booking details</returns>
        [HttpPost("book")]
        public IActionResult BookRoom([FromBody] Booking request)
        {
            try
            {
                var booking = _bookingService.CreateBooking(request.RoomId, request.CheckIn, request.CheckOut, request.Guests);
                return Ok(booking);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Retrieves booking details using the booking reference number.
        /// </summary>
        /// <param name="bookingNumber">Booking reference number</param>
        /// <returns>Booking details</returns>
        [HttpGet("booking/{bookingNumber}")]
        public IActionResult GetBooking(int bookingNumber)
        {
            var booking = _bookingService.GetBookingByNumber(bookingNumber);
            if (booking == null) return NotFound();
            return Ok(booking);
        }
    }
}
