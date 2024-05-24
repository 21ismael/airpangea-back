using airpangea_back.Data;
using airpangea_back.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MyApp.Namespace
{
    [Authorize]
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;
        public UserController(DataContext context)
        {
            _context = context;
        }

        private static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private static List<string> ValidateUser(User user)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(user.Email))
            {
                errors.Add("Email cannot be an empty string.");
            }
            else if (!IsValidEmail(user.Email))
            {
                errors.Add("Email is not in a valid format.");
            }

            if (string.IsNullOrWhiteSpace(user.Password))
            {
                errors.Add("Password cannot be an empty string.");
            }
            else if (user.Password.Length <= 4)
            {
                errors.Add("Password must be more than 4 characters long.");
            }

            if (string.IsNullOrWhiteSpace(user.Name))
            {
                errors.Add("Name cannot be an empty string.");
            }

            if (string.IsNullOrWhiteSpace(user.LastName))
            {
                errors.Add("LastName cannot be an empty string.");
            }

            return errors;
        }

        [HttpGet(Name = "GetUsers")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _context.Users
                                .Include(u => u.Passengers)
                                .ToListAsync();

            return users;
        }

        [HttpGet("{id}", Name = "GetUser")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost]
        public async Task<ActionResult<User>> Post(User user)
        {
            // Validar los campos
            var validationErrors = ValidateUser(user);
            if (validationErrors.Any())
            {
                return BadRequest(new { message = "Validation failed.", errors = validationErrors });
            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new CreatedAtRouteResult("GetUser", new { id = user.Id }, user);
        }

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


        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }
    }
}
