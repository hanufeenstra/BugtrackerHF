using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BugtrackerHF.Migrations
{
    public partial class Updated_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IssueViewModel_UserViewModel_UserViewModelAuthZeroId",
                table: "IssueViewModel");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageViewModel_UserViewModel_UserViewModelAuthZeroId",
                table: "MessageViewModel");

            migrationBuilder.DropForeignKey(
                name: "FK_NotificationViewModels_UserViewModel_UserViewModelAuthZeroId",
                table: "NotificationViewModels");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectViewModel_UserViewModel_ProjectAdminAuthZeroId",
                table: "ProjectViewModel");

            migrationBuilder.DropForeignKey(
                name: "FK_UserViewModel_UserViewModel_AdminViewModelAuthZeroId",
                table: "UserViewModel");

            migrationBuilder.DropForeignKey(
                name: "FK_UserViewModel_UserViewModel_AdminViewModelAuthZeroId1",
                table: "UserViewModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserViewModel",
                table: "UserViewModel");

            migrationBuilder.DropIndex(
                name: "IX_UserViewModel_AdminViewModelAuthZeroId",
                table: "UserViewModel");

            migrationBuilder.DropIndex(
                name: "IX_UserViewModel_AdminViewModelAuthZeroId1",
                table: "UserViewModel");

            migrationBuilder.DropIndex(
                name: "IX_ProjectViewModel_ProjectAdminAuthZeroId",
                table: "ProjectViewModel");

            migrationBuilder.DropIndex(
                name: "IX_NotificationViewModels_UserViewModelAuthZeroId",
                table: "NotificationViewModels");

            migrationBuilder.DropIndex(
                name: "IX_MessageViewModel_UserViewModelAuthZeroId",
                table: "MessageViewModel");

            migrationBuilder.DropIndex(
                name: "IX_IssueViewModel_UserViewModelAuthZeroId",
                table: "IssueViewModel");

            migrationBuilder.DropColumn(
                name: "AdminViewModelAuthZeroId",
                table: "UserViewModel");

            migrationBuilder.DropColumn(
                name: "AdminViewModelAuthZeroId1",
                table: "UserViewModel");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "UserViewModel");

            migrationBuilder.DropColumn(
                name: "ProjectAdminAuthZeroId",
                table: "ProjectViewModel");

            migrationBuilder.DropColumn(
                name: "UserViewModelAuthZeroId",
                table: "NotificationViewModels");

            migrationBuilder.DropColumn(
                name: "UserViewModelAuthZeroId",
                table: "MessageViewModel");

            migrationBuilder.DropColumn(
                name: "UserViewModelAuthZeroId",
                table: "IssueViewModel");

            migrationBuilder.AlterColumn<string>(
                name: "AuthZeroId",
                table: "UserViewModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserViewModel",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

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
                name: "UserViewModelId",
                table: "NotificationViewModels",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SenderUserId",
                table: "MessageViewModel",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "ReceiverUserId",
                table: "MessageViewModel",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserViewModelId",
                table: "MessageViewModel",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ReportedByUserId",
                table: "IssueViewModel",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IssueName",
                table: "IssueViewModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "CurrentStatus",
                table: "IssueViewModel",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AssignedToUserId",
                table: "IssueViewModel",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserViewModelId",
                table: "IssueViewModel",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserViewModel",
                table: "UserViewModel",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AdminViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminViewModel", x => x.Id);
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
                name: "IX_NotificationViewModels_UserViewModelId",
                table: "NotificationViewModels",
                column: "UserViewModelId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IssueViewModel_UserViewModel_UserViewModelId",
                table: "IssueViewModel");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageViewModel_UserViewModel_UserViewModelId",
                table: "MessageViewModel");

            migrationBuilder.DropForeignKey(
                name: "FK_NotificationViewModels_UserViewModel_UserViewModelId",
                table: "NotificationViewModels");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectViewModel_AdminViewModel_ProjectAdminId",
                table: "ProjectViewModel");

            migrationBuilder.DropForeignKey(
                name: "FK_UserViewModel_AdminViewModel_AdminViewModelId",
                table: "UserViewModel");

            migrationBuilder.DropTable(
                name: "AdminViewModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserViewModel",
                table: "UserViewModel");

            migrationBuilder.DropIndex(
                name: "IX_UserViewModel_AdminViewModelId",
                table: "UserViewModel");

            migrationBuilder.DropIndex(
                name: "IX_ProjectViewModel_ProjectAdminId",
                table: "ProjectViewModel");

            migrationBuilder.DropIndex(
                name: "IX_NotificationViewModels_UserViewModelId",
                table: "NotificationViewModels");

            migrationBuilder.DropIndex(
                name: "IX_MessageViewModel_UserViewModelId",
                table: "MessageViewModel");

            migrationBuilder.DropIndex(
                name: "IX_IssueViewModel_UserViewModelId",
                table: "IssueViewModel");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserViewModel");

            migrationBuilder.DropColumn(
                name: "AdminViewModelId",
                table: "UserViewModel");

            migrationBuilder.DropColumn(
                name: "ProjectAdminId",
                table: "ProjectViewModel");

            migrationBuilder.DropColumn(
                name: "UserViewModelId",
                table: "NotificationViewModels");

            migrationBuilder.DropColumn(
                name: "UserViewModelId",
                table: "MessageViewModel");

            migrationBuilder.DropColumn(
                name: "UserViewModelId",
                table: "IssueViewModel");

            migrationBuilder.AlterColumn<string>(
                name: "AuthZeroId",
                table: "UserViewModel",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdminViewModelAuthZeroId",
                table: "UserViewModel",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdminViewModelAuthZeroId1",
                table: "UserViewModel",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "UserViewModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProjectAdminAuthZeroId",
                table: "ProjectViewModel",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserViewModelAuthZeroId",
                table: "NotificationViewModels",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SenderUserId",
                table: "MessageViewModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReceiverUserId",
                table: "MessageViewModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserViewModelAuthZeroId",
                table: "MessageViewModel",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReportedByUserId",
                table: "IssueViewModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IssueName",
                table: "IssueViewModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CurrentStatus",
                table: "IssueViewModel",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AssignedToUserId",
                table: "IssueViewModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserViewModelAuthZeroId",
                table: "IssueViewModel",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserViewModel",
                table: "UserViewModel",
                column: "AuthZeroId");

            migrationBuilder.CreateIndex(
                name: "IX_UserViewModel_AdminViewModelAuthZeroId",
                table: "UserViewModel",
                column: "AdminViewModelAuthZeroId");

            migrationBuilder.CreateIndex(
                name: "IX_UserViewModel_AdminViewModelAuthZeroId1",
                table: "UserViewModel",
                column: "AdminViewModelAuthZeroId1");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectViewModel_ProjectAdminAuthZeroId",
                table: "ProjectViewModel",
                column: "ProjectAdminAuthZeroId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationViewModels_UserViewModelAuthZeroId",
                table: "NotificationViewModels",
                column: "UserViewModelAuthZeroId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageViewModel_UserViewModelAuthZeroId",
                table: "MessageViewModel",
                column: "UserViewModelAuthZeroId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueViewModel_UserViewModelAuthZeroId",
                table: "IssueViewModel",
                column: "UserViewModelAuthZeroId");

            migrationBuilder.AddForeignKey(
                name: "FK_IssueViewModel_UserViewModel_UserViewModelAuthZeroId",
                table: "IssueViewModel",
                column: "UserViewModelAuthZeroId",
                principalTable: "UserViewModel",
                principalColumn: "AuthZeroId");

            migrationBuilder.AddForeignKey(
                name: "FK_MessageViewModel_UserViewModel_UserViewModelAuthZeroId",
                table: "MessageViewModel",
                column: "UserViewModelAuthZeroId",
                principalTable: "UserViewModel",
                principalColumn: "AuthZeroId");

            migrationBuilder.AddForeignKey(
                name: "FK_NotificationViewModels_UserViewModel_UserViewModelAuthZeroId",
                table: "NotificationViewModels",
                column: "UserViewModelAuthZeroId",
                principalTable: "UserViewModel",
                principalColumn: "AuthZeroId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectViewModel_UserViewModel_ProjectAdminAuthZeroId",
                table: "ProjectViewModel",
                column: "ProjectAdminAuthZeroId",
                principalTable: "UserViewModel",
                principalColumn: "AuthZeroId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserViewModel_UserViewModel_AdminViewModelAuthZeroId",
                table: "UserViewModel",
                column: "AdminViewModelAuthZeroId",
                principalTable: "UserViewModel",
                principalColumn: "AuthZeroId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserViewModel_UserViewModel_AdminViewModelAuthZeroId1",
                table: "UserViewModel",
                column: "AdminViewModelAuthZeroId1",
                principalTable: "UserViewModel",
                principalColumn: "AuthZeroId");
        }
    }
}
