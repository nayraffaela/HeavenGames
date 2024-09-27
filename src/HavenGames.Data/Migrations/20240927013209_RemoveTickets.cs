using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HavenGames.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveTickets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_TICKETS");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_TICKETS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Alteracao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BuyerCPF = table.Column<string>(type: "varchar(11)", nullable: false),
                    BuyerName = table.Column<string>(type: "varchar(200)", nullable: false),
                    Inclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentMethod = table.Column<string>(type: "varchar(100)", nullable: false),
                    TicketType = table.Column<string>(type: "varchar(100)", nullable: false),
                    Value = table.Column<string>(type: "varchar(200)", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_TB_TICKETS_EventId",
                table: "TB_TICKETS",
                column: "EventId");
        }
    }
}
