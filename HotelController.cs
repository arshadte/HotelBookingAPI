using HotelBookingAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;

        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        /// <summary>
        /// Retrieves a hotel by its name.
        /// </summary>
        /// <param name="name">Hotel name</param>
        /// <returns>Hotel details</returns>
        [HttpGet("hotel/{name}")]
        public IActionResult GetHotel(string name)
        {
            var hotel = _hotelService.GetHotelByName(name);
            if (hotel == null) return NotFound();
            return Ok(hotel);
        }

        /// <summary>
        /// Finds available rooms between two dates for a given number of guests.
        /// </summary>
        /// <param name="checkIn">Check-in date</param>
        /// <param name="checkOut">Check-out date</param>
        /// <param name="guests">Number of guests</param>
        /// <returns>List of available rooms</returns>
        [HttpGet("rooms/availability")]
        public IActionResult GetAvailableRooms([FromQuery] DateTime checkIn, [FromQuery] DateTime checkOut, [FromQuery] int guests)
        {
            return Ok(_hotelService.GetAvailableRooms(checkIn, checkOut, guests));
        }
    }
}
