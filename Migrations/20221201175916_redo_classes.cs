using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BugtrackerHF.Migrations
{
    public partial class redo_classes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserRole",
                table: "UserViewModel",
                type: "int",
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "MessageViewModel",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "MessageViewModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "MessageViewModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReceiverUserId",
                table: "MessageViewModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SenderUserId",
                table: "MessageViewModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

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


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "MessageViewModel");

            migrationBuilder.DropColumn(
                name: "Message",
                table: "MessageViewModel");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "MessageViewModel");

            migrationBuilder.DropColumn(
                name: "ReceiverUserId",
                table: "MessageViewModel");

            migrationBuilder.DropColumn(
                name: "SenderUserId",
                table: "MessageViewModel");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "IssueViewModel");

            migrationBuilder.DropColumn(
                name: "IssueName",
                table: "IssueViewModel");

            migrationBuilder.AlterColumn<int>(
                name: "UserRole",
                table: "UserViewModel",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
