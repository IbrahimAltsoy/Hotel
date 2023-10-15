using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CategoryMessageId",
                table: "Contacts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CategoryMessages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryMessages", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_CategoryMessageId",
                table: "Contacts",
                column: "CategoryMessageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_CategoryMessages_CategoryMessageId",
                table: "Contacts",
                column: "CategoryMessageId",
                principalTable: "CategoryMessages",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_CategoryMessages_CategoryMessageId",
                table: "Contacts");

            migrationBuilder.DropTable(
                name: "CategoryMessages");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_CategoryMessageId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "CategoryMessageId",
                table: "Contacts");
        }
    }
}
