using AM.Portfolio.Core.Domain.Persistence.Entities;
using AM.Portfolio.Core.Domain.Persistence.Entities.Catalogs;

using Microsoft.Extensions.Options;

using Net.Shared.Background.BackgroundServices;
using Net.Shared.Background.Models.Settings;
namespace AM.Portfolio.Worker.BackgroundServices;

public sealed class DealProcessingBackgroundService : ProcessingBackgroundService<Deal, ProcessStep>
{
    public DealProcessingBackgroundService(
        IServiceScopeFactory scopeFactory,
        IOptionsMonitor<BackgroundTaskSection> options,
        ILogger<DealProcessingBackgroundService> logger)
         : base(options, logger, scopeFactory) { }
}
