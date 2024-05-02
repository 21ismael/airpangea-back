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
            _context.Passengers.Add(passenger);
            await _context.SaveChangesAsync();

            return new CreatedAtRouteResult("GetPassenger", new { id = passenger.Id }, passenger);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Passenger>> Put(int id, Passenger passenger)
        {
            if (id != passenger.Id)
            {
                return BadRequest("El ID proporcionado no coincide con el ID del pasajero.");
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
