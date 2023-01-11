#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace BugtrackerHF.Migrations
{
    public partial class remove_assignedtouserid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssignedToUserId",
                table: "IssueModel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AssignedToUserId",
                table: "IssueModel",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
