using AM.Portfolio.Core.Abstractions.Persistence;
using AM.Portfolio.Core.Domain.Persistence.Entities;
using AM.Portfolio.Core.Domain.Persistence.Entities.Catalogs;

using Net.Shared.Background.BackgroundTasks;
using Net.Shared.Background.Handlers;

namespace AM.Portfolio.Worker.BackgroundTasks;

public sealed class EventProcessingBackgroundTask : ProcessingBackgroundTask<Event, ProcessStep>
{
    public EventProcessingBackgroundTask(ILogger<EventProcessingBackgroundTask> logger, IUnitOfWorkRepository unitOfWork)
        : base(logger, unitOfWork.Event, unitOfWork.ProcessStep, new BackgroundTaskStepHandler<Event>(new() { }))
    {
    }
}
