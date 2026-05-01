using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebGames.Domain.Entities;

namespace WebGames.Infra.Mapping;

public class ArticleMapping : IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {
        builder.ToTable("artigos");

        builder.HasKey(article => article.Id);

        builder.Property(article => article.Id)
            .HasColumnName("id");

        builder.Property(article => article.Title)
            .HasColumnName("titulo")
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(article => article.Content)
            .HasColumnName("conteudo")
            .IsRequired();

        builder.Property(article => article.SecondContent)
            .HasColumnName("conteudo_secundario");

        builder.Property(article => article.AuthorId)
            .HasColumnName("autor_id");

        builder.Property(article => article.PublishedDate)
            .HasColumnName("data_publicacao");

        builder.Property(article => article.CreateDate)
            .HasColumnName("data_criacao")
            .IsRequired();

        builder.Property(article => article.UpdateDate)
            .HasColumnName("data_atualizacao");
    }
}
