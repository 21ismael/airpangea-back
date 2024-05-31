using airpangea_back.Data;
using airpangea_back.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MyApp.Namespace
{
    [Route("api/flight")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly DataContext _context;
        public FlightController(DataContext context)
        {
            _context = context;
        }

        private static List<string> ValidateFlight(Flight flight)
        {
            var errors = new List<string>();

            // Validar el campo "seats"
            if (string.IsNullOrEmpty(flight.Seats) || flight.Seats.Length != 40 || !flight.Seats.All(c => c == 'O' || c == 'X' || c == ' '))
            {
                errors.Add("Seats must be a string of 40 characters containing only 'O', 'X' and ' '.");
            }

            // Validar el campo "price"
            if (flight.Price < 0)
            {
                errors.Add("Price must be equal to or greater than 0.");
            }

            // Validar el campo "status"
            var allowedStatus = new List<string> { "Scheduled", "En route", "Delayed", "Cancelled", "Completed" };
            if (!allowedStatus.Contains(flight.Status))
            {
                errors.Add("Status must be one of the following values: Scheduled, En route, Delayed, Cancelled, Completed.");
            }

            // Validar fechas
            DateTime currentDate = DateTime.UtcNow.Date;
            if (flight.DepartureDateTime.Date < currentDate)
            {
                errors.Add("Departure date must be in the future.");
            }

            if (flight.ArrivalDateTime <= flight.DepartureDateTime)
            {
                errors.Add("Arrival date must be later than departure date.");
            }

            // Validar IDs de aeropuertos
            if (flight.AirportDepartureId == flight.AirportArrivalId)
            {
                errors.Add("Departure and arrival airports must be different.");
            }

            return errors;
        }

        [HttpGet(Name = "GetFlights")]
        public async Task<ActionResult<IEnumerable<Flight>>> GetFlights()
        {
            var flights = await _context.Flights
                .Include(f => f.AirportDeparture)
                .Include(f => f.AirportArrival)
                .ToListAsync();

            return flights;
        }

        [HttpGet("{id}", Name = "GetFlight")]
        public async Task<ActionResult<Flight>> GetFlight(int id)
        {
            var flight = await _context.Flights
                .Include(f => f.AirportDeparture)
                .Include(f => f.AirportArrival)
                .FirstOrDefaultAsync(f => f.Id == id);

            if (flight == null)
            {
                return NotFound();
            }

            return flight;
        }

        [HttpGet("scheduled", Name = "GetScheduledFlights")]
        public async Task<ActionResult<IEnumerable<Flight>>> GetScheduledFlights()
        {
            var scheduledFlights = await _context.Flights
                .Where(f => f.Status == "Scheduled")
                .Include(f => f.AirportDeparture)
                .Include(f => f.AirportArrival)
                .ToListAsync();

            return scheduledFlights;
        }

        [HttpPost]
        public async Task<ActionResult<Flight>> Post(Flight flight)
        {
            // Validar los campos
            var validationErrors = ValidateFlight(flight);
            if (validationErrors.Any())
            {
                return BadRequest(new { message = "Validation failed.", errors = validationErrors });
            }

            _context.Flights.Add(flight);
            await _context.SaveChangesAsync();

            return new CreatedAtRouteResult("GetFlight", new { id = flight.Id }, flight);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<Flight>> Put(int id, Flight flight)
        {
            if (id != flight.Id)
            {
                return BadRequest("The provided ID does not match the flight ID.");
            }

            var existingFlight = await _context.Flights.FindAsync(id);
            if (existingFlight == null)
            {
                return NotFound();
            }

            existingFlight.AirportArrivalId = flight.AirportArrivalId;
            existingFlight.AirportDepartureId = flight.AirportDepartureId;
            existingFlight.ArrivalDateTime = flight.ArrivalDateTime;
            existingFlight.DepartureDateTime = flight.DepartureDateTime;
            existingFlight.Price = flight.Price;
            existingFlight.Seats = flight.Seats;
            existingFlight.Status = flight.Status;

            var validationErrors = ValidateFlight(existingFlight);
            if (validationErrors.Any())
            {
                return BadRequest(new { message = "Validation failed.", errors = validationErrors });
            }

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Flight>> Delete(int id)
        {
            var flight = await _context.Flights.FindAsync(id);

            if (flight == null)
            {
                return NotFound();
            }

            _context.Flights.Remove(flight);
            await _context.SaveChangesAsync();

            return flight;
        }
    }
}
