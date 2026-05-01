using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebGames.Domain.Entities;

namespace WebGames.Infra.Context;

public class WebGamesDbContext(DbContextOptions<WebGamesDbContext> options)
    : IdentityDbContext<IdentityUser, IdentityRole, string>(options)
{
    public DbSet<Article> Artigos => Set<Article>();
    public DbSet<Championship> Campeonatos => Set<Championship>();
    public DbSet<News> Noticias => Set<News>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(WebGamesDbContext).Assembly);
    }
}
