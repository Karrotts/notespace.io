using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Notespace.Web.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Note",
                columns: table => new
                {
                    NoteID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotebookID = table.Column<long>(nullable: false),
                    UserID = table.Column<long>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    IsPublic = table.Column<bool>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    HTML = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Note", x => x.NoteID);
                });

            migrationBuilder.CreateTable(
                name: "Notebook",
                columns: table => new
                {
                    NotebookID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<long>(nullable: false),
                    IsPublic = table.Column<bool>(nullable: false),
                    Color = table.Column<byte>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notebook", x => x.NotebookID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    LastLogon = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Note");

            migrationBuilder.DropTable(
                name: "Notebook");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
