using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BugtrackerHF.Migrations
{
    public partial class DepInject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "CreatedTime",
                table: "MessageViewModel");

            migrationBuilder.DropColumn(
                name: "IssueViewModelId",
                table: "MessageViewModel");

            migrationBuilder.DropColumn(
                name: "Message",
                table: "MessageViewModel");

            migrationBuilder.DropColumn(
                name: "ParentMassageId",
                table: "MessageViewModel");

            migrationBuilder.DropColumn(
                name: "ReceiverUserId",
                table: "MessageViewModel");

            migrationBuilder.DropColumn(
                name: "SenderUserId",
                table: "MessageViewModel");

            migrationBuilder.DropColumn(
                name: "UserViewModelId",
                table: "MessageViewModel");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "IssueViewModel");

            migrationBuilder.DropColumn(
                name: "IssueName",
                table: "IssueViewModel");

            migrationBuilder.DropColumn(
                name: "ReportedByUserId",
                table: "IssueViewModel");

            migrationBuilder.DropColumn(
                name: "UserViewModelId",
                table: "IssueViewModel");

            migrationBuilder.AlterColumn<int>(
                name: "UserRole",
                table: "UserViewModel",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AuthZeroId",
                table: "UserViewModel",
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

            migrationBuilder.AlterColumn<int>(
                name: "CurrentSeverity",
                table: "IssueViewModel",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AssignedToUserId",
                table: "IssueViewModel",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuthZeroId",
                table: "AdminViewModel",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthZeroId",
                table: "AdminViewModel");

            migrationBuilder.AlterColumn<string>(
                name: "UserRole",
                table: "UserViewModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "AuthZeroId",
                table: "UserViewModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "UserViewModelId",
                table: "NotificationViewModels",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "MessageViewModel",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IssueViewModelId",
                table: "MessageViewModel",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "MessageViewModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentMassageId",
                table: "MessageViewModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReceiverUserId",
                table: "MessageViewModel",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SenderUserId",
                table: "MessageViewModel",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserViewModelId",
                table: "MessageViewModel",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CurrentStatus",
                table: "IssueViewModel",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CurrentSeverity",
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
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "IssueViewModel",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "IssueName",
                table: "IssueViewModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReportedByUserId",
                table: "IssueViewModel",
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
    }
}
