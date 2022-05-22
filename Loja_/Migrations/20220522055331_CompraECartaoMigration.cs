using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Loja_.Migrations
{
    public partial class CompraECartaoMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cartaoCreditos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TitularCartao = table.Column<string>(type: "text", nullable: true),
                    NumeroCartao = table.Column<string>(type: "text", nullable: true),
                    DataExpiracao = table.Column<string>(type: "text", nullable: true),
                    BandeiraCartao = table.Column<string>(type: "text", nullable: true),
                    CodigoSeguranca = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cartaoCreditos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProdutoId = table.Column<int>(type: "integer", nullable: false),
                    QuantidadeComprada = table.Column<int>(type: "integer", nullable: false),
                    DataDeCompra = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CartaoId = table.Column<int>(type: "integer", nullable: false),
                    cartaoCreditoId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Compras_cartaoCreditos_cartaoCreditoId",
                        column: x => x.cartaoCreditoId,
                        principalTable: "cartaoCreditos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Compras_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Compras_cartaoCreditoId",
                table: "Compras",
                column: "cartaoCreditoId");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_ProdutoId",
                table: "Compras",
                column: "ProdutoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Compras");

            migrationBuilder.DropTable(
                name: "cartaoCreditos");
        }
    }
}
