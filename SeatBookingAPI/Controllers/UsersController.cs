using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeatBookingAPI.Models;

namespace SeatBookingAPI.Controllers
{
    [Route("api/Users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly SeatBookingContext _context;

        public UsersController(SeatBookingContext context)
        {
            _context = context;
        }

        // GET: api/Users
        // Get all users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        // Get a user by id
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(long id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);

            if (user == null) return NotFound();

            return user;
        }

        // PUT: api/Users/5
        // Update a user by id
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(long id, UserDTO userDTO)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
            
            if (user == null) return NotFound();

            if(user.Name != userDTO.Name) user.Name = userDTO.Name;
            if(user.OfficeId != userDTO.OfficeId) user.OfficeId = userDTO.OfficeId;

            _context.Users.Update(user);
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // PUT: api/Users/5/admin
        // Update the user's role as well as the other settings (should only be accessible by admin)
        [HttpPut("{id}/role")]
        public async Task<IActionResult> PutAdmUser(long id, UserRole admUserSettings)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);

            if(user == null) return NotFound();

            if(user.Role != admUserSettings.Role) user.Role = admUserSettings.Role;

            _context.Users.Update(user);
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Users
        // Add a new user
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(UserDTO userDTO)
        {
            User user = new User()
            {
                Role = 0,
                Name = userDTO.Name,
                OfficeId = userDTO.OfficeId
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new { id = user.UserId }, user);
        }

        // DELETE: api/Users/5
        // Delete a user by id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(long id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound();

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
