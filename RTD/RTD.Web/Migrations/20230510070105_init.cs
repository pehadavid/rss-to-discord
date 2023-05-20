using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RTD.Web.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminUsers",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Salt = table.Column<string>(type: "TEXT", nullable: false),
                    Active = table.Column<bool>(type: "INTEGER", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminUsers", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "RssSources",
                columns: table => new
                {
                    RssSourceId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RssName = table.Column<string>(type: "TEXT", nullable: false),
                    Active = table.Column<bool>(type: "INTEGER", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateChecked = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RssSources", x => x.RssSourceId);
                });

            migrationBuilder.CreateTable(
                name: "RssEntries",
                columns: table => new
                {
                    RssEntryInternalId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Uid = table.Column<string>(type: "TEXT", nullable: false),
                    Link = table.Column<string>(type: "TEXT", nullable: false),
                    ImageLink = table.Column<string>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    ItemDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    RssSourceId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RssEntries", x => x.RssEntryInternalId);
                    table.ForeignKey(
                        name: "FK_RssEntries_RssSources_RssSourceId",
                        column: x => x.RssSourceId,
                        principalTable: "RssSources",
                        principalColumn: "RssSourceId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RssEntries_RssSourceId",
                table: "RssEntries",
                column: "RssSourceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminUsers");

            migrationBuilder.DropTable(
                name: "RssEntries");

            migrationBuilder.DropTable(
                name: "RssSources");
        }
    }
}
