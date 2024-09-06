using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HavenGames.Data.Migrations
{
    /// <inheritdoc />
    public partial class TBTabelaSistema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_JOGOS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Plataforma = table.Column<string>(type: "varchar(100)", nullable: false),
                    Genero = table.Column<string>(type: "varchar(100)", nullable: false),
                    Imagem = table.Column<string>(type: "varchar(255)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: true),
                    Inclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Alteracao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_JOGOS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_TICKETS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Valor = table.Column<string>(type: "varchar(100)", nullable: false),
                    Desconto = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TICKETS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_PERSONAGENS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JogoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Imagem = table.Column<string>(type: "varchar(250)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(200)", nullable: false),
                    Inclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Alteracao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PERSONAGENS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_PERSONAGENS_TB_JOGOS_JogoId",
                        column: x => x.JogoId,
                        principalTable: "TB_JOGOS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_PERSONAGENS_JogoId",
                table: "TB_PERSONAGENS",
                column: "JogoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_PERSONAGENS");

            migrationBuilder.DropTable(
                name: "TB_TICKETS");

            migrationBuilder.DropTable(
                name: "TB_JOGOS");
        }
    }
}
