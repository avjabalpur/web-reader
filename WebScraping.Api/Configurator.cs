using Microsoft.AspNetCore.Builder.Extensions;
using WebScraping.Api.Services;
using WebScraping.Core.Options;
using WebScraping.Core.Services;

namespace WebScraping.Api
{
    public static class Configurator
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, ConfigurationManager configuration)
        {

            services.AddOptions<SiteOptions>()
                       .Bind(configuration.GetSection(nameof(SiteOptions)));

            services.AddScoped<ISiteService, SiteService>();

            return services;

        }
    }
}
