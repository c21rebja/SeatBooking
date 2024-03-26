using System.ComponentModel.DataAnnotations.Schema;

namespace SeatBookingAPI.Models
{
    public class Office
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long OfficeId { get; set; }
        public string? Name { get; set; }
        public string? Layout { get; set; }
        public IEnumerator<Seat> Seats { get; set; }
    }

    public class OfficeDTO
    {
        public string? Name { get; set; }
        public string? Layout { get; set; }
    }
}
