using AM.Portfolio.Worker.BackgroundTasks;

using Microsoft.Extensions.Options;

using Net.Shared.Background.BackgroundServices;
using Net.Shared.Background.Models.Settings;

namespace AM.Portfolio.Worker.BackgroundServices;

public sealed class ProcessingIncomingDataBackgroundService : ProcessingBackgroundService<ProcessingIncomingDataBackgroundTask>
{
    public ProcessingIncomingDataBackgroundService( IServiceScopeFactory scopeFactory, IOptionsMonitor<BackgroundTaskSection> options, ILogger<ProcessingIncomingDataBackgroundService> logger)
         : base(options, logger, scopeFactory) { }
}
