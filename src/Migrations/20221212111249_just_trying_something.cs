#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace BugtrackerHF.Migrations
{
    public partial class just_trying_something : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Viewed",
                table: "MessageModel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Viewed",
                table: "MessageModel",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
