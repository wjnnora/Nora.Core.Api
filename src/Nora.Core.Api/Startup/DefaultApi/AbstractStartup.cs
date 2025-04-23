using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nora.Core.Api.FluentValidation;

namespace Nora.Core.Api.Startup.DefaultApi;

public abstract class AbstractStartup(IConfiguration configuration)
{
    protected readonly IConfiguration Configuration = configuration;

    public virtual void ConfigureServices(IServiceCollection services)
    {
        services
            .AddHttpContextAccessor();        
    }

    public virtual void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {        
        app.UseMiddleware<FailureValidationMiddleware>();        
    }
}