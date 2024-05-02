using airpangea_back.Data;
using airpangea_back.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MyApp.Namespace
{
    [Route("api/airport")]
    [ApiController]
    public class AirportController : ControllerBase
    {
        private readonly DataContext _context;
        public AirportController(DataContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetAirports")]
        public async Task<ActionResult<IEnumerable<Airport>>> GetAirports()
        {
            var airports = await _context.Airports.ToListAsync();

            return airports;
        }

        [HttpGet("by-country-name/{countryName}", Name = "GetAirportsByCountry")]
        public async Task<ActionResult<IEnumerable<Airport>>> GetAirportsByCountry(string countryName)
        {
            var airports = await _context.Airports
                                        .Where(a => a.Country == countryName)
                                        .ToListAsync();

            return airports;
        }

        [HttpGet("{id}", Name = "GetAirport")]
        public async Task<ActionResult<Airport>> GetAirport(int id)
        {
            var airport = await _context.Airports.FirstOrDefaultAsync(b => b.Id == id);

            if (airport == null)
            {
                return NotFound();
            }

            return airport;
        }

        [HttpPost]
        public async Task<ActionResult<Airport>> Post(Airport airport)
        {
            _context.Airports.Add(airport);
            await _context.SaveChangesAsync();

            return new CreatedAtRouteResult("GetAirport", new { id = airport.Id }, airport);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Airport>> Put(int id, Airport airport)
        {
            if (id != airport.Id)
            {
                return BadRequest("El ID proporcionado no coincide con un ID de aeropuerto.");
            }

            _context.Entry(airport).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Airport>> Delete(int id)
        {
            var airport = await _context.Airports.FindAsync(id);

            if (airport == null)
            {
                return NotFound();
            }

            _context.Airports.Remove(airport);
            await _context.SaveChangesAsync();

            return airport;
        }
    }
}
