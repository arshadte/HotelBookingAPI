namespace HotelBookingAPI.DTOs
{
    /// <summary>
    /// Data Transfer Object for creating a booking request.
    /// </summary>
    public class BookingRequestDto
    {
        /// <summary>
        /// Gets or sets the Room ID.
        /// </summary>
        public int RoomId { get; set; }

        /// <summary>
        /// Gets or sets the check-in date.
        /// </summary>
        public DateTime CheckIn { get; set; }

        /// <summary>
        /// Gets or sets the check-out date.
        /// </summary>
        public DateTime CheckOut { get; set; }

        /// <summary>
        /// Gets or sets the number of guests for the booking.
        /// </summary>
        public int Guests { get; set; }
    }
}
