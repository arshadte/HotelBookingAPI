namespace HotelBookingAPI.DTOs
{
    /// <summary>
    /// Data Transfer Object for returning room availability.
    /// </summary>
    public class RoomAvailabilityDto
    {
        /// <summary>
        /// Gets or sets the Room ID.
        /// </summary>
        public int RoomId { get; set; }

        /// <summary>
        /// Gets or sets the room type (Single, Double, Deluxe).
        /// </summary>
        public string RoomType { get; set; }

        /// <summary>
        /// Gets or sets the maximum capacity of the room.
        /// </summary>
        public int Capacity { get; set; }
    }
}
