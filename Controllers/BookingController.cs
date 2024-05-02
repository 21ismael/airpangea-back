using airpangea_back.Data;
using airpangea_back.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MyApp.Namespace
{
    [Route("api/booking")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly DataContext _context;
        public BookingController(DataContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetBookings")]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBookings()
        {
            var bookings = await _context.Bookings
                                        .Include(b => b.Flight)
                                        .ToListAsync();

            return bookings;
        }

        [HttpGet("{id}", Name = "GetBooking")]
        public async Task<ActionResult<Booking>> GetBooking(int id)
        {
            var booking = await _context.Bookings
                            .Include(b => b.Flight)
                            .FirstOrDefaultAsync(b => b.Id == id);

            if (booking == null)
            {
                return NotFound();
            }

            return booking;
        }

        [HttpPost]
        public async Task<ActionResult<Booking>> Post(Booking booking)
        {
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            return new CreatedAtRouteResult("GetBooking", new { id = booking.Id }, booking);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Booking>> Put(int id, Booking booking)
        {
            if (id != booking.Id)
            {
                return BadRequest("El ID proporcionado no coincide con un ID de reserva.");
            }

            _context.Entry(booking).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Booking>> Delete(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);

            if (booking == null)
            {
                return NotFound();
            }

            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();

            return booking;
        }
    }
}
