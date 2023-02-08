using AM.Portfolio.Core.Domain.Persistence.Collections;
using AM.Portfolio.Core.Domain.Persistence.Entities.Catalogs;

using Microsoft.Extensions.Options;

using Shared.Background.Core.BackgroundServices;
using Shared.Background.Settings.Sections;

namespace AM.Portfolio.Worker.BackgroundServices;

public sealed class BackgroundServiceIncomingDataProcessing : BackgroundServiceProcessing<IncomingData, ProcessStep>
{
    public BackgroundServiceIncomingDataProcessing(
        IServiceScopeFactory scopeFactory,
        IOptionsMonitor<BackgroundTaskSection> options,
        ILogger<BackgroundServiceIncomingDataProcessing> logger)
         : base(options, logger, scopeFactory) { }
}