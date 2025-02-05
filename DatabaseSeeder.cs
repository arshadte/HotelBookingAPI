using HotelBookingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelBookingAPI.Data
{
    /// <summary>
    /// Provides functionality for seeding initial data into the database.
    /// </summary>
    public static class DatabaseSeeder
    {
        /// <summary>
        /// Seeds the database with initial hotel, room, and booking data.
        /// </summary>
        /// <param name="context">The database context</param>
        public static void Seed(HotelDbContext context)
        {
            if (!context.Hotels.Any())
            {
                var hotel = new Hotel { Name = "The Savoy" };
                context.Hotels.Add(hotel);
                context.SaveChanges();

                var rooms = new List<Room>
                {
                    new Room { Type = "single", Capacity = 1, HotelId = hotel.Id }, // ✅ Enforcing lowercase room types
                    new Room { Type = "double", Capacity = 2, HotelId = hotel.Id },
                    new Room { Type = "deluxe", Capacity = 3, HotelId = hotel.Id },
                    new Room { Type = "single", Capacity = 1, HotelId = hotel.Id },
                    new Room { Type = "double", Capacity = 2, HotelId = hotel.Id },
                    new Room { Type = "deluxe", Capacity = 3, HotelId = hotel.Id }
                };

                context.Rooms.AddRange(rooms);
                context.SaveChanges();
            }

            var bookedRooms = context.Rooms.ToList();

            if (!context.Bookings.Any())
            {
                var lastBookingNumber = context.Bookings.OrderByDescending(b => b.BookingNumber)
                                       .Select(b => b.BookingNumber).FirstOrDefault(); // ✅ Get last booking number

                var bookings = new List<Booking>
                {
                    new Booking
                    {
                        RoomId = bookedRooms[0].Id,
                        CheckIn = DateTime.Today.AddDays(1),
                        CheckOut = DateTime.Today.AddDays(3),
                        Guests = 1
                    },
                    new Booking
                    {
                        RoomId = bookedRooms[1].Id,
                        CheckIn = DateTime.Today.AddDays(2),
                        CheckOut = DateTime.Today.AddDays(4),
                        Guests = 2
                    },
                    new Booking
                    {
                        RoomId = bookedRooms[2].Id,
                        CheckIn = DateTime.Today.AddDays(5),
                        CheckOut = DateTime.Today.AddDays(7),
                        Guests = 3
                    }
                };

                context.Bookings.AddRange(bookings);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Resets the database by removing all bookings and preparing for reseeding.
        /// </summary>
        /// <param name="context">The database context</param>
        public static void Reset(HotelDbContext context)
        {
            context.Bookings.RemoveRange(context.Bookings);
            context.SaveChanges();

            Seed(context);
        }
    }
}
