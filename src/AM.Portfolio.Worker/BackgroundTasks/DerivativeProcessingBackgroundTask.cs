using AM.Portfolio.Core.Abstractions.Persistence;
using AM.Portfolio.Core.Domain.Persistence.Entities;
using AM.Portfolio.Core.Domain.Persistence.Entities.Catalogs;

using Net.Shared.Background.BackgroundTasks;
using Net.Shared.Background.Handlers;

namespace AM.Portfolio.Worker.BackgroundTasks;

public sealed class DerivativeProcessingBackgroundTask : ProcessingBackgroundTask<Derivative, ProcessStep>
{
    public DerivativeProcessingBackgroundTask(ILogger<DerivativeProcessingBackgroundTask> logger, IUnitOfWorkRepository unitOfWork)
        : base(logger, unitOfWork.Derivative, unitOfWork.ProcessStep, new BackgroundTaskStepHandler<Derivative>(new() { }))
    {
    }
}
