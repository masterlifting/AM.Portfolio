using AM.Portfolio.Core.Domain.Persistence.Collections;
using AM.Portfolio.Core.Domain.Persistence.Entities.Catalogs;
using AM.Portfolio.Infrastructure;
using AM.Portfolio.Worker.BackgroundServices;
using AM.Portfolio.Worker.BackgroundTasks;

using Shared.Background.Core.BackgroundTasks;
using Shared.Background.Settings.Sections;

namespace AM.Portfolio.Worker;

public class Program
{
    public static void Main(string[] args) =>
        Host.CreateDefaultBuilder(args)
        .ConfigureServices((hostContext, services) =>
        {
            var configuration = hostContext.Configuration;

            services.AddPortfolioPersistence(configuration);
            services.AddPortfolioCoreServices();

            services.Configure<BackgroundTaskSection>(configuration.GetSection(BackgroundTaskSection.Name));

            services.AddHostedService<BackgroundServiceIncomingDataProcessing>();
            services.AddTransient<BackgroundTaskProcessing<IncomingData, ProcessStep>, BackgroundTaskIncomingDataProcessing>();
        })
        .Build()
        .Run();
}