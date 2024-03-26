using Microsoft.EntityFrameworkCore;

namespace SeatBookingAPI.Models;

public class SeatBookingContext : DbContext
{
    public SeatBookingContext(DbContextOptions<SeatBookingContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Office> Office { get; set; } = default!;
    public DbSet<Seat> Seat { get; set; } = default!;
}
