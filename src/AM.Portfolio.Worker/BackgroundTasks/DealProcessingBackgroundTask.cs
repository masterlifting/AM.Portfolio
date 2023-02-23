using AM.Portfolio.Core.Abstractions.Persistence;

using Net.Shared.Background.BackgroundTasks;
using Net.Shared.Background.Handlers;

namespace AM.Portfolio.Worker.BackgroundTasks;

public sealed class DealProcessingBackgroundTask : ProcessingBackgroundTask
{
    public DealProcessingBackgroundTask(ILogger<DealProcessingBackgroundTask> logger, IUnitOfWorkRepository unitOfWork)
        : base(logger, unitOfWork.Deal, unitOfWork.ProcessStep, new BackgroundTaskHandler(new() { }))
    {
    }
}
