using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BugtrackerHF.Migrations
{
    public partial class made_lots_of_changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MessageViewModel_UserViewModel_UserViewModelId",
                table: "MessageViewModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectViewModel_AdminViewModel_ProjectAdminId",
                table: "ProjectViewModel");

            migrationBuilder.DropForeignKey(
                name: "FK_UserViewModel_AdminViewModel_AdminViewModelId",
                table: "UserViewModel");

            migrationBuilder.DropTable(
                name: "AdminViewModel");

            migrationBuilder.DropTable(
                name: "NotificationViewModels");

            migrationBuilder.DropIndex(
                name: "IX_UserViewModel_AdminViewModelId",
                table: "UserViewModel");

            migrationBuilder.DropIndex(
                name: "IX_ProjectViewModel_ProjectAdminId",
                table: "ProjectViewModel");

            migrationBuilder.DropIndex(
                name: "IX_MessageViewModel_UserViewModelId",
                table: "MessageViewModel");

            migrationBuilder.DropColumn(
                name: "AdminViewModelId",
                table: "UserViewModel");

            migrationBuilder.DropColumn(
                name: "ProjectAdminId",
                table: "ProjectViewModel");

            migrationBuilder.DropColumn(
                name: "ReceiverUserId",
                table: "MessageViewModel");

            migrationBuilder.DropColumn(
                name: "UserViewModelId",
                table: "MessageViewModel");

            migrationBuilder.RenameColumn(
                name: "SenderUserId",
                table: "MessageViewModel",
                newName: "CreatedByUserId");

            migrationBuilder.AddColumn<int>(
                name: "ProjectManagerId",
                table: "ProjectViewModel",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProjectManagerId",
                table: "ProjectViewModel");

            migrationBuilder.RenameColumn(
                name: "CreatedByUserId",
                table: "MessageViewModel",
                newName: "SenderUserId");

            migrationBuilder.AddColumn<int>(
                name: "AdminViewModelId",
                table: "UserViewModel",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjectAdminId",
                table: "ProjectViewModel",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReceiverUserId",
                table: "MessageViewModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserViewModelId",
                table: "MessageViewModel",
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
                        principalTable: "UserViewModel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserViewModel_AdminViewModelId",
                table: "UserViewModel",
                column: "AdminViewModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectViewModel_ProjectAdminId",
                table: "ProjectViewModel",
                column: "ProjectAdminId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageViewModel_UserViewModelId",
                table: "MessageViewModel",
                column: "UserViewModelId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationViewModels_UserViewModelId",
                table: "NotificationViewModels",
                column: "UserViewModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_MessageViewModel_UserViewModel_UserViewModelId",
                table: "MessageViewModel",
                column: "UserViewModelId",
                principalTable: "UserViewModel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectViewModel_AdminViewModel_ProjectAdminId",
                table: "ProjectViewModel",
                column: "ProjectAdminId",
                principalTable: "AdminViewModel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserViewModel_AdminViewModel_AdminViewModelId",
                table: "UserViewModel",
                column: "AdminViewModelId",
                principalTable: "AdminViewModel",
                principalColumn: "Id");
        }
    }
}
