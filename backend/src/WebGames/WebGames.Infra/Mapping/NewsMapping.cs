using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebGames.Domain.Entities;

namespace WebGames.Infra.Mapping;

public class NewsMapping : IEntityTypeConfiguration<News>
{
    public void Configure(EntityTypeBuilder<News> builder)
    {
        builder.ToTable("noticias");

        builder.HasKey(news => news.Id);

        builder.Property(news => news.Id)
            .HasColumnName("id");

        builder.Property(news => news.Title)
            .HasColumnName("titulo")
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(news => news.Content)
            .HasColumnName("conteudo")
            .IsRequired();

        builder.Property(news => news.PublishedAt)
            .HasColumnName("data_publicacao");

        builder.Property(news => news.CreateDate)
            .HasColumnName("data_criacao")
            .IsRequired();

        builder.Property(news => news.UpdateDate)
            .HasColumnName("data_atualizacao");
    }
}
