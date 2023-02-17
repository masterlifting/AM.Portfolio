using AM.Portfolio.Infrastructure;
using AM.Portfolio.Worker.BackgroundServices;
using AM.Portfolio.Worker.BackgroundTasks;

using Net.Shared.Background.Models.Settings;

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

            services.AddHostedService<IncomingDataProcessingBackgroundService>();
            services.AddTransient<IncomingDataProcessingBackgroundTask>();
        })
        .Build()
        .Run();
}
