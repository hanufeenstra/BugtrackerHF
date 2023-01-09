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
                table: "IssueModel");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageViewModel_UserViewModel_UserViewModelAuthZeroId",
                table: "MessageModel");

            migrationBuilder.DropForeignKey(
                name: "FK_NotificationViewModels_UserViewModel_UserViewModelAuthZeroId",
                table: "NotificationViewModels");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectViewModel_UserViewModel_ProjectAdminAuthZeroId",
                table: "ProjectModel");

            migrationBuilder.DropForeignKey(
                name: "FK_UserViewModel_UserViewModel_AdminViewModelAuthZeroId",
                table: "UserModel");

            migrationBuilder.DropForeignKey(
                name: "FK_UserViewModel_UserViewModel_AdminViewModelAuthZeroId1",
                table: "UserModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserViewModel",
                table: "UserModel");

            migrationBuilder.DropIndex(
                name: "IX_UserViewModel_AdminViewModelAuthZeroId",
                table: "UserModel");

            migrationBuilder.DropIndex(
                name: "IX_UserViewModel_AdminViewModelAuthZeroId1",
                table: "UserModel");

            migrationBuilder.DropIndex(
                name: "IX_ProjectViewModel_ProjectAdminAuthZeroId",
                table: "ProjectModel");

            migrationBuilder.DropIndex(
                name: "IX_NotificationViewModels_UserViewModelAuthZeroId",
                table: "NotificationViewModels");

            migrationBuilder.DropIndex(
                name: "IX_MessageViewModel_UserViewModelAuthZeroId",
                table: "MessageModel");

            migrationBuilder.DropIndex(
                name: "IX_IssueViewModel_UserViewModelAuthZeroId",
                table: "IssueModel");

            migrationBuilder.DropColumn(
                name: "AdminViewModelAuthZeroId",
                table: "UserModel");

            migrationBuilder.DropColumn(
                name: "AdminViewModelAuthZeroId1",
                table: "UserModel");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "UserModel");

            migrationBuilder.DropColumn(
                name: "ProjectAdminAuthZeroId",
                table: "ProjectModel");

            migrationBuilder.DropColumn(
                name: "UserViewModelAuthZeroId",
                table: "NotificationViewModels");

            migrationBuilder.DropColumn(
                name: "UserViewModelAuthZeroId",
                table: "MessageModel");

            migrationBuilder.DropColumn(
                name: "UserViewModelAuthZeroId",
                table: "IssueModel");

            migrationBuilder.AlterColumn<string>(
                name: "AuthZeroId",
                table: "UserModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserModel",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

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
                name: "UserViewModelId",
                table: "NotificationViewModels",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SenderUserId",
                table: "MessageModel",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "ReceiverUserId",
                table: "MessageModel",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserViewModelId",
                table: "MessageModel",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ReportedByUserId",
                table: "IssueModel",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IssueName",
                table: "IssueModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "CurrentStatus",
                table: "IssueModel",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AssignedToUserId",
                table: "IssueModel",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserViewModelId",
                table: "IssueModel",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserViewModel",
                table: "UserModel",
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
                table: "UserModel",
                column: "AdminViewModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectViewModel_ProjectAdminId",
                table: "ProjectModel",
                column: "ProjectAdminId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationViewModels_UserViewModelId",
                table: "NotificationViewModels",
                column: "UserViewModelId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageViewModel_UserViewModelId",
                table: "MessageModel",
                column: "UserViewModelId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueViewModel_UserViewModelId",
                table: "IssueModel",
                column: "UserViewModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_IssueViewModel_UserViewModel_UserViewModelId",
                table: "IssueModel",
                column: "UserViewModelId",
                principalTable: "UserModel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MessageViewModel_UserViewModel_UserViewModelId",
                table: "MessageModel",
                column: "UserViewModelId",
                principalTable: "UserModel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NotificationViewModels_UserViewModel_UserViewModelId",
                table: "NotificationViewModels",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IssueViewModel_UserViewModel_UserViewModelId",
                table: "IssueModel");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageViewModel_UserViewModel_UserViewModelId",
                table: "MessageModel");

            migrationBuilder.DropForeignKey(
                name: "FK_NotificationViewModels_UserViewModel_UserViewModelId",
                table: "NotificationViewModels");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectViewModel_AdminViewModel_ProjectAdminId",
                table: "ProjectModel");

            migrationBuilder.DropForeignKey(
                name: "FK_UserViewModel_AdminViewModel_AdminViewModelId",
                table: "UserModel");

            migrationBuilder.DropTable(
                name: "AdminViewModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserViewModel",
                table: "UserModel");

            migrationBuilder.DropIndex(
                name: "IX_UserViewModel_AdminViewModelId",
                table: "UserModel");

            migrationBuilder.DropIndex(
                name: "IX_ProjectViewModel_ProjectAdminId",
                table: "ProjectModel");

            migrationBuilder.DropIndex(
                name: "IX_NotificationViewModels_UserViewModelId",
                table: "NotificationViewModels");

            migrationBuilder.DropIndex(
                name: "IX_MessageViewModel_UserViewModelId",
                table: "MessageModel");

            migrationBuilder.DropIndex(
                name: "IX_IssueViewModel_UserViewModelId",
                table: "IssueModel");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserModel");

            migrationBuilder.DropColumn(
                name: "AdminViewModelId",
                table: "UserModel");

            migrationBuilder.DropColumn(
                name: "ProjectAdminId",
                table: "ProjectModel");

            migrationBuilder.DropColumn(
                name: "UserViewModelId",
                table: "NotificationViewModels");

            migrationBuilder.DropColumn(
                name: "UserViewModelId",
                table: "MessageModel");

            migrationBuilder.DropColumn(
                name: "UserViewModelId",
                table: "IssueModel");

            migrationBuilder.AlterColumn<string>(
                name: "AuthZeroId",
                table: "UserModel",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdminViewModelAuthZeroId",
                table: "UserModel",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdminViewModelAuthZeroId1",
                table: "UserModel",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "UserModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProjectAdminAuthZeroId",
                table: "ProjectModel",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserViewModelAuthZeroId",
                table: "NotificationViewModels",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SenderUserId",
                table: "MessageModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReceiverUserId",
                table: "MessageModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserViewModelAuthZeroId",
                table: "MessageModel",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReportedByUserId",
                table: "IssueModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IssueName",
                table: "IssueModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CurrentStatus",
                table: "IssueModel",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AssignedToUserId",
                table: "IssueModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserViewModelAuthZeroId",
                table: "IssueModel",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserViewModel",
                table: "UserModel",
                column: "AuthZeroId");

            migrationBuilder.CreateIndex(
                name: "IX_UserViewModel_AdminViewModelAuthZeroId",
                table: "UserModel",
                column: "AdminViewModelAuthZeroId");

            migrationBuilder.CreateIndex(
                name: "IX_UserViewModel_AdminViewModelAuthZeroId1",
                table: "UserModel",
                column: "AdminViewModelAuthZeroId1");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectViewModel_ProjectAdminAuthZeroId",
                table: "ProjectModel",
                column: "ProjectAdminAuthZeroId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationViewModels_UserViewModelAuthZeroId",
                table: "NotificationViewModels",
                column: "UserViewModelAuthZeroId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageViewModel_UserViewModelAuthZeroId",
                table: "MessageModel",
                column: "UserViewModelAuthZeroId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueViewModel_UserViewModelAuthZeroId",
                table: "IssueModel",
                column: "UserViewModelAuthZeroId");

            migrationBuilder.AddForeignKey(
                name: "FK_IssueViewModel_UserViewModel_UserViewModelAuthZeroId",
                table: "IssueModel",
                column: "UserViewModelAuthZeroId",
                principalTable: "UserModel",
                principalColumn: "AuthZeroId");

            migrationBuilder.AddForeignKey(
                name: "FK_MessageViewModel_UserViewModel_UserViewModelAuthZeroId",
                table: "MessageModel",
                column: "UserViewModelAuthZeroId",
                principalTable: "UserModel",
                principalColumn: "AuthZeroId");

            migrationBuilder.AddForeignKey(
                name: "FK_NotificationViewModels_UserViewModel_UserViewModelAuthZeroId",
                table: "NotificationViewModels",
                column: "UserViewModelAuthZeroId",
                principalTable: "UserModel",
                principalColumn: "AuthZeroId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectViewModel_UserViewModel_ProjectAdminAuthZeroId",
                table: "ProjectModel",
                column: "ProjectAdminAuthZeroId",
                principalTable: "UserModel",
                principalColumn: "AuthZeroId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserViewModel_UserViewModel_AdminViewModelAuthZeroId",
                table: "UserModel",
                column: "AdminViewModelAuthZeroId",
                principalTable: "UserModel",
                principalColumn: "AuthZeroId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserViewModel_UserViewModel_AdminViewModelAuthZeroId1",
                table: "UserModel",
                column: "AdminViewModelAuthZeroId1",
                principalTable: "UserModel",
                principalColumn: "AuthZeroId");
        }
    }
}
