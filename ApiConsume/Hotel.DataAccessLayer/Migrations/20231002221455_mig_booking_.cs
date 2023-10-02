using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_booking_ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Bookings",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Bookings");
        }
    }
}
