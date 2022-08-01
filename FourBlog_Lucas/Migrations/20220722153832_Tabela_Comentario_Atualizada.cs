using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FourBlog_Lucas.Migrations
{
    public partial class Tabela_Comentario_Atualizada : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_AspNetUsers_UsuarioId",
                table: "Comentarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Postagens_PostagemId",
                table: "Comentarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comentarios",
                table: "Comentarios");

            migrationBuilder.RenameTable(
                name: "Comentarios",
                newName: "Tbl_Comentario");

            migrationBuilder.RenameColumn(
                name: "ComentarioId",
                table: "Tbl_Comentario",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Comentarios_UsuarioId",
                table: "Tbl_Comentario",
                newName: "IX_Tbl_Comentario_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Comentarios_PostagemId",
                table: "Tbl_Comentario",
                newName: "IX_Tbl_Comentario_PostagemId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCriacao",
                table: "Postagens",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tbl_Comentario",
                table: "Tbl_Comentario",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Comentario_AspNetUsers_UsuarioId",
                table: "Tbl_Comentario",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Comentario_Postagens_PostagemId",
                table: "Tbl_Comentario",
                column: "PostagemId",
                principalTable: "Postagens",
                principalColumn: "PostagemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Comentario_AspNetUsers_UsuarioId",
                table: "Tbl_Comentario");

            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Comentario_Postagens_PostagemId",
                table: "Tbl_Comentario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tbl_Comentario",
                table: "Tbl_Comentario");

            migrationBuilder.RenameTable(
                name: "Tbl_Comentario",
                newName: "Comentarios");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Comentarios",
                newName: "ComentarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Tbl_Comentario_UsuarioId",
                table: "Comentarios",
                newName: "IX_Comentarios_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Tbl_Comentario_PostagemId",
                table: "Comentarios",
                newName: "IX_Comentarios_PostagemId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCriacao",
                table: "Postagens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comentarios",
                table: "Comentarios",
                column: "ComentarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_AspNetUsers_UsuarioId",
                table: "Comentarios",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Postagens_PostagemId",
                table: "Comentarios",
                column: "PostagemId",
                principalTable: "Postagens",
                principalColumn: "PostagemId");
        }
    }
}
