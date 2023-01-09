using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BugtrackerHF.Migrations
{
    public partial class add_view_models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IssueViewModel_UserViewModel_UserViewModelId",
                table: "IssueModel");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageViewModel_IssueViewModel_IssueViewModelId",
                table: "MessageModel");

            migrationBuilder.RenameColumn(
                name: "IssueViewModelId",
                table: "MessageModel",
                newName: "IssueModelId");

            migrationBuilder.RenameIndex(
                name: "IX_MessageViewModel_IssueViewModelId",
                table: "MessageModel",
                newName: "IX_MessageModel_IssueModelId");

            migrationBuilder.RenameColumn(
                name: "UserViewModelId",
                table: "IssueModel",
                newName: "UserModelId");

            migrationBuilder.RenameIndex(
                name: "IX_IssueViewModel_UserViewModelId",
                table: "IssueModel",
                newName: "IX_IssueModel_UserModelId");

            migrationBuilder.AddColumn<int>(
                name: "ProjectModelId",
                table: "UserModel",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserModelId",
                table: "UserModel",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IssueName",
                table: "IssueModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserModel_ProjectModelId",
                table: "UserModel",
                column: "ProjectModelId");

            migrationBuilder.CreateIndex(
                name: "IX_UserModel_UserModelId",
                table: "UserModel",
                column: "UserModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectModel_ProjectManagerId",
                table: "ProjectModel",
                column: "ProjectManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_IssueModel_UserModel_UserModelId",
                table: "IssueModel",
                column: "UserModelId",
                principalTable: "UserModel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MessageModel_IssueModel_IssueModelId",
                table: "MessageModel",
                column: "IssueModelId",
                principalTable: "IssueModel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectModel_UserModel_ProjectManagerId",
                table: "ProjectModel",
                column: "ProjectManagerId",
                principalTable: "UserModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserModel_ProjectModel_ProjectModelId",
                table: "UserModel",
                column: "ProjectModelId",
                principalTable: "ProjectModel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserModel_UserModel_UserModelId",
                table: "UserModel",
                column: "UserModelId",
                principalTable: "UserModel",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IssueModel_UserModel_UserModelId",
                table: "IssueModel");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageModel_IssueModel_IssueModelId",
                table: "MessageModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectModel_UserModel_ProjectManagerId",
                table: "ProjectModel");

            migrationBuilder.DropForeignKey(
                name: "FK_UserModel_ProjectModel_ProjectModelId",
                table: "UserModel");

            migrationBuilder.DropForeignKey(
                name: "FK_UserModel_UserModel_UserModelId",
                table: "UserModel");

            migrationBuilder.DropIndex(
                name: "IX_UserModel_ProjectModelId",
                table: "UserModel");

            migrationBuilder.DropIndex(
                name: "IX_UserModel_UserModelId",
                table: "UserModel");

            migrationBuilder.DropIndex(
                name: "IX_ProjectModel_ProjectManagerId",
                table: "ProjectModel");

            migrationBuilder.DropColumn(
                name: "ProjectModelId",
                table: "UserModel");

            migrationBuilder.DropColumn(
                name: "UserModelId",
                table: "UserModel");

            migrationBuilder.RenameColumn(
                name: "IssueModelId",
                table: "MessageModel",
                newName: "IssueViewModelId");

            migrationBuilder.RenameIndex(
                name: "IX_MessageModel_IssueModelId",
                table: "MessageModel",
                newName: "IX_MessageModel_IssueViewModelId");

            migrationBuilder.RenameColumn(
                name: "UserModelId",
                table: "IssueModel",
                newName: "UserViewModelId");

            migrationBuilder.RenameIndex(
                name: "IX_IssueModel_UserModelId",
                table: "IssueModel",
                newName: "IX_IssueModel_UserViewModelId");

            migrationBuilder.AlterColumn<string>(
                name: "IssueName",
                table: "IssueModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_IssueModel_UserModel_UserViewModelId",
                table: "IssueModel",
                column: "UserViewModelId",
                principalTable: "UserModel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MessageModel_IssueModel_IssueViewModelId",
                table: "MessageModel",
                column: "IssueViewModelId",
                principalTable: "IssueModel",
                principalColumn: "Id");
        }
    }
}
