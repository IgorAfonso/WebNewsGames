using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using WebGames.Infra.Context;

#nullable disable

namespace WebGames.Infra.Migrations;

[DbContext(typeof(WebGamesDbContext))]
[Migration("20260501010000_AddMediaFieldsToArticlesAndNews")]
public partial class AddMediaFieldsToArticlesAndNews : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.RenameColumn(
            name: "conteudo_secundario",
            table: "artigos",
            newName: "conteudo_2");

        migrationBuilder.AddColumn<string>(
            name: "imagem_base64",
            table: "artigos",
            type: "text",
            nullable: false,
            defaultValue: string.Empty);

        migrationBuilder.AddColumn<string>(
            name: "legenda_imagem",
            table: "artigos",
            type: "character varying(300)",
            maxLength: 300,
            nullable: false,
            defaultValue: string.Empty);

        migrationBuilder.AddColumn<string>(
            name: "imagem_2_base64",
            table: "artigos",
            type: "text",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "legenda_imagem_2",
            table: "artigos",
            type: "character varying(300)",
            maxLength: 300,
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "conteudo_3",
            table: "artigos",
            type: "text",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "imagem_3_base64",
            table: "artigos",
            type: "text",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "legenda_imagem_3",
            table: "artigos",
            type: "character varying(300)",
            maxLength: 300,
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "imagem_base64",
            table: "noticias",
            type: "text",
            nullable: false,
            defaultValue: string.Empty);

        migrationBuilder.AddColumn<string>(
            name: "legenda_imagem",
            table: "noticias",
            type: "character varying(300)",
            maxLength: 300,
            nullable: false,
            defaultValue: string.Empty);

        migrationBuilder.AddColumn<string>(
            name: "conteudo_2",
            table: "noticias",
            type: "text",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "imagem_2_base64",
            table: "noticias",
            type: "text",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "legenda_imagem_2",
            table: "noticias",
            type: "character varying(300)",
            maxLength: 300,
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "conteudo_3",
            table: "noticias",
            type: "text",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "imagem_3_base64",
            table: "noticias",
            type: "text",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "legenda_imagem_3",
            table: "noticias",
            type: "character varying(300)",
            maxLength: 300,
            nullable: true);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(name: "imagem_base64", table: "artigos");
        migrationBuilder.DropColumn(name: "legenda_imagem", table: "artigos");
        migrationBuilder.DropColumn(name: "imagem_2_base64", table: "artigos");
        migrationBuilder.DropColumn(name: "legenda_imagem_2", table: "artigos");
        migrationBuilder.DropColumn(name: "conteudo_3", table: "artigos");
        migrationBuilder.DropColumn(name: "imagem_3_base64", table: "artigos");
        migrationBuilder.DropColumn(name: "legenda_imagem_3", table: "artigos");

        migrationBuilder.DropColumn(name: "imagem_base64", table: "noticias");
        migrationBuilder.DropColumn(name: "legenda_imagem", table: "noticias");
        migrationBuilder.DropColumn(name: "conteudo_2", table: "noticias");
        migrationBuilder.DropColumn(name: "imagem_2_base64", table: "noticias");
        migrationBuilder.DropColumn(name: "legenda_imagem_2", table: "noticias");
        migrationBuilder.DropColumn(name: "conteudo_3", table: "noticias");
        migrationBuilder.DropColumn(name: "imagem_3_base64", table: "noticias");
        migrationBuilder.DropColumn(name: "legenda_imagem_3", table: "noticias");

        migrationBuilder.RenameColumn(
            name: "conteudo_2",
            table: "artigos",
            newName: "conteudo_secundario");
    }
}
