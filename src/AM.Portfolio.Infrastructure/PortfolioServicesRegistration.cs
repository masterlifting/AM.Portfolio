using AM.Portfolio.Core.Abstractions.ExcelService;
using AM.Portfolio.Core.Abstractions.Persistence;
using AM.Portfolio.Core.Abstractions.Persistence.Repositories;
using AM.Portfolio.Core.Abstractions.WebServices;
using AM.Portfolio.Core.Persistence.Entities.NoSql;
using AM.Portfolio.Core.Persistence.Entities.Sql.Catalogs;
using AM.Portfolio.Core.Services.BcsServices.Implementations.v1;
using AM.Portfolio.Core.Services.BcsServices.Interfaces;
using AM.Portfolio.Infrastructure.ExcelServices;
using AM.Portfolio.Infrastructure.Persistence;
using AM.Portfolio.Infrastructure.Persistence.Contexts;
using AM.Portfolio.Infrastructure.Persistence.Repositories;
using AM.Portfolio.Infrastructure.Settings;
using AM.Portfolio.Infrastructure.WebClients;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Net.Shared.Persistence.Abstractions.Contexts;
using Net.Shared.Persistence.Abstractions.Repositories;
using Net.Shared.Persistence.Repositories;
using Net.Shared.Queues.Abstractions.Domain.WorkQueue;
using Net.Shared.Queues.Domain.WorkQueue;

using Polly;

namespace AM.Portfolio.Infrastructure;

public static partial class PortfolioServicesRegistration
{
    public static void AddPortfolioWorkerInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        AddPortfolioApiInfrastructureServices(services, configuration);

        services.AddScoped<IPersistenceRepository<IncomingData>, MongoRepository<IncomingData>>();
        services.AddScoped<IPersistenceRepository<ProcessStep>, PostgreRepository<ProcessStep>>();
    }
    public static void AddPortfolioApiInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPortfolioApiInfrastructureServices(configuration);
    }
}

public static partial class PortfolioServicesRegistration
{
    private static void AddPortfolioLogic(this IServiceCollection services)
    {
        services.AddTransient<IPortfolioExcelService, PortfolioExcelService>();
        services.AddTransient<IBcsReportService, BcsReportService>();
    }
    private static void AddPortfolioPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<DatabaseConnectionSection>(configuration.GetSection(DatabaseConnectionSection.Name));

        services.AddScoped<IPersistencePostgreContext, PostgrePortfolioContext>();
        services.AddScoped<IPersistenceMongoContext, MongoPortfolioContext>();

        services.AddScoped<IProcessStepRepository, ProcessStepRepository>();
        services.AddScoped<IIncomingDataRepository, IncomingDataRepository>();
        services.AddScoped<IAssetRepository, AssetRepository>();
        services.AddScoped<IDealRepository, DealRepository>();
        services.AddScoped<IEventRepository, EventRepository>();
        services.AddScoped<IDerivativeRepository, DerivativeRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<IDerivativeRepository, DerivativeRepository>();

        services.AddScoped<IUnitOfWorkRepository, UnitOfWorkRepository>();

        services.AddTransient<IWorkQueue, WorkQueue>();
    }
    private static void AddPortfolioWeb(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<WebclientConnectionSection>(configuration.GetSection(WebclientConnectionSection.Name));

        services.AddHttpClient<IMoexWebclient, MoexWebclient>()
            .AddTransientHttpErrorPolicy(policy => policy.WaitAndRetryAsync(5, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))))
            .AddTransientHttpErrorPolicy(policy => policy.CircuitBreakerAsync(3, TimeSpan.FromSeconds(30)));
    }
}
