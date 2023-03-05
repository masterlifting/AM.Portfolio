using AM.Portfolio.Core.Abstractions.ExcelService;
using AM.Portfolio.Core.Abstractions.Persistence;
using AM.Portfolio.Core.Abstractions.Persistence.Repositories;
using AM.Portfolio.Core.Abstractions.WebServices;
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
using Net.Shared.Queues.Abstractions.Core.WorkQueue;
using Net.Shared.Queues.WorkQueue;
using Polly;

namespace AM.Portfolio.Infrastructure;

public static partial class PortfolioServicesRegistration
{
    public static void AddPortfolioWorkerInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPortfolioPersistence(configuration);

        services.AddPortfolioLogic();
    }
    public static void AddPortfolioApiInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMemoryCache();

        services.AddPortfolioPersistence(configuration);

        services.AddPortfolioLogic();

        services.Configure<WebclientConnectionSection>(configuration.GetSection(WebclientConnectionSection.Name));

        services.AddHttpClient<IMoexWebclient, MoexWebclient>()
            .AddTransientHttpErrorPolicy(policy => policy.WaitAndRetryAsync(5, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))))
            .AddTransientHttpErrorPolicy(policy => policy.CircuitBreakerAsync(3, TimeSpan.FromSeconds(30)));
    }
}

public static partial class PortfolioServicesRegistration
{
    private static void AddPortfolioLogic(this IServiceCollection services)
    {
        services.AddTransient<IPortfolioExcelService, PortfolioExcelService>();
        services.AddTransient<IBcsReportService, BcsReportService>();
        services.AddTransient<IWorkQueue, WorkQueue>();
    }
    private static void AddPortfolioPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<DatabaseConnectionSection>(configuration.GetSection(DatabaseConnectionSection.Name));

        services.AddTransient<IPersistencePostgreContext, PostgrePortfolioContext>();
        services.AddTransient<IPersistenceMongoContext, MongoPortfolioContext>();

        services.AddTransient<IProcessStepRepository, ProcessStepRepository>();
        services.AddTransient<IIncomingDataRepository, IncomingDataRepository>();
        services.AddTransient<IAssetRepository, AssetRepository>();
        services.AddTransient<IDealRepository, DealRepository>();
        services.AddTransient<IEventRepository, EventRepository>();
        services.AddTransient<IDerivativeRepository, DerivativeRepository>();
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IAccountRepository, AccountRepository>();
        services.AddTransient<IDerivativeRepository, DerivativeRepository>();

        services.AddTransient<IUnitOfWorkRepository, UnitOfWorkRepository>();
    }
}
