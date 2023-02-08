using AM.Portfolio.Core.Abstractions.Persistence;
using AM.Portfolio.Core.Domain.Persistence.Collections;
using AM.Portfolio.Core.Domain.Persistence.Entities.Catalogs;
using AM.Portfolio.Core.Services.BcsServices.Interfaces;
using AM.Services.Portfolio.Worker.BackgroundTasksSteps;

using Net.Shared.Queues.Abstractions.Domain.WorkQueue;

using Shared.Background.Core.BackgroundTasks;
using Shared.Background.Core.Handlers;

using static AM.Portfolio.Core.Constants.Enums;

namespace AM.Portfolio.Worker.BackgroundTasks;

public sealed class BackgroundTaskIncomingDataProcessing : BackgroundTaskProcessing<IncomingData, ProcessStep>
{
    public BackgroundTaskIncomingDataProcessing(
        ILogger<BackgroundTaskIncomingDataProcessing> logger
        , IBcsReportService service
        , IUnitOfWorkRepository uow
        , IWorkQueue workQueue)
        : base(
            logger
            , uow.IncomingData
            , uow.ProcessStep
            , new BackgroundTaskStepHandler<IncomingData>(new()
                {
                    {(int)ProcessSteps.ParseBcsReport, new BcsReportParser(service, uow, workQueue)}
                }))
    { }
}
