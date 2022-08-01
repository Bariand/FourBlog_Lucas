using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FourBlog_Lucas.Migrations
{
    public partial class Modelos_atualizados_para_validacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Postagens_AspNetUsers_UsuarioId",
                table: "Postagens");

            migrationBuilder.DropForeignKey(
                name: "FK_Postagens_Tags_TagId",
                table: "Postagens");

            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Comentario_Postagens_PostagemId",
                table: "Tbl_Comentario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tags",
                table: "Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Postagens",
                table: "Postagens");

            migrationBuilder.RenameTable(
                name: "Tags",
                newName: "Tbl_Tag");

            migrationBuilder.RenameTable(
                name: "Postagens",
                newName: "Tbl_Postagem");

            migrationBuilder.RenameColumn(
                name: "TagId",
                table: "Tbl_Tag",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PostagemId",
                table: "Tbl_Postagem",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Postagens_UsuarioId",
                table: "Tbl_Postagem",
                newName: "IX_Tbl_Postagem_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Postagens_TagId",
                table: "Tbl_Postagem",
                newName: "IX_Tbl_Postagem_TagId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tbl_Tag",
                table: "Tbl_Tag",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tbl_Postagem",
                table: "Tbl_Postagem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Comentario_Tbl_Postagem_PostagemId",
                table: "Tbl_Comentario",
                column: "PostagemId",
                principalTable: "Tbl_Postagem",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Postagem_AspNetUsers_UsuarioId",
                table: "Tbl_Postagem",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Postagem_Tbl_Tag_TagId",
                table: "Tbl_Postagem",
                column: "TagId",
                principalTable: "Tbl_Tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Comentario_Tbl_Postagem_PostagemId",
                table: "Tbl_Comentario");

            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Postagem_AspNetUsers_UsuarioId",
                table: "Tbl_Postagem");

            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Postagem_Tbl_Tag_TagId",
                table: "Tbl_Postagem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tbl_Tag",
                table: "Tbl_Tag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tbl_Postagem",
                table: "Tbl_Postagem");

            migrationBuilder.RenameTable(
                name: "Tbl_Tag",
                newName: "Tags");

            migrationBuilder.RenameTable(
                name: "Tbl_Postagem",
                newName: "Postagens");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tags",
                newName: "TagId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Postagens",
                newName: "PostagemId");

            migrationBuilder.RenameIndex(
                name: "IX_Tbl_Postagem_UsuarioId",
                table: "Postagens",
                newName: "IX_Postagens_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Tbl_Postagem_TagId",
                table: "Postagens",
                newName: "IX_Postagens_TagId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tags",
                table: "Tags",
                column: "TagId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Postagens",
                table: "Postagens",
                column: "PostagemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Postagens_AspNetUsers_UsuarioId",
                table: "Postagens",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Postagens_Tags_TagId",
                table: "Postagens",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "TagId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Comentario_Postagens_PostagemId",
                table: "Tbl_Comentario",
                column: "PostagemId",
                principalTable: "Postagens",
                principalColumn: "PostagemId");
        }
    }
}
