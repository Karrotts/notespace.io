using Microsoft.EntityFrameworkCore.Migrations;

namespace Notespace.Web.Migrations
{
    public partial class AddNulls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Notebooks_NotebookID",
                table: "Notes");

            migrationBuilder.AlterColumn<long>(
                name: "NotebookID",
                table: "Notes",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Notebooks_NotebookID",
                table: "Notes",
                column: "NotebookID",
                principalTable: "Notebooks",
                principalColumn: "NotebookID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Notebooks_NotebookID",
                table: "Notes");

            migrationBuilder.AlterColumn<long>(
                name: "NotebookID",
                table: "Notes",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Notebooks_NotebookID",
                table: "Notes",
                column: "NotebookID",
                principalTable: "Notebooks",
                principalColumn: "NotebookID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
