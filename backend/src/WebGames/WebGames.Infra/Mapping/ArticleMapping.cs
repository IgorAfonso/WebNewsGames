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

        builder.Property(article => article.ImageBase64)
            .HasColumnName("imagem_base64")
            .IsRequired();

        builder.Property(article => article.ImageCaption)
            .HasColumnName("legenda_imagem")
            .HasMaxLength(300)
            .IsRequired();

        builder.Property(article => article.Content2)
            .HasColumnName("conteudo_2");

        builder.Property(article => article.Image2Base64)
            .HasColumnName("imagem_2_base64");

        builder.Property(article => article.Image2Caption)
            .HasColumnName("legenda_imagem_2")
            .HasMaxLength(300);

        builder.Property(article => article.Content3)
            .HasColumnName("conteudo_3");

        builder.Property(article => article.Image3Base64)
            .HasColumnName("imagem_3_base64");

        builder.Property(article => article.Image3Caption)
            .HasColumnName("legenda_imagem_3")
            .HasMaxLength(300);

        builder.Property(article => article.AuthorId)
            .HasColumnName("autor_id");

        builder.Property(article => article.AuthorUserId)
            .HasColumnName("autor_usuario_id")
            .HasMaxLength(450);

        builder.Property(article => article.AuthorName)
            .HasColumnName("autor_nome")
            .HasMaxLength(256);

        builder.Property(article => article.PublishedDate)
            .HasColumnName("data_publicacao");

        builder.Property(article => article.CreateDate)
            .HasColumnName("data_criacao")
            .IsRequired();

        builder.Property(article => article.UpdateDate)
            .HasColumnName("data_atualizacao");
    }
}
