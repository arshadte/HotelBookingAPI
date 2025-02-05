using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingAPI.Models
{
    /// <summary>
    /// Represents a Booking entity for hotel rooms.
    /// </summary>
    public class Booking
    {
        /// <summary>
        /// Gets or sets the unique booking reference number.
        /// </summary>
        [Key] // ✅ Defines BookingNumber as the primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingNumber { get; set; }

        /// <summary>
        /// Gets or sets the foreign key referencing the booked room.
        /// </summary>
        public int RoomId { get; set; }

        /// <summary>
        /// Gets or sets the room entity associated with the booking.
        /// </summary>
        public Room Room { get; set; }

        /// <summary>
        /// Gets or sets the check-in date for the booking.
        /// </summary>
        public DateTime CheckIn { get; set; }

        /// <summary>
        /// Gets or sets the check-out date for the booking.
        /// </summary>
        public DateTime CheckOut { get; set; }

        /// <summary>
        /// Gets or sets the number of guests for the booking.
        /// </summary>
        public int Guests { get; set; }
    }
}
