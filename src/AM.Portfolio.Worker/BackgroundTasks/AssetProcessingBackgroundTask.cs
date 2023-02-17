using AM.Portfolio.Core.Abstractions.Persistence;
using AM.Portfolio.Core.Domain.Persistence.Entities;
using AM.Portfolio.Core.Domain.Persistence.Entities.Catalogs;

using Net.Shared.Background.BackgroundTasks;
using Net.Shared.Background.Handlers;

namespace AM.Portfolio.Worker.BackgroundTasks;

public sealed class AssetProcessingBackgroundTask : ProcessingBackgroundTask<Asset, ProcessStep>
{
    public AssetProcessingBackgroundTask(ILogger<AssetProcessingBackgroundTask> logger, IUnitOfWorkRepository unitOfWork)
        : base(logger, unitOfWork.Asset, unitOfWork.ProcessStep, new BackgroundTaskStepHandler<Asset>(new() { }))
    {
    }
}
