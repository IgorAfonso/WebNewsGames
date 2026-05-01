using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebGames.Domain.Entities;

namespace WebGames.Infra.Mapping;

public class ChampionshipMapping : IEntityTypeConfiguration<Championship>
{
    public void Configure(EntityTypeBuilder<Championship> builder)
    {
        builder.ToTable("campeonatos");

        builder.HasKey(championship => championship.Id);

        builder.Property(championship => championship.Id)
            .HasColumnName("id");

        builder.Property(championship => championship.Name)
            .HasColumnName("nome")
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(championship => championship.Description)
            .HasColumnName("descricao")
            .HasMaxLength(1000)
            .IsRequired();

        builder.Property(championship => championship.StartDate)
            .HasColumnName("data_inicio");

        builder.Property(championship => championship.EndDate)
            .HasColumnName("data_fim");

        builder.Property(championship => championship.CreateDate)
            .HasColumnName("data_criacao")
            .IsRequired();

        builder.Property(championship => championship.UpdateDate)
            .HasColumnName("data_atualizacao");
    }
}
