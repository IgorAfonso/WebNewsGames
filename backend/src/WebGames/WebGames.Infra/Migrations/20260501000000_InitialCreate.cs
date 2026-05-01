using System;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using WebGames.Infra.Context;

#nullable disable

namespace WebGames.Infra.Migrations;

[DbContext(typeof(WebGamesDbContext))]
[Migration("20260501000000_InitialCreate")]
public partial class InitialCreate : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "artigos",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uuid", nullable: false),
                titulo = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                conteudo = table.Column<string>(type: "text", nullable: false),
                data_publicacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                autor_id = table.Column<Guid>(type: "uuid", nullable: true),
                conteudo_secundario = table.Column<string>(type: "text", nullable: true),
                data_criacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                data_atualizacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_artigos", x => x.id);
            });

        migrationBuilder.CreateTable(
            name: "campeonatos",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uuid", nullable: false),
                nome = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                descricao = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                data_inicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                data_fim = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                data_criacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                data_atualizacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_campeonatos", x => x.id);
            });

        migrationBuilder.CreateTable(
            name: "noticias",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uuid", nullable: false),
                titulo = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                conteudo = table.Column<string>(type: "text", nullable: false),
                data_publicacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                data_criacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                data_atualizacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_noticias", x => x.id);
            });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(name: "artigos");
        migrationBuilder.DropTable(name: "campeonatos");
        migrationBuilder.DropTable(name: "noticias");
    }
}
