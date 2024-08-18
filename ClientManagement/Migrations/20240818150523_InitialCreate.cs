using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RSGymPT.ClientManagement.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoPagamento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fidelizado = table.Column<bool>(type: "bit", nullable: true),
                    DataInscricao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorMensalidade = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ServicosUtilizados = table.Column<int>(type: "int", nullable: false),
                    MesesFidelizacao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
