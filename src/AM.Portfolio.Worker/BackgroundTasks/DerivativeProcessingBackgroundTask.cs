using AM.Portfolio.Core.Abstractions.Persistence;
using AM.Portfolio.Core.Persistence.Entities.Sql;
using AM.Portfolio.Core.Persistence.Entities.Sql.Catalogs;
using Net.Shared.Background.BackgroundTasks;
using Net.Shared.Background.Handlers;

namespace AM.Portfolio.Worker.BackgroundTasks;

public sealed class DerivativeProcessingBackgroundTask : ProcessingBackgroundTask<Derivative, ProcessStep>
{
    public DerivativeProcessingBackgroundTask(ILogger<DerivativeProcessingBackgroundTask> logger, IUnitOfWorkRepository unitOfWork)
        : base(logger, unitOfWork.Derivative, unitOfWork.ProcessStep, new BackgroundTaskHandler<Derivative>(new() { }))
    {
    }
}
