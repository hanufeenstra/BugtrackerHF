using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BugtrackerHF.Migrations
{
    public partial class hometest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserRole",
                table: "UserViewModel",
                type: "int",
                nullable: true);
                //oldClrType: typeof(int),
                //oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UserViewModelId",
                table: "NotificationViewModels",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IssueViewModelId",
                table: "MessageViewModel",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserViewModelId",
                table: "MessageViewModel",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserViewModelId",
                table: "IssueViewModel",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NotificationViewModels_UserViewModelId",
                table: "NotificationViewModels",
                column: "UserViewModelId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageViewModel_IssueViewModelId",
                table: "MessageViewModel",
                column: "IssueViewModelId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageViewModel_UserViewModelId",
                table: "MessageViewModel",
                column: "UserViewModelId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueViewModel_UserViewModelId",
                table: "IssueViewModel",
                column: "UserViewModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_IssueViewModel_UserViewModel_UserViewModelId",
                table: "IssueViewModel",
                column: "UserViewModelId",
                principalTable: "UserViewModel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MessageViewModel_IssueViewModel_IssueViewModelId",
                table: "MessageViewModel",
                column: "IssueViewModelId",
                principalTable: "IssueViewModel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MessageViewModel_UserViewModel_UserViewModelId",
                table: "MessageViewModel",
                column: "UserViewModelId",
                principalTable: "UserViewModel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NotificationViewModels_UserViewModel_UserViewModelId",
                table: "NotificationViewModels",
                column: "UserViewModelId",
                principalTable: "UserViewModel",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IssueViewModel_UserViewModel_UserViewModelId",
                table: "IssueViewModel");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageViewModel_IssueViewModel_IssueViewModelId",
                table: "MessageViewModel");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageViewModel_UserViewModel_UserViewModelId",
                table: "MessageViewModel");

            migrationBuilder.DropForeignKey(
                name: "FK_NotificationViewModels_UserViewModel_UserViewModelId",
                table: "NotificationViewModels");

            migrationBuilder.DropIndex(
                name: "IX_NotificationViewModels_UserViewModelId",
                table: "NotificationViewModels");

            migrationBuilder.DropIndex(
                name: "IX_MessageViewModel_IssueViewModelId",
                table: "MessageViewModel");

            migrationBuilder.DropIndex(
                name: "IX_MessageViewModel_UserViewModelId",
                table: "MessageViewModel");

            migrationBuilder.DropIndex(
                name: "IX_IssueViewModel_UserViewModelId",
                table: "IssueViewModel");

            migrationBuilder.DropColumn(
                name: "UserViewModelId",
                table: "NotificationViewModels");

            migrationBuilder.DropColumn(
                name: "IssueViewModelId",
                table: "MessageViewModel");

            migrationBuilder.DropColumn(
                name: "UserViewModelId",
                table: "MessageViewModel");

            migrationBuilder.DropColumn(
                name: "UserViewModelId",
                table: "IssueViewModel");

            migrationBuilder.AlterColumn<int>(
                name: "UserRole",
                table: "UserViewModel",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
