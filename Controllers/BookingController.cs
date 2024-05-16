using System.Text.RegularExpressions;
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

        public static List<string> ValidateBooking(Booking booking)
        {
            var errors = new List<string>();

            // Validar el campo "fare"
            var allowedFares = new List<string> { "Basic", "Regular", "Plus" };
            if (string.IsNullOrEmpty(booking.Fare) || !allowedFares.Contains(booking.Fare))
            {
                errors.Add("Fare must be one of the following values: Basic, Regular, Plus.");
            }

            // Validar el campo "seat"
            if (string.IsNullOrEmpty(booking.Seat) || !Regex.IsMatch(booking.Seat, "^[A-Z]{1}[1-3]$"))
            {
                errors.Add("Seat must be in the format of one uppercase letter followed by a number between 1 and 3 (e.g., A1, B3).");
            }

            return errors;
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
            var validationErrors = ValidateBooking(booking);
            if (validationErrors.Any())
            {
                return BadRequest(new { message = "Validation failed.", errors = validationErrors });
            }

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            return new CreatedAtRouteResult("GetBooking", new { id = booking.Id }, booking);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Booking>> Put(int id, Booking booking)
        {
            if (id != booking.Id)
            {
                return BadRequest("The provided ID does not match a booking ID.");
            }

            var existingBooking = await _context.Bookings.FindAsync(id);
            if (existingBooking == null)
            {
                return NotFound();
            }

            existingBooking.Fare = booking.Fare;
            existingBooking.Seat = booking.Seat;
            existingBooking.PassengerId = booking.PassengerId;
            existingBooking.FlightId = booking.FlightId;

            // Validar los campos
            var validationErrors = ValidateBooking(existingBooking);
            if (validationErrors.Any())
            {
                return BadRequest(new { message = "Validation failed.", errors = validationErrors });
            }

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
