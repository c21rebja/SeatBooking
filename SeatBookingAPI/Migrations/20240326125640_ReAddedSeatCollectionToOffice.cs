using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeatBookingAPI.Migrations
{
    /// <inheritdoc />
    public partial class ReAddedSeatCollectionToOffice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Seat_OfficeId",
                table: "Seat",
                column: "OfficeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_Office_OfficeId",
                table: "Seat",
                column: "OfficeId",
                principalTable: "Office",
                principalColumn: "OfficeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seat_Office_OfficeId",
                table: "Seat");

            migrationBuilder.DropIndex(
                name: "IX_Seat_OfficeId",
                table: "Seat");
        }
    }
}
