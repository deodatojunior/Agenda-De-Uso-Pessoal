using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoIntegrador.Migrations
{
    public partial class abc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Anotacao",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anotacao", x => x.id);
                });

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

            migrationBuilder.InsertData(
                table: "Lembretes",
                columns: new[] { "id", "data", "texto" },
                values: new object[] { 1, new DateTime(2021, 6, 1, 13, 41, 28, 584, DateTimeKind.Local).AddTicks(2328), "Hoje foi um belo dia, espero que amanhã seja melhor!" });

            migrationBuilder.InsertData(
                table: "Lembretes",
                columns: new[] { "id", "data", "texto" },
                values: new object[] { 2, new DateTime(2021, 6, 1, 13, 41, 28, 586, DateTimeKind.Local).AddTicks(2315), "Hoje foi um dia comum, espero que amanhã seja melhor!" });

            migrationBuilder.InsertData(
                table: "Lembretes",
                columns: new[] { "id", "data", "texto" },
                values: new object[] { 3, new DateTime(2021, 6, 1, 13, 41, 28, 586, DateTimeKind.Local).AddTicks(2376), "Hoje foi um péssimo dia, espero que amanhã seja melhor!" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Anotacao");

            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "Lembretes");
        }
    }
}
