using AM.Portfolio.Core.Domain.Persistence.Entities;
using AM.Portfolio.Core.Domain.Persistence.Entities.Catalogs;

using Microsoft.Extensions.Options;

using Net.Shared.Background.BackgroundServices;
using Net.Shared.Background.Models.Settings;

namespace AM.Portfolio.Worker.BackgroundServices;

public sealed class AssetProcessingBackgroundService : ProcessingBackgroundService<Asset, ProcessStep>
{
    public AssetProcessingBackgroundService(
        IServiceScopeFactory scopeFactory,
        IOptionsMonitor<BackgroundTaskSection> options,
        ILogger<AssetProcessingBackgroundService> logger)
        : base(options, logger, scopeFactory) { }
}
