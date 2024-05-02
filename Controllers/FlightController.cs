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

        [HttpGet(Name = "GetFlights")]
        public async Task<ActionResult<IEnumerable<Flight>>> GetFlights()
        {
            var flights = await _context.Flights
                .Include(f => f.Aircraft)
                .Include(f => f.AirportDeparture)
                .Include(f => f.AirportArrival)
                .ToListAsync();

            return flights;
        }

        [HttpGet("{id}", Name = "GetFlight")]
        public async Task<ActionResult<Flight>> GetFlight(int id)
        {
            var flight = await _context.Flights
                .Include(f => f.Aircraft)
                .Include(f => f.AirportDeparture)
                .Include(f => f.AirportArrival)
                .FirstOrDefaultAsync(f => f.Id == id);

            if (flight == null)
            {
                return NotFound();
            }

            return flight;
        }

        [HttpPost]
        public async Task<ActionResult<Flight>> Post(Flight flight)
        {
            _context.Flights.Add(flight);
            await _context.SaveChangesAsync();

            return new CreatedAtRouteResult("GetFlight", new { id = flight.Id }, flight);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Flight>> Put(int id, Flight flight)
        {
            if (id != flight.Id)
            {
                return BadRequest("El ID proporcionado no coincide con el ID de vuelo.");
            }

            _context.Entry(flight).State = EntityState.Modified;
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
