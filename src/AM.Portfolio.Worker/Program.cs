using AM.Portfolio.Infrastructure;
using AM.Portfolio.Worker.BackgroundServices;
using AM.Portfolio.Worker.BackgroundTasks;

using Net.Shared.Background.Models.Settings;

namespace AM.Portfolio.Worker;

public static class Program
{
    public static void Main(string[] args) =>
        Host.CreateDefaultBuilder(args)
        .ConfigureServices((hostContext, services) =>
        {
            var configuration = hostContext.Configuration;

            services.AddPortfolioWorkerInfrastructureServices(configuration);

            services.Configure<BackgroundTaskSection>(configuration.GetSection(BackgroundTaskSection.Name));

            services.AddHostedService<ProcessingIncomingDataBackgroundService>();
            services.AddTransient<ProcessingIncomingDataBackgroundTask>();
        })
        .Build()
        .Run();
}
