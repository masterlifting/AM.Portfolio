using AM.Portfolio.Core.Abstractions.Persistence;
using AM.Portfolio.Core.Persistence.Entities.NoSql;
using AM.Portfolio.Core.Services.BcsServices.Interfaces;
using AM.Portfolio.Worker.Exceptions;
using Net.Shared.Background.Abstractions.Core;
using Net.Shared.Queues.Abstractions.Core.WorkQueue;

using static Net.Shared.Persistence.Models.Constants.Enums;

namespace AM.Portfolio.Worker.BackgroundTasksSteps;

public class BcsReportParser : IBackgroundTaskHandler<IncomingData>
{
    private readonly IUnitOfWorkRepository _uow;
    private readonly IWorkQueue _workQueue;
    private readonly IBcsReportService _service;
    public BcsReportParser(IBcsReportService service, IUnitOfWorkRepository uow, IWorkQueue workQueue)
    {
        _service = service;
        _uow = uow;
        _workQueue = workQueue;
    }

    public Task Handle(IEnumerable<IncomingData> entities, CancellationToken cToken) =>
        Task.WhenAll(entities.Select(x => Task.Run(async () =>
        {
            try
            {
                var reportModel = _service.GetReportModel(x.PayloadSource, x.Payload);

                var deals = await _service.GetDeals(x.UserId, reportModel.Agreement, reportModel.Deals, cToken);
                var events = await _service.GetEvents(x.UserId, reportModel.Agreement, reportModel.Events, cToken);

                await _workQueue.Process(async () =>
                {
                    try
                    {
                        await _uow.PostgreContext.StartTransaction(cToken);
                        await _uow.Deal.Writer.CreateMany(deals, cToken);
                        await _uow.Event.Writer.CreateMany(events, cToken);
                        await _uow.PostgreContext.CommitTransaction(cToken);
                    }
                    catch (Exception exeption)
                    {
                        await _uow.PostgreContext.RollbackTransaction(cToken);
                        throw new AmPortfolioWorkerException(exeption);
                    }
                });
            }
            catch (Exception exception)
            {
                x.ProcessStatusId = (int)ProcessStatuses.Error;
                x.Error = $"Source: {x.PayloadSource}. " + exception.Message;
            }
        }, cToken)));
    public Task<IReadOnlyCollection<IncomingData>> Handle(CancellationToken cToken)
    {
        throw new NotImplementedException();
    }
}
