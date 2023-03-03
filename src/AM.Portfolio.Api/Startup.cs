using AM.Portfolio.Api.Services;
using AM.Portfolio.Api.Services.Interfaces;
using AM.Portfolio.Infrastructure;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Net.Shared.Extensions;

namespace AM.Portfolio.Api;

public sealed class Startup
{
    private IConfiguration Configuration { get; }
    public Startup(IConfiguration configuration) => Configuration = configuration;

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddPortfolioApiInfrastructureServices(Configuration);

        services.AddControllers().AddJsonOptions(x =>
        {
            x.JsonSerializerOptions.Converters.Add(new JsonExtensions.TimeOnlyConverter());
            x.JsonSerializerOptions.Converters.Add(new JsonExtensions.DateOnlyConverter());
        });

        services.AddTransient<IReportApi, ReportApi>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
            app.UseDeveloperExceptionPage();

        app.UseRouting();

        app.UseEndpoints(endpoints => endpoints.MapControllers());
    }
}
