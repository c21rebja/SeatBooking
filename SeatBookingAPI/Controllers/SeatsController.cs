using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeatBookingAPI.Models;

namespace SeatBookingAPI.Controllers
{
    [Route("api/Seats")]
    [ApiController]
    public class SeatsController : ControllerBase
    {
        private readonly SeatBookingContext _context;

        public SeatsController(SeatBookingContext context)
        {
            _context = context;
        }

        // GET: api/Seats
        // Get all seats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Seat>>> GetSeat()
        {
            return await _context.Seat.ToListAsync();
        }


        // GET: api/Seats/Office/5
        // Get all seats connected to an office
        [HttpGet("office/{id}")]
        public async Task<ActionResult<IEnumerable<Seat>>> GetOfficeSeats(long id)
        {
            return await _context.Seat.Where(s => s.OfficeId == id)
                .ToListAsync();
        }

        // GET: api/Seats/5
        // Get a seat by id
        [HttpGet("{id}")]
        public async Task<ActionResult<Seat>> GetSeat(long id)
        {
            var seat = await _context.Seat.FirstOrDefaultAsync(s => s.SeatId == id);

            if (seat == null) return NotFound();

            return seat;
        }

        // PUT: api/Seats/5
        // Update seat by id
        [HttpPut("{id}")]
        public async Task<ActionResult<Seat>> PutSeat(long id, SeatDTO seatDTO)
        {
            var seat = await _context.Seat.FirstOrDefaultAsync(s => s.SeatId == id);

            if (seat == null) return NotFound();

            if (seat.UserId != seatDTO.UserId) seat.UserId = seatDTO.UserId;
            if (seat.State != seatDTO.State) seat.State = seatDTO.State;
            if (seat.Layout != seatDTO.Layout && seatDTO.Layout != null) seat.Layout = seatDTO.Layout;
            
            _context.Seat.Update(seat);
            _context.Entry(seat).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return seat;
        }

        // POST: api/Seats
        // Create new seat
        [HttpPost]
        public async Task<ActionResult<Seat>> PostSeat(long officeId, SeatDTO seatDTO)
        {
            Seat seat = new()
            {
                OfficeId = officeId,
                State = seatDTO.State,
                Layout = seatDTO.Layout,
            };
            _context.Seat.Add(seat);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSeat), new { id = seat.SeatId }, seat);
        }

        // DELETE: api/Seats/5
        // Delete seat by id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeat(long id)
        {
            var seat = await _context.Seat.FindAsync(id);
            if (seat == null)
            {
                return NotFound();
            }

            _context.Seat.Remove(seat);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
