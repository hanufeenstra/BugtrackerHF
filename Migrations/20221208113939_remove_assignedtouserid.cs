using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BugtrackerHF.Migrations
{
    public partial class remove_assignedtouserid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssignedToUserId",
                table: "IssueViewModel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AssignedToUserId",
                table: "IssueViewModel",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
