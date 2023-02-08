using AM.Portfolio.Core.Domain.Persistence.Entities;
using AM.Portfolio.Core.Domain.Persistence.Entities.Catalogs;

using Microsoft.Extensions.Options;

using Shared.Background.Core.BackgroundServices;
using Shared.Background.Settings.Sections;

namespace AM.Portfolio.Worker.BackgroundServices;

public sealed class BackgroundServiceAssetProcessing : BackgroundServiceProcessing<Asset, ProcessStep>
{
    public BackgroundServiceAssetProcessing(
        IServiceScopeFactory scopeFactory,
        IOptionsMonitor<BackgroundTaskSection> options,
        ILogger<BackgroundServiceAssetProcessing> logger)
        : base(options, logger, scopeFactory) { }
}