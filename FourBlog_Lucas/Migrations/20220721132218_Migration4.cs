using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FourBlog_Lucas.Migrations
{
    public partial class Migration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "texto",
                table: "Comentarios",
                newName: "Texto");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataHora",
                table: "Comentarios",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Texto",
                table: "Comentarios",
                newName: "texto");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataHora",
                table: "Comentarios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
