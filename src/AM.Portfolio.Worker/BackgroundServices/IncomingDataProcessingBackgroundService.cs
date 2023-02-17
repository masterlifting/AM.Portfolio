using AM.Portfolio.Worker.BackgroundTasks;

using Microsoft.Extensions.Options;

using Net.Shared.Background.BackgroundServices;
using Net.Shared.Background.Models.Settings;

namespace AM.Portfolio.Worker.BackgroundServices;

public sealed class IncomingDataProcessingBackgroundService : ProcessingBackgroundService<IncomingDataProcessingBackgroundTask>
{
    public IncomingDataProcessingBackgroundService(
        IServiceScopeFactory scopeFactory,
        IOptionsMonitor<BackgroundTaskSection> options,
        ILogger<IncomingDataProcessingBackgroundService> logger)
         : base(options, logger, scopeFactory) { }
}
