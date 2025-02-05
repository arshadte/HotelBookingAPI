namespace HotelBookingAPI.Models
{
    /// <summary>
    /// Represents a Hotel entity.
    /// </summary>
    public class Hotel
    {
        /// <summary>
        /// Gets or sets the unique identifier for the hotel.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the hotel.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the collection of rooms available in the hotel.
        /// </summary>
        public List<Room> Rooms { get; set; } = new();
    }
}
