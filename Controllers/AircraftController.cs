using airpangea_back.Data;
using airpangea_back.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MyApp.Namespace
{
    [Route("api/aircraft")]
    [ApiController]
    public class AircraftController : ControllerBase
    {
        private readonly DataContext _context;
        public AircraftController(DataContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetAircrafts")]
        public async Task<ActionResult<IEnumerable<Aircraft>>> GetAircrafts()
        {
            var aircrafts = await _context.Aircrafts.ToListAsync();

            return aircrafts;
        }

        [HttpGet("{id}", Name = "GetAircraft")]
        public async Task<ActionResult<Aircraft>> GetAircraft(int id)
        {
            var aircraft = await _context.Aircrafts.FirstOrDefaultAsync(b => b.Id == id);

            if (aircraft == null)
            {
                return NotFound();
            }

            return aircraft;
        }

        [HttpPost]
        public async Task<ActionResult<Aircraft>> Post(Aircraft aircraft)
        {
            _context.Aircrafts.Add(aircraft);
            await _context.SaveChangesAsync();

            return new CreatedAtRouteResult("GetAircraft", new { id = aircraft.Id }, aircraft);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Aircraft>> Put(int id, Aircraft aircraft)
        {
            if (id != aircraft.Id)
            {
                return BadRequest("El ID proporcionado no coincide con un ID de avión.");
            }

            _context.Entry(aircraft).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Aircraft>> Delete(int id)
        {
            var aircraft = await _context.Aircrafts.FindAsync(id);

            if (aircraft == null)
            {
                return NotFound();
            }

            _context.Aircrafts.Remove(aircraft);
            await _context.SaveChangesAsync();

            return aircraft;
        }

    }
}
