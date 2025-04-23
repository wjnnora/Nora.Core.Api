using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Nora.Core.Api.MediatR.Extensions;

public static class MediaTrExtensions
{
    public static IServiceCollection AddMediatR<T1>(this IServiceCollection services)
    {
        services.AddMediatR(typeof(T1));
        return services;
    }

    public static IServiceCollection AddMediatR<T1, T2>(this IServiceCollection services)
    {
        services.AddMediatR(typeof(T1), typeof(T2));
        return services;
    }

    public static IServiceCollection AddMediatR<T1, T2, T3>(this IServiceCollection services)
    {
        services.AddMediatR(typeof(T1), typeof(T2), typeof(T3));
        return services;
    }
}