using AM.Portfolio.Core.Abstractions.Persistence;
using AM.Portfolio.Core.Persistence.Entities.Sql;
using AM.Portfolio.Core.Persistence.Entities.Sql.Catalogs;
using Net.Shared.Background.BackgroundTasks;
using Net.Shared.Background.Handlers;

namespace AM.Portfolio.Worker.BackgroundTasks;

public sealed class EventProcessingBackgroundTask : ProcessingBackgroundTask<Event, ProcessStep>
{
    public EventProcessingBackgroundTask(ILogger<EventProcessingBackgroundTask> logger, IUnitOfWorkRepository unitOfWork)
        : base(logger, unitOfWork.Event, unitOfWork.ProcessStep, new BackgroundTaskHandler<Event>(new() { }))
    {
    }
}
