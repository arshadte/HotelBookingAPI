using HotelBookingAPI.Data;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagementController : ControllerBase
    {
        private readonly HotelDbContext _context;

        public ManagementController(HotelDbContext context)
        {
            _context = context;
        }

        [HttpPost("seed")]
        public IActionResult SeedDatabase()
        {
            DatabaseSeeder.Seed(_context);
            return Ok("Database has been seeded.");
        }

        [HttpPost("reset")]
        public IActionResult ResetDatabase()
        {
            DatabaseSeeder.Reset(_context);
            return Ok("Database has been reset.");
        }
    }

}
