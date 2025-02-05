namespace HotelBookingAPI.Models
{
    /// <summary>
    /// Represents a Room entity within a hotel.
    /// </summary>
    public class Room
    {
        /// <summary>
        /// Gets or sets the unique identifier for the room.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the type of the room (Single, Double, Deluxe).
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the maximum capacity of the room.
        /// </summary>
        public int Capacity { get; set; }

        /// <summary>
        /// Gets or sets whether the room is currently booked.
        /// </summary>
        public bool IsBooked { get; set; }

        /// <summary>
        /// Gets or sets the foreign key referencing the hotel this room belongs to.
        /// </summary>
        public int HotelId { get; set; }

        /// <summary>
        /// Gets or sets the hotel entity associated with this room.
        /// </summary>
        public Hotel Hotel { get; set; }
    }
}
