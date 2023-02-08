using AM.Portfolio.Core.Domain.Persistence.Entities;
using AM.Portfolio.Core.Domain.Persistence.Entities.Catalogs;

using Microsoft.Extensions.Options;

using Shared.Background.Core.BackgroundServices;
using Shared.Background.Settings.Sections;
namespace AM.Portfolio.Worker.BackgroundServices;

public sealed class BackgroundServiceDerivativeProcessing : BackgroundServiceProcessing<Derivative, ProcessStep>
{
    public BackgroundServiceDerivativeProcessing(
        IServiceScopeFactory scopeFactory,
        IOptionsMonitor<BackgroundTaskSection> options,
        ILogger<BackgroundServiceDerivativeProcessing> logger)
        : base(options, logger, scopeFactory) { }
}