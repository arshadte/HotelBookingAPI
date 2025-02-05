using HotelBookingAPI.Models;

namespace HotelBookingAPI.Services
{
    /// <summary>
    /// Interface defining booking-related operations.
    /// </summary>
    public interface IBookingService
    {
        /// <summary>
        /// Creates a new booking.
        /// </summary>
        /// <param name="roomId">Room ID</param>
        /// <param name="checkIn">Check-in date</param>
        /// <param name="checkOut">Check-out date</param>
        /// <param name="guests">Number of guests</param>
        /// <returns>Created booking entity</returns>
        Booking CreateBooking(int roomId, DateTime checkIn, DateTime checkOut, int guests);

        /// <summary>
        /// Retrieves a booking by its unique reference number.
        /// </summary>
        /// <param name="bookingNumber">Booking reference number</param>
        /// <returns>Booking entity</returns>
        Booking GetBookingByNumber(int bookingNumber);
    }
}