using AM.Portfolio.Core.Abstractions.Persistence;
using AM.Portfolio.Core.Persistence.Entities.NoSql;
using AM.Portfolio.Core.Persistence.Entities.Sql.Catalogs;
using AM.Portfolio.Core.Services.BcsServices.Interfaces;
using AM.Portfolio.Worker.BackgroundTasksSteps;

using Net.Shared.Background.BackgroundTasks;
using Net.Shared.Background.Handlers;
using Net.Shared.Persistence.Abstractions.Entities;
using Net.Shared.Persistence.Abstractions.Entities.Catalogs;
using Net.Shared.Persistence.Abstractions.Repositories;
using Net.Shared.Queues.Abstractions.Domain.WorkQueue;

using static AM.Portfolio.Core.Constants.Enums;

namespace AM.Portfolio.Worker.BackgroundTasks;

public sealed class ProcessingIncomingDataBackgroundTask : ProcessingBackgroundTask
{
    public ProcessingIncomingDataBackgroundTask(
        ILogger<ProcessingIncomingDataBackgroundTask> logger
        , IPersistenceRepository<IncomingData> processRepository
        , IPersistenceRepository<ProcessStep> processStepRepository
        , IBcsReportService service
        , IUnitOfWorkRepository uow
        , IWorkQueue workQueue)
        : base(
            logger
            , (IPersistenceRepository<IPersistentProcess>)processRepository
            , (IPersistenceRepository<IPersistentProcessStep>)processStepRepository
            , (BackgroundTaskHandler<IPersistentProcess>) new BackgroundTaskHandler<IncomingData>(new()
                {
                    {new ProcessStep(), new BcsReportParser(service, uow, workQueue)}
                }))
    {
    }
}
