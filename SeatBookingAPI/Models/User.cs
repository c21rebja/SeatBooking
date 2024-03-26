using System.ComponentModel.DataAnnotations.Schema;

namespace SeatBookingAPI.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserId { get; set; }
        public int Role { get; set; } // 0 = User, 1 = Admin
        public string? Name { get; set; }
        public long OfficeId { get; set; }
        public Office? Office { get; set; }
    }

    public class UserDTO
    {
        public string? Name { get; set; }
        public long OfficeId { get; set; }
    }

    public class UserRole
    {
        public int Role { get; set; }
    }
}
