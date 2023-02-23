using AM.Portfolio.Core.Abstractions.Persistence;
using AM.Portfolio.Core.Persistence.Entities.Sql;
using AM.Portfolio.Core.Persistence.Entities.Sql.Catalogs;
using Net.Shared.Background.BackgroundTasks;
using Net.Shared.Background.Handlers;

namespace AM.Portfolio.Worker.BackgroundTasks;

public sealed class AssetProcessingBackgroundTask : ProcessingBackgroundTask<Asset, ProcessStep>
{
    public AssetProcessingBackgroundTask(ILogger<AssetProcessingBackgroundTask> logger, IUnitOfWorkRepository unitOfWork)
        : base(logger, unitOfWork.Asset, unitOfWork.ProcessStep, new BackgroundTaskHandler<Asset>(new() { }))
    {
    }
}
