using System.Text.RegularExpressions;
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

        public static List<string> ValidateAirport(Airport airport)
        {
            var errors = new List<string>();

            // Validar el campo "IATA"
            if (string.IsNullOrEmpty(airport.IATA) || airport.IATA.Length != 3 || !Regex.IsMatch(airport.IATA, "^[A-Z]{3}$"))
            {
                errors.Add("IATA code must be a string of 3 uppercase letters (A-Z).");
            }

            // Validar el campo "name"
            if (string.IsNullOrEmpty(airport.Name) || airport.Name == "string")
            {
                errors.Add("Name is required.");
            }

            // Validar el campo "city"
            if (string.IsNullOrEmpty(airport.City) || airport.City == "string")
            {
                errors.Add("City is required.");
            }

            // Validar el campo "country"
            if (string.IsNullOrEmpty(airport.Country) || airport.Country == "string")
            {
                errors.Add("Country is required.");
            }

            return errors;
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
            var validationErrors = ValidateAirport(airport);
            if (validationErrors.Any())
            {
                return BadRequest(new { message = "Validation failed.", errors = validationErrors });
            }

            _context.Airports.Add(airport);
            await _context.SaveChangesAsync();

            return new CreatedAtRouteResult("GetAirport", new { id = airport.Id }, airport);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Airport>> Put(int id, Airport airport)
        {
            if (id != airport.Id)
            {
                return BadRequest("The provided ID does not match the airport ID.");
            }

            var existingAirport = await _context.Airports.FindAsync(id);
            if (existingAirport == null)
            {
                return NotFound();
            }

            existingAirport.IATA = airport.IATA;
            existingAirport.Name = airport.Name;
            existingAirport.City = airport.City;
            existingAirport.Country = airport.Country;

            // Validar los campos
            var validationErrors = ValidateAirport(existingAirport);
            if (validationErrors.Any())
            {
                return BadRequest(new { message = "Validation failed.", errors = validationErrors });
            }

            await _context.SaveChangesAsync();

            return Ok();
        }


        /*
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Put(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest(new { message = "The provided ID does not match the user ID." });
            }

            var existingUser = await _context.Users.FindAsync(id);
            if (existingUser == null)
            {
                return NotFound();
            }

            // Actualizar los campos de la entidad existente
            existingUser.Email = user.Email;
            existingUser.Password = user.Password;
            existingUser.Name = user.Name;
            existingUser.LastName = user.LastName;

            // Validar los campos
            var validationErrors = ValidateUser(existingUser);
            if (validationErrors.Any())
            {
                return BadRequest(new { message = "Validation failed.", errors = validationErrors });
            }

            await _context.SaveChangesAsync();

            return Ok();
        }
        */

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
