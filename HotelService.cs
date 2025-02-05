using HotelBookingAPI.Data;
using HotelBookingAPI.Models;

using HotelBookingAPI.Services;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Implementation of hotel-related services.
/// </summary>
public class HotelService : IHotelService
{
    private readonly HotelDbContext _context;

    public HotelService(HotelDbContext context)
    {
        _context = context;
    }

    public Hotel GetHotelByName(string name) =>
        _context.Hotels.Include(h => h.Rooms).FirstOrDefault(h => h.Name == name);

    public List<Room> GetAvailableRooms(DateTime checkIn, DateTime checkOut, int guests)
    {
        return _context.Rooms.Where(r =>
            r.Capacity >= guests &&
            !_context.Bookings.Any(b => b.RoomId == r.Id &&
                                        ((b.CheckIn <= checkOut && b.CheckOut >= checkIn))))
            .ToList();
    }
}