using Mono.TextTemplating;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeatBookingAPI.Models
{
    public class Seat
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long SeatId { get; set; }
        public long OfficeId { get; set; }
        public int State { get; set; }  // 0 = Free, 1 = Booked
    }

    public class SeatDTO
    {
        public int State { get; set; }
    }
}
