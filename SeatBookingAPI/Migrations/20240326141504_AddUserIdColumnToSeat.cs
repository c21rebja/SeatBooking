using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeatBookingAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddUserIdColumnToSeat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "Seat",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Seat");
        }
    }
}
