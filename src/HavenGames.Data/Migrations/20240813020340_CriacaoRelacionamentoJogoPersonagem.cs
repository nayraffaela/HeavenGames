using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HavenGames.Data.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoRelacionamentoJogoPersonagem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "JogoId",
                table: "TB_PERSONAGENS",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_PERSONAGENS_JogoId",
                table: "TB_PERSONAGENS",
                column: "JogoId");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_PERSONAGENS_TB_JOGOS_JogoId",
                table: "TB_PERSONAGENS",
                column: "JogoId",
                principalTable: "TB_JOGOS",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_PERSONAGENS_TB_JOGOS_JogoId",
                table: "TB_PERSONAGENS");

            migrationBuilder.DropIndex(
                name: "IX_TB_PERSONAGENS_JogoId",
                table: "TB_PERSONAGENS");

            migrationBuilder.DropColumn(
                name: "JogoId",
                table: "TB_PERSONAGENS");
        }
    }
}
