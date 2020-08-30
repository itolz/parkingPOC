using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkingPOC.Infra.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estabelecimento",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    CNPJ = table.Column<string>(nullable: false),
                    Endereco = table.Column<string>(maxLength: 100, nullable: false),
                    Telefone = table.Column<string>(nullable: false),
                    PosicoesVagasMotos = table.Column<int>(nullable: false),
                    PosicoesVagasCarros = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estabelecimento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ocorrencia",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EstabelecimentoId = table.Column<Guid>(nullable: false),
                    VeiculoId = table.Column<Guid>(nullable: false),
                    Movimento = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocorrencia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Veiculo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Marca = table.Column<string>(maxLength: 50, nullable: false),
                    Modelo = table.Column<string>(maxLength: 50, nullable: false),
                    Cor = table.Column<string>(maxLength: 40, nullable: false),
                    Placa = table.Column<string>(nullable: false),
                    Tipo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estabelecimento");

            migrationBuilder.DropTable(
                name: "Ocorrencia");

            migrationBuilder.DropTable(
                name: "Veiculo");
        }
    }
}
