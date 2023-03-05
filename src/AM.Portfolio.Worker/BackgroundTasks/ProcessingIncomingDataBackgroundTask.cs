using AM.Portfolio.Core.Abstractions.Persistence;
using AM.Portfolio.Core.Persistence.Entities.NoSql;
using AM.Portfolio.Core.Persistence.Entities.Sql.Catalogs;
using AM.Portfolio.Core.Services.BcsServices.Interfaces;
using AM.Portfolio.Worker.BackgroundTasksSteps;

using Net.Shared.Background.BackgroundTasks;
using Net.Shared.Background.Handlers;
using Net.Shared.Queues.Abstractions.Core.WorkQueue;

using static AM.Portfolio.Core.Constants.Enums;

namespace AM.Portfolio.Worker.BackgroundTasks;

public sealed class ProcessingIncomingDataBackgroundTask : ProcessingBackgroundTask<IncomingData, ProcessStep>
{
    public ProcessingIncomingDataBackgroundTask(
        ILogger<ProcessingIncomingDataBackgroundTask> logger,
        IUnitOfWorkRepository uow,
        IBcsReportService service,
        IWorkQueue workQueue) : base(logger, uow.IncomingData, uow.ProcessStep,
            new BackgroundTaskHandler<IncomingData>(new()
            {
                {(int)ProcessSteps.ParseBcsReport, new BcsReportParser(service, uow, workQueue)}
            }))
    {
    }
}
