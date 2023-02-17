using AM.Portfolio.Core.Abstractions.Persistence;
using AM.Portfolio.Core.Services.BcsServices.Interfaces;
using AM.Portfolio.Worker.BackgroundTasksSteps;

using Net.Shared.Background.BackgroundTasks;
using Net.Shared.Background.Handlers;
using Net.Shared.Queues.Abstractions.Domain.WorkQueue;

using static AM.Portfolio.Core.Constants.Enums;

namespace AM.Portfolio.Worker.BackgroundTasks;

public sealed class IncomingDataProcessingBackgroundTask : ProcessingBackgroundTask
{
    public IncomingDataProcessingBackgroundTask(
        ILogger<IncomingDataProcessingBackgroundTask> logger
        , IBcsReportService service
        , IUnitOfWorkRepository uow
        , IWorkQueue workQueue)
        : base(
            logger
            , uow.IncomingData
            , uow.ProcessStep
            , new BackgroundTaskStepHandler(new()
                {
                    {(int)ProcessSteps.ParseBcsReport, new BcsReportParser(service, uow, workQueue)}
                }))
    { }
}
