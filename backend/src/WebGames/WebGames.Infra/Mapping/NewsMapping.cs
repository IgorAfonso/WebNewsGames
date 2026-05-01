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

        builder.Property(news => news.ImageBase64)
            .HasColumnName("imagem_base64")
            .IsRequired();

        builder.Property(news => news.ImageCaption)
            .HasColumnName("legenda_imagem")
            .HasMaxLength(300)
            .IsRequired();

        builder.Property(news => news.Content2)
            .HasColumnName("conteudo_2");

        builder.Property(news => news.Image2Base64)
            .HasColumnName("imagem_2_base64");

        builder.Property(news => news.Image2Caption)
            .HasColumnName("legenda_imagem_2")
            .HasMaxLength(300);

        builder.Property(news => news.Content3)
            .HasColumnName("conteudo_3");

        builder.Property(news => news.Image3Base64)
            .HasColumnName("imagem_3_base64");

        builder.Property(news => news.Image3Caption)
            .HasColumnName("legenda_imagem_3")
            .HasMaxLength(300);

        builder.Property(news => news.PublishedAt)
            .HasColumnName("data_publicacao");

        builder.Property(news => news.CreateDate)
            .HasColumnName("data_criacao")
            .IsRequired();

        builder.Property(news => news.UpdateDate)
            .HasColumnName("data_atualizacao");
    }
}
