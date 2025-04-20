using Microsoft.Extensions.DependencyInjection;
using Refit;
using System.Text.Json;

namespace Nora.Core.Api.Refit;

public static class RefitExtensions
{
    public static IServiceCollection AddRefitClient<TClient>(
        this IServiceCollection services,
        string url) where TClient : class
    {
        var settings = new RefitSettings(new SystemTextJsonContentSerializer(new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }));        

        services            
            .AddRefitClient<TClient>(settings)
            .AddConfigurations(url);

        return services;
    }    

    private static IHttpClientBuilder AddConfigurations(
        this IHttpClientBuilder builder,
        string url)
    {
        builder
            .ConfigureHttpClient(configure => configure.BaseAddress = new Uri(url));

        return builder;
    }
}