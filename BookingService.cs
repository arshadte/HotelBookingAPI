using HotelBookingAPI.Data;
using HotelBookingAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace HotelBookingAPI.Services
{
    /// <summary>
    /// Service responsible for handling booking operations.
    /// Implements IBookingService for dependency injection.
    /// </summary>
    public class BookingService : IBookingService
    {
        private readonly HotelDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookingService"/> class.
        /// </summary>
        /// <param name="context">Database context for bookings.</param>
        public BookingService(HotelDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new booking, ensuring all business rules are enforced.
        /// </summary>
        public Booking CreateBooking(int roomId, DateTime checkIn, DateTime checkOut, int guests)
        {
            if (checkIn >= checkOut)
                throw new Exception("Check-out date must be after check-in date.");

            var room = _context.Rooms.Include(r => r.Hotel).FirstOrDefault(r => r.Id == roomId);
            if (room == null)
                throw new Exception("Room does not exist.");

            if (guests > room.Capacity)
                throw new Exception("Number of guests exceeds room capacity.");

            var hotelRooms = _context.Rooms.Count(r => r.HotelId == room.HotelId);
            if (hotelRooms != 6)
                throw new Exception("Hotel must have exactly 6 rooms.");

            if (_context.Bookings.Any(b => b.RoomId == roomId && (b.CheckIn < checkOut && b.CheckOut > checkIn)))
                throw new Exception("Room is already booked for the selected dates.");

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var booking = new Booking
                    {
                        BookingNumber = GenerateBookingNumber(), // ✅ Ensure unique sequential number
                        RoomId = roomId,
                        CheckIn = checkIn,
                        CheckOut = checkOut,
                        Guests = guests
                    };

                    _context.Bookings.Add(booking);
                    _context.SaveChanges();

                    transaction.Commit();
                    return booking;
                }
                catch
                {
                    transaction.Rollback();
                    throw new Exception("An error occurred while creating the booking.");
                }
            }
        }

        /// <summary>
        /// Generates the next sequential booking number to ensure uniqueness.
        /// </summary>
        private int GenerateBookingNumber()
        {
            // Get the last BookingNumber in the database, default to 0 if no bookings exist
            int lastNumber = _context.Bookings.OrderByDescending(b => b.BookingNumber)
                                              .Select(b => b.BookingNumber)
                                              .FirstOrDefault();
            return lastNumber + 1; // ✅ Increment last booking number
        }

        /// <summary>
        /// Retrieves a booking by its booking number.
        /// </summary>
        public Booking GetBookingByNumber(int bookingNumber)
        {
            return _context.Bookings.FirstOrDefault(b => b.BookingNumber == bookingNumber)
                ?? throw new Exception("Booking not found.");
        }
    }
}
