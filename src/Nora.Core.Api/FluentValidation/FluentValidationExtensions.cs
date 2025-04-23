using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Nora.Core.Api.FluentValidation;

public static class FluentValidationExtensions
{
    public static IServiceCollection AddFluentValidation(this IServiceCollection services, params Assembly[] assemblies)
    {
        services.AddValidatorsFromAssemblies(assemblies);        

        return services;
    }
}