using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HavenGames.Data.Migrations
{
    /// <inheritdoc />
    public partial class TabelaSistema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_EVENTS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", nullable: false),
                    Description = table.Column<string>(type: "varchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Inclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Alteracao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_EVENTS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_JOGOS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    Plataforma = table.Column<string>(type: "varchar(200)", nullable: false),
                    Genero = table.Column<string>(type: "varchar(200)", nullable: false),
                    Imagem = table.Column<string>(type: "varchar(500)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(max)", nullable: false),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Value = table.Column<string>(type: "varchar(200)", nullable: false),
                    BuyerName = table.Column<string>(type: "varchar(200)", nullable: false),
                    BuyerCPF = table.Column<string>(type: "varchar(11)", nullable: false),
                    TicketType = table.Column<string>(type: "varchar(100)", nullable: false),
                    PaymentMethod = table.Column<string>(type: "varchar(100)", nullable: false),
                    Inclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Alteracao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TICKETS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_TICKETS_TB_EVENTS_EventId",
                        column: x => x.EventId,
                        principalTable: "TB_EVENTS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TB_PERSONAGENS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    Imagem = table.Column<string>(type: "varchar(500)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(max)", nullable: false),
                    JogoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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

            migrationBuilder.CreateIndex(
                name: "IX_TB_TICKETS_EventId",
                table: "TB_TICKETS",
                column: "EventId");
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

            migrationBuilder.DropTable(
                name: "TB_EVENTS");
        }
    }
}
