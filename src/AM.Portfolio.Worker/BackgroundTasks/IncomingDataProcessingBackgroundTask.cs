using AM.Portfolio.Core.Abstractions.Persistence;
using AM.Portfolio.Core.Persistence.Entities.NoSql;
using AM.Portfolio.Core.Persistence.Entities.Sql.Catalogs;
using AM.Portfolio.Core.Services.BcsServices.Interfaces;
using AM.Portfolio.Worker.BackgroundTasksSteps;

using Net.Shared.Background.BackgroundTasks;
using Net.Shared.Background.Handlers;
using Net.Shared.Persistence.Abstractions.Repositories;
using Net.Shared.Queues.Abstractions.Domain.WorkQueue;

using static AM.Portfolio.Core.Constants.Enums;

namespace AM.Portfolio.Worker.BackgroundTasks;

public sealed class IncomingDataProcessingBackgroundTask : ProcessingBackgroundTask
{
    public IncomingDataProcessingBackgroundTask(
        ILogger<IncomingDataProcessingBackgroundTask> logger
        , IPersistenceRepository<IncomingData> processRepository
        , IPersistenceRepository<ProcessStep> processStepRepository
        , IBcsReportService service
        , IUnitOfWorkRepository uow
        , IWorkQueue workQueue)
        : base( logger , processRepository, processStepRepository, new BackgroundTaskStepHandler(new()
                {
                    {(int)ProcessSteps.ParseBcsReport, new BcsReportParser(service, uow, workQueue)}
                }))
    { }
}
