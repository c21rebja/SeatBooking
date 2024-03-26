using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeatBookingAPI.Models;

namespace SeatBookingAPI.Controllers
{
    [Route("api/Offices")]
    [ApiController]
    public class OfficesController : ControllerBase
    {
        private readonly SeatBookingContext _context;

        public OfficesController(SeatBookingContext context)
        {
            _context = context;
        }

        // GET: api/Offices
        // Get all offices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Office>>> GetOffice()
        {
            return await _context.Office.ToListAsync();
        }

        // GET: api/Offices/5
        // Get office by id
        [HttpGet("{id}")]
        public async Task<ActionResult<Office>> GetOffice(long id)
        {
            var office = await _context.Office.FirstOrDefaultAsync(o => o.OfficeId == id);

            if (office == null) return NotFound();

            return office;
        }

        // PUT: api/Offices/5
        // Update office by id
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOffice(long id, OfficeDTO officeDTO)
        {
            var office = await _context.Office.FirstOrDefaultAsync(o => o.OfficeId == id);

            if (office == null) return NotFound();

            if(office.Name != officeDTO.Name) office.Name = officeDTO.Name;
            if(office.Layout != officeDTO.Layout) office.Layout = officeDTO.Layout;

            _context.Office.Update(office);
            _context.Entry(office).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Offices
        // Add a new office
        [HttpPost]
        public async Task<ActionResult<Office>> PostOffice(OfficeDTO officeDTO)
        {
            Office office = new()
            {
                Name = officeDTO.Name,
                Layout = officeDTO.Layout
            };
            _context.Office.Add(office);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOffice), new { id = office.OfficeId }, office);
        }

        // DELETE: api/Offices/5
        // Remove an office by id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOffice(long id)
        {
            var office = await _context.Office.FirstOrDefaultAsync(o => o.OfficeId == id);

            if (office == null) return NotFound();

            _context.Office.Remove(office);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
