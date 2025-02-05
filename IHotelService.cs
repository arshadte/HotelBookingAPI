using HotelBookingAPI.Models;

namespace HotelBookingAPI.Services
{
    /// <summary>
    /// Interface defining hotel-related operations.
    /// </summary>
    public interface IHotelService
    {
        /// <summary>
        /// Retrieves a hotel by its name.
        /// </summary>
        /// <param name="name">Hotel name</param>
        /// <returns>Hotel entity</returns>
        Hotel GetHotelByName(string name);

        /// <summary>
        /// Retrieves a list of available rooms between specified dates for a given number of guests.
        /// </summary>
        /// <param name="checkIn">Check-in date</param>
        /// <param name="checkOut">Check-out date</param>
        /// <param name="guests">Number of guests</param>
        /// <returns>List of available rooms</returns>
        List<Room> GetAvailableRooms(DateTime checkIn, DateTime checkOut, int guests);
    }
}