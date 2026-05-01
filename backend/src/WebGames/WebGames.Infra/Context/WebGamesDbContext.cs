using Microsoft.EntityFrameworkCore;
using WebGames.Domain.Entities;

namespace WebGames.Infra.Context;

public class WebGamesDbContext(DbContextOptions<WebGamesDbContext> options) : DbContext(options)
{
    public DbSet<Article> Artigos => Set<Article>();
    public DbSet<Championship> Campeonatos => Set<Championship>();
    public DbSet<News> Noticias => Set<News>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(WebGamesDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
