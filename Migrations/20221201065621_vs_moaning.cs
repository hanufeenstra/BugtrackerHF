using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BugtrackerHF.Migrations
{
    public partial class vs_moaning : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserRole",
                table: "UserViewModel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserRole",
                table: "UserViewModel",
                type: "int",
                nullable: true,
                defaultValue: 0);
        }
    }
}
