using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoIntegrador.Migrations
{
    public partial class primeiro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    descricao = table.Column<string>(maxLength: 10000, nullable: true),
                    data_evento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Lembretes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    data = table.Column<DateTime>(nullable: false),
                    texto = table.Column<string>(maxLength: 10000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lembretes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Anotacao_Evento",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    descricao = table.Column<string>(nullable: true),
                    eventoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anotacao_Evento", x => x.id);
                    table.ForeignKey(
                        name: "FK_Anotacao_Evento_Eventos_eventoId",
                        column: x => x.eventoId,
                        principalTable: "Eventos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Anotacao_Lembrete",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    descricao = table.Column<string>(nullable: true),
                    lembreteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anotacao_Lembrete", x => x.id);
                    table.ForeignKey(
                        name: "FK_Anotacao_Lembrete_Lembretes_lembreteId",
                        column: x => x.lembreteId,
                        principalTable: "Lembretes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Lembretes",
                columns: new[] { "id", "data", "texto" },
                values: new object[] { 1, new DateTime(2021, 6, 15, 22, 58, 43, 943, DateTimeKind.Local).AddTicks(1294), "Hoje foi um belo dia, espero que amanhã seja melhor!" });

            migrationBuilder.InsertData(
                table: "Lembretes",
                columns: new[] { "id", "data", "texto" },
                values: new object[] { 2, new DateTime(2021, 6, 15, 22, 58, 43, 945, DateTimeKind.Local).AddTicks(4123), "Hoje foi um dia comum, espero que amanhã seja melhor!" });

            migrationBuilder.InsertData(
                table: "Lembretes",
                columns: new[] { "id", "data", "texto" },
                values: new object[] { 3, new DateTime(2021, 6, 15, 22, 58, 43, 945, DateTimeKind.Local).AddTicks(4208), "Hoje foi um péssimo dia, espero que amanhã seja melhor!" });

            migrationBuilder.CreateIndex(
                name: "IX_Anotacao_Evento_eventoId",
                table: "Anotacao_Evento",
                column: "eventoId");

            migrationBuilder.CreateIndex(
                name: "IX_Anotacao_Lembrete_lembreteId",
                table: "Anotacao_Lembrete",
                column: "lembreteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Anotacao_Evento");

            migrationBuilder.DropTable(
                name: "Anotacao_Lembrete");

            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "Lembretes");
        }
    }
}
