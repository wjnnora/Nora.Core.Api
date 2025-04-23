using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection;

namespace Nora.Core.Api.FluentValidation.Extensions;

public static class FluentValidationExtensions
{
    public static IServiceCollection AddFluentValidation(this IServiceCollection services, params Assembly[] assemblies)
    {
        services.AddValidatorsFromAssemblies(assemblies);
        services.TryAddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationPipelineBehavior<,>));

        return services;
    }
}