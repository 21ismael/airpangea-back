using airpangea_back.Data;
using airpangea_back.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MyApp.Namespace
{
    [Route("api/passenger")]
    [ApiController]
    public class PassengerController : ControllerBase
    {
        private readonly DataContext _context;
        public PassengerController(DataContext context)
        {
            _context = context;
        }

        private static List<string> ValidatePassenger(Passenger passenger)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(passenger.Name))
            {
                errors.Add("Name cannot be an empty string.");
            }

            if (string.IsNullOrWhiteSpace(passenger.LastName))
            {
                errors.Add("LastName cannot be an empty string.");
            }

            if (string.IsNullOrWhiteSpace(passenger.IdentityNumber))
            {
                errors.Add("IdentityNumber cannot be an empty string.");
            }

            return errors;
        }

        [HttpGet(Name = "GetPassengers")]
        public async Task<ActionResult<IEnumerable<Passenger>>> GetPassengers()
        {
            var passengers = await _context.Passengers
                                            .Include(p => p.User)
                                            .Include(p => p.Bookings)
                                            .ThenInclude(b => b.Flight)
                                            .ToListAsync();

            return passengers;
        }

        [HttpGet("{id}", Name = "GetPassenger")]
        public async Task<ActionResult<Passenger>> GetPassenger(int id)
        {
            var passenger = await _context.Passengers.FindAsync(id);

            if (passenger == null)
            {
                return NotFound();
            }

            return passenger;
        }

       [HttpPost]
        public async Task<ActionResult<Passenger>> Post(Passenger passenger)
        {
            // Verificar si el usuario existe
            var user = await _context.Users.FindAsync(passenger.UserId);
            if (user == null)
            {
                return NotFound(new { message = $"User with ID {passenger.UserId} doesn't exist." });
            }

            // Validar los campos
            var validationErrors = ValidatePassenger(passenger);
            if (validationErrors.Any())
            {
                return BadRequest(new { message = "Validation failed.", errors = validationErrors });
            }

            _context.Passengers.Add(passenger);
            await _context.SaveChangesAsync();

            return new CreatedAtRouteResult("GetPassenger", new { id = passenger.Id }, passenger);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Passenger>> Put(int id, Passenger passenger)
        {
            if (id != passenger.Id)
            {
                return BadRequest(new { message = "The provided ID does not match the passenger ID." });
            }

            var existingPassenger = await _context.Passengers.FindAsync(id);
            if (existingPassenger == null)
            {
                return NotFound();
            }

            // Validar los campos
            var validationErrors = ValidatePassenger(passenger);
            if (validationErrors.Any())
            {
                return BadRequest(new { message = "Validation failed.", errors = validationErrors });
            }

            _context.Entry(passenger).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Passenger>> Delete(int id)
        {
            var passenger = await _context.Passengers.FindAsync(id);

            if (passenger == null)
            {
                return NotFound();
            }

            _context.Passengers.Remove(passenger);
            await _context.SaveChangesAsync();

            return passenger;
        }
    }
}
