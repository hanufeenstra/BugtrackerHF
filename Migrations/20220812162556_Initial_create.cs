using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BugtrackerHF.Migrations
{
    public partial class Initial_create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserViewModel",
                columns: table => new
                {
                    AuthZeroId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserNickname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserRole = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdminViewModelAuthZeroId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminViewModelAuthZeroId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserViewModel", x => x.AuthZeroId);
                    table.ForeignKey(
                        name: "FK_UserViewModel_UserViewModel_AdminViewModelAuthZeroId",
                        column: x => x.AdminViewModelAuthZeroId,
                        principalTable: "UserViewModel",
                        principalColumn: "AuthZeroId");
                    table.ForeignKey(
                        name: "FK_UserViewModel_UserViewModel_AdminViewModelAuthZeroId1",
                        column: x => x.AdminViewModelAuthZeroId1,
                        principalTable: "UserViewModel",
                        principalColumn: "AuthZeroId");
                });

            migrationBuilder.CreateTable(
                name: "IssueViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IssueName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CurrentSeverity = table.Column<int>(type: "int", nullable: true),
                    CurrentStatus = table.Column<int>(type: "int", nullable: false),
                    ReportedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssignedToUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserViewModelAuthZeroId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueViewModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IssueViewModel_UserViewModel_UserViewModelAuthZeroId",
                        column: x => x.UserViewModelAuthZeroId,
                        principalTable: "UserViewModel",
                        principalColumn: "AuthZeroId");
                });

            migrationBuilder.CreateTable(
                name: "NotificationViewModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserViewModelAuthZeroId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationViewModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotificationViewModels_UserViewModel_UserViewModelAuthZeroId",
                        column: x => x.UserViewModelAuthZeroId,
                        principalTable: "UserViewModel",
                        principalColumn: "AuthZeroId");
                });

            migrationBuilder.CreateTable(
                name: "ProjectViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectAdminAuthZeroId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectViewModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectViewModel_UserViewModel_ProjectAdminAuthZeroId",
                        column: x => x.ProjectAdminAuthZeroId,
                        principalTable: "UserViewModel",
                        principalColumn: "AuthZeroId");
                });

            migrationBuilder.CreateTable(
                name: "MessageViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentMassageId = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SenderUserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiverUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Viewed = table.Column<bool>(type: "bit", nullable: false),
                    IssueViewModelId = table.Column<int>(type: "int", nullable: true),
                    UserViewModelAuthZeroId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageViewModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MessageViewModel_IssueViewModel_IssueViewModelId",
                        column: x => x.IssueViewModelId,
                        principalTable: "IssueViewModel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MessageViewModel_UserViewModel_UserViewModelAuthZeroId",
                        column: x => x.UserViewModelAuthZeroId,
                        principalTable: "UserViewModel",
                        principalColumn: "AuthZeroId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_IssueViewModel_UserViewModelAuthZeroId",
                table: "IssueViewModel",
                column: "UserViewModelAuthZeroId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageViewModel_IssueViewModelId",
                table: "MessageViewModel",
                column: "IssueViewModelId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageViewModel_UserViewModelAuthZeroId",
                table: "MessageViewModel",
                column: "UserViewModelAuthZeroId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationViewModels_UserViewModelAuthZeroId",
                table: "NotificationViewModels",
                column: "UserViewModelAuthZeroId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectViewModel_ProjectAdminAuthZeroId",
                table: "ProjectViewModel",
                column: "ProjectAdminAuthZeroId");

            migrationBuilder.CreateIndex(
                name: "IX_UserViewModel_AdminViewModelAuthZeroId",
                table: "UserViewModel",
                column: "AdminViewModelAuthZeroId");

            migrationBuilder.CreateIndex(
                name: "IX_UserViewModel_AdminViewModelAuthZeroId1",
                table: "UserViewModel",
                column: "AdminViewModelAuthZeroId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MessageViewModel");

            migrationBuilder.DropTable(
                name: "NotificationViewModels");

            migrationBuilder.DropTable(
                name: "ProjectViewModel");

            migrationBuilder.DropTable(
                name: "IssueViewModel");

            migrationBuilder.DropTable(
                name: "UserViewModel");
        }
    }
}
