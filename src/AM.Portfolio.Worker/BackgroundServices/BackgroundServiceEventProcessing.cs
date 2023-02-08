using AM.Portfolio.Core.Domain.Persistence.Entities;
using AM.Portfolio.Core.Domain.Persistence.Entities.Catalogs;

using Microsoft.Extensions.Options;

using Shared.Background.Core.BackgroundServices;
using Shared.Background.Settings.Sections;
namespace AM.Portfolio.Worker.BackgroundServices;

public sealed class BackgroundServiceEventProcessing : BackgroundServiceProcessing<Event, ProcessStep>
{
    public BackgroundServiceEventProcessing(
        IServiceScopeFactory scopeFactory,
        IOptionsMonitor<BackgroundTaskSection> options,
        ILogger<BackgroundServiceEventProcessing> logger)
         : base(options, logger, scopeFactory) { }
}