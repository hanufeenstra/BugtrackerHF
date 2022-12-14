using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BugtrackerHF.Migrations
{
    public partial class add_sub_user_list : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserViewModelId",
                table: "UserViewModel",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IssueName",
                table: "IssueViewModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserViewModel_UserViewModelId",
                table: "UserViewModel",
                column: "UserViewModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserViewModel_UserViewModel_UserViewModelId",
                table: "UserViewModel",
                column: "UserViewModelId",
                principalTable: "UserViewModel",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserViewModel_UserViewModel_UserViewModelId",
                table: "UserViewModel");

            migrationBuilder.DropIndex(
                name: "IX_UserViewModel_UserViewModelId",
                table: "UserViewModel");

            migrationBuilder.DropColumn(
                name: "UserViewModelId",
                table: "UserViewModel");

            migrationBuilder.AlterColumn<string>(
                name: "IssueName",
                table: "IssueViewModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
