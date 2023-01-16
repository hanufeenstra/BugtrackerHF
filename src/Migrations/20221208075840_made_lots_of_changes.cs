#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace BugtrackerHF.Migrations
{
    public partial class made_lots_of_changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MessageViewModel_UserViewModel_UserViewModelId",
                table: "MessageModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectViewModel_AdminViewModel_ProjectAdminId",
                table: "ProjectModel");

            migrationBuilder.DropForeignKey(
                name: "FK_UserViewModel_AdminViewModel_AdminViewModelId",
                table: "UserModel");

            migrationBuilder.DropTable(
                name: "AdminViewModel");

            migrationBuilder.DropTable(
                name: "NotificationViewModels");

            migrationBuilder.DropIndex(
                name: "IX_UserViewModel_AdminViewModelId",
                table: "UserModel");

            migrationBuilder.DropIndex(
                name: "IX_ProjectViewModel_ProjectAdminId",
                table: "ProjectModel");

            migrationBuilder.DropIndex(
                name: "IX_MessageViewModel_UserViewModelId",
                table: "MessageModel");

            migrationBuilder.DropColumn(
                name: "AdminViewModelId",
                table: "UserModel");

            migrationBuilder.DropColumn(
                name: "ProjectAdminId",
                table: "ProjectModel");

            migrationBuilder.DropColumn(
                name: "ReceiverUserId",
                table: "MessageModel");

            migrationBuilder.DropColumn(
                name: "UserViewModelId",
                table: "MessageModel");

            migrationBuilder.RenameColumn(
                name: "SenderUserId",
                table: "MessageModel",
                newName: "CreatedByUserId");

            migrationBuilder.AddColumn<int>(
                name: "ProjectManagerId",
                table: "ProjectModel",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProjectManagerId",
                table: "ProjectModel");

            migrationBuilder.RenameColumn(
                name: "CreatedByUserId",
                table: "MessageModel",
                newName: "SenderUserId");

            migrationBuilder.AddColumn<int>(
                name: "AdminViewModelId",
                table: "UserModel",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjectAdminId",
                table: "ProjectModel",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReceiverUserId",
                table: "MessageModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserViewModelId",
                table: "MessageModel",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AdminViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthZeroId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminViewModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NotificationViewModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserViewModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationViewModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotificationViewModels_UserViewModel_UserViewModelId",
                        column: x => x.UserViewModelId,
                        principalTable: "UserModel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserViewModel_AdminViewModelId",
                table: "UserModel",
                column: "AdminViewModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectViewModel_ProjectAdminId",
                table: "ProjectModel",
                column: "ProjectAdminId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageViewModel_UserViewModelId",
                table: "MessageModel",
                column: "UserViewModelId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationViewModels_UserViewModelId",
                table: "NotificationViewModels",
                column: "UserViewModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_MessageViewModel_UserViewModel_UserViewModelId",
                table: "MessageModel",
                column: "UserViewModelId",
                principalTable: "UserModel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectViewModel_AdminViewModel_ProjectAdminId",
                table: "ProjectModel",
                column: "ProjectAdminId",
                principalTable: "AdminViewModel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserViewModel_AdminViewModel_AdminViewModelId",
                table: "UserModel",
                column: "AdminViewModelId",
                principalTable: "AdminViewModel",
                principalColumn: "Id");
        }
    }
}
