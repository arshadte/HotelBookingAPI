namespace HotelBookingAPI.DTOs
{
    /// <summary>
    /// Data Transfer Object for returning booking details.
    /// </summary>
    public class BookingResponseDto
    {
        /// <summary>
        /// Gets or sets the unique booking number.
        /// </summary>
        public string BookingNumber { get; set; }

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
