using AM.Portfolio.Core.Persistence.Entities.Sql;
using AM.Portfolio.Core.Persistence.Entities.Sql.Catalogs;
using Microsoft.Extensions.Options;

using Net.Shared.Background.BackgroundServices;
using Net.Shared.Background.Models.Settings;
namespace AM.Portfolio.Worker.BackgroundServices;

public sealed class EventProcessingBackgroundService : ProcessingBackgroundService<Event, ProcessStep>
{
    public EventProcessingBackgroundService(
        IServiceScopeFactory scopeFactory,
        IOptionsMonitor<BackgroundTaskSection> options,
        ILogger<EventProcessingBackgroundService> logger)
         : base(options, logger, scopeFactory) { }
}
