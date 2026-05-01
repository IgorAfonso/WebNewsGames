using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using WebGames.Infra.Context;

#nullable disable

namespace WebGames.Infra.Migrations;

[DbContext(typeof(WebGamesDbContext))]
[Migration("20260501020000_UpdateChampionshipStructure")]
public partial class UpdateChampionshipStructure : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<string>(
            name: "descricao",
            table: "campeonatos",
            type: "character varying(500)",
            maxLength: 500,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "character varying(1000)",
            oldMaxLength: 1000);

        migrationBuilder.AddColumn<string>(
            name: "sistema",
            table: "campeonatos",
            type: "character varying(100)",
            maxLength: 100,
            nullable: false,
            defaultValue: string.Empty);

        migrationBuilder.AddColumn<string>(
            name: "local",
            table: "campeonatos",
            type: "character varying(300)",
            maxLength: 300,
            nullable: false,
            defaultValue: string.Empty);

        migrationBuilder.AddColumn<bool>(
            name: "apenas_exibicional",
            table: "campeonatos",
            type: "boolean",
            nullable: false,
            defaultValue: true);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(name: "sistema", table: "campeonatos");
        migrationBuilder.DropColumn(name: "local", table: "campeonatos");
        migrationBuilder.DropColumn(name: "apenas_exibicional", table: "campeonatos");

        migrationBuilder.AlterColumn<string>(
            name: "descricao",
            table: "campeonatos",
            type: "character varying(1000)",
            maxLength: 1000,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "character varying(500)",
            oldMaxLength: 500);
    }
}
