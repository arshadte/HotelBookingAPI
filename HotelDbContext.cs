using HotelBookingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingAPI.Data
{
    /// <summary>
    /// Represents the Entity Framework Core database context for the hotel booking system.
    /// </summary>
    public class HotelDbContext : DbContext
    {
        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options) { }

        /// <summary>
        /// DbSet representing the collection of hotels.
        /// </summary>
        public DbSet<Hotel> Hotels { get; set; }

        /// <summary>
        /// DbSet representing the collection of rooms.
        /// </summary>
        public DbSet<Room> Rooms { get; set; }

        /// <summary>
        /// DbSet representing the collection of bookings.
        /// </summary>
        public DbSet<Booking> Bookings { get; set; }
    }
}
