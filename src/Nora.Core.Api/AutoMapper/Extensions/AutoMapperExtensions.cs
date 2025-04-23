using Microsoft.Extensions.DependencyInjection;

namespace Nora.Core.Api.AutoMapper.Extensions;

public static class AutoMapperExtensions
{
    public static IServiceCollection AddAutoMapper<T1>(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(T1).Assembly);

        return services;
    }

    public static IServiceCollection AddAutoMapper<T1, T2>(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(T1).Assembly, typeof(T2).Assembly);

        return services;
    }
}