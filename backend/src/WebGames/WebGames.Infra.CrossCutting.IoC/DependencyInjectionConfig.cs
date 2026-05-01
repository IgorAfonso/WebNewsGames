using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebGames.Application.AppService;
using WebGames.Application.AppService.Interface;
using WebGames.Domain.Interface.Repository;
using WebGames.Domain.Interface.Service;
using WebGames.Domain.Service;
using WebGames.Infra.Context;
using WebGames.Infra.Repository;

namespace WebGames.Infra.CrossCutting.IoC;

public static class DependencyInjectionConfig
{
    public static void DependencyInjectionConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        if (string.IsNullOrWhiteSpace(connectionString))
            throw new InvalidOperationException("Connection string 'DefaultConnection' was not found.");

        services.AddDbContext<WebGamesDbContext>(options => options.UseNpgsql(connectionString));
        // AppService
        services.AddScoped<IArticlesAppService, ArticlesAppService>();
        services.AddScoped<IChampionshipAppService, ChampionshipAppService>();
        services.AddScoped<INewsAppService, NewsAppService>();

        // DomainService
        services.AddScoped<IArticleDomainService, ArticleDomainService>();
        services.AddScoped<IChampionshipDomainService, ChampionshipDomainService>();
        services.AddScoped<INewsDomainService, NewsDomainService>();

        // Repository
        services.AddScoped<IArticleRepository, ArticleRepository>();
        services.AddScoped<IChampionshipRepository, ChampionshipRepository>();
        services.AddScoped<INewsRepository, NewsRepository>();
    }
}
