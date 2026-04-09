using Microsoft.Extensions.DependencyInjection;
using WebGames.Application.AppService;
using WebGames.Application.AppService.Interface;
using WebGames.Domain.Interface.Service;
using WebGames.Domain.Service;

namespace WebGames.Infra.CrossCutting.IoC
{
    public static class DependencyInjectionConfig
    {
        public static void DependencyInjectionConfiguration(this IServiceCollection services)
        {
            // AppService
            services.AddScoped<IArticlesAppService, ArticlesAppService>();
            services.AddScoped<IChampionshipAppService, ChampionshipAppService>();
            services.AddScoped<INewsAppService, NewsAppService>();

            //DomainService
            services.AddScoped<IArticleDomainService, ArticleDomainService>();
            services.AddScoped<IChampionshipDomainService, ChampionshipDomainService>();
            services.AddScoped<INewsDomainService, NewsDomainService>();
        }
    }
}
