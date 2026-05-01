using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebGames.Infra.Context;

#nullable disable

namespace WebGames.Infra.Migrations;

[DbContext(typeof(WebGamesDbContext))]
partial class WebGamesDbContextModelSnapshot : ModelSnapshot
{
    protected override void BuildModel(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasAnnotation("ProductVersion", "10.0.0")
            .HasAnnotation("Relational:MaxIdentifierLength", 63);

        NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

        modelBuilder.Entity("WebGames.Domain.Entities.Article", b =>
        {
            b.Property<Guid>("Id")
                .ValueGeneratedOnAdd()
                .HasColumnType("uuid")
                .HasColumnName("id");

            b.Property<Guid?>("AuthorId")
                .HasColumnType("uuid")
                .HasColumnName("autor_id");

            b.Property<string>("Content")
                .IsRequired()
                .HasColumnType("text")
                .HasColumnName("conteudo");

            b.Property<DateTime>("CreateDate")
                .HasColumnType("timestamp with time zone")
                .HasColumnName("data_criacao");

            b.Property<DateTime>("PublishedDate")
                .HasColumnType("timestamp with time zone")
                .HasColumnName("data_publicacao");

            b.Property<string>("SecondContent")
                .HasColumnType("text")
                .HasColumnName("conteudo_secundario");

            b.Property<string>("Title")
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnType("character varying(200)")
                .HasColumnName("titulo");

            b.Property<DateTime>("UpdateDate")
                .HasColumnType("timestamp with time zone")
                .HasColumnName("data_atualizacao");

            b.HasKey("Id");

            b.ToTable("artigos", (string)null);
        });

        modelBuilder.Entity("WebGames.Domain.Entities.Championship", b =>
        {
            b.Property<Guid>("Id")
                .ValueGeneratedOnAdd()
                .HasColumnType("uuid")
                .HasColumnName("id");

            b.Property<DateTime>("CreateDate")
                .HasColumnType("timestamp with time zone")
                .HasColumnName("data_criacao");

            b.Property<string>("Description")
                .IsRequired()
                .HasMaxLength(1000)
                .HasColumnType("character varying(1000)")
                .HasColumnName("descricao");

            b.Property<DateTime>("EndDate")
                .HasColumnType("timestamp with time zone")
                .HasColumnName("data_fim");

            b.Property<string>("Name")
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnType("character varying(200)")
                .HasColumnName("nome");

            b.Property<DateTime>("StartDate")
                .HasColumnType("timestamp with time zone")
                .HasColumnName("data_inicio");

            b.Property<DateTime>("UpdateDate")
                .HasColumnType("timestamp with time zone")
                .HasColumnName("data_atualizacao");

            b.HasKey("Id");

            b.ToTable("campeonatos", (string)null);
        });

        modelBuilder.Entity("WebGames.Domain.Entities.News", b =>
        {
            b.Property<Guid>("Id")
                .ValueGeneratedOnAdd()
                .HasColumnType("uuid")
                .HasColumnName("id");

            b.Property<string>("Content")
                .IsRequired()
                .HasColumnType("text")
                .HasColumnName("conteudo");

            b.Property<DateTime>("CreateDate")
                .HasColumnType("timestamp with time zone")
                .HasColumnName("data_criacao");

            b.Property<DateTime>("PublishedAt")
                .HasColumnType("timestamp with time zone")
                .HasColumnName("data_publicacao");

            b.Property<string>("Title")
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnType("character varying(200)")
                .HasColumnName("titulo");

            b.Property<DateTime>("UpdateDate")
                .HasColumnType("timestamp with time zone")
                .HasColumnName("data_atualizacao");

            b.HasKey("Id");

            b.ToTable("noticias", (string)null);
        });
    }
}
