using AM.Portfolio.Core.Persistence.Entities.Sql;
using AM.Portfolio.Core.Persistence.Entities.Sql.Catalogs;
using Microsoft.Extensions.Options;

using Net.Shared.Background.BackgroundServices;
using Net.Shared.Background.Models.Settings;
namespace AM.Portfolio.Worker.BackgroundServices;

public sealed class DerivativeProcessingBackgroundService : ProcessingBackgroundService<Derivative, ProcessStep>
{
    public DerivativeProcessingBackgroundService(
        IServiceScopeFactory scopeFactory,
        IOptionsMonitor<BackgroundTaskSection> options,
        ILogger<DerivativeProcessingBackgroundService> logger)
        : base(options, logger, scopeFactory) { }
}
