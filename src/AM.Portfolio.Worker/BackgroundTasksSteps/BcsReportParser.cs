﻿using System.Collections.Generic;

using AM.Portfolio.Core.Abstractions.Persistence;
using AM.Portfolio.Core.Domain.Persistence.Collections;
using AM.Portfolio.Core.Services.BcsServices.Interfaces;
using AM.Portfolio.Worker.Exceptions;

using Net.Shared.Background.Abstractions.Interfaces;
using Net.Shared.Persistence.Abstractions.Entities;
using Net.Shared.Queues.Abstractions.Domain.WorkQueue;

using static Net.Shared.Persistence.Abstractions.Constants.Enums;

namespace AM.Portfolio.Worker.BackgroundTasksSteps;

public class BcsReportParser : IProcessStepHandler
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

    public Task HandleStepAsync(IEnumerable<IPersistentProcess> entities, CancellationToken cToken) => HandleAsync((IEnumerable<IncomingData>)entities, cToken);
    public Task<IReadOnlyCollection<IPersistentProcess>> HandleStepAsync(CancellationToken cToken) => HandleAsync(cToken);

    private Task HandleAsync(IEnumerable<IncomingData> entities, CancellationToken cToken) =>
        Task.WhenAll(entities.Select(x => Task.Run(async () =>
        {
            try
            {
                var reportModel = _service.GetReportModel(x.PayloadSource, x.Payload);

                var deals = await _service.GetDealsAsync(x.UserId, reportModel.Agreement, reportModel.Deals, cToken);
                var events = await _service.GetEventsAsync(x.UserId, reportModel.Agreement, reportModel.Events, cToken);

                await _workQueue.ProcessAsync(async () =>
                {
                    try
                    {
                        await _uow.PostgreContext.StartTransactionAsync(cToken);
                        await _uow.Deal.Writer.CreateManyAsync(deals, cToken);
                        await _uow.Event.Writer.CreateManyAsync(events, cToken);
                        await _uow.PostgreContext.CommitTransactionAsync(cToken);
                    }
                    catch (Exception exeption)
                    {
                        await _uow.PostgreContext.RollbackTransactionAsync(cToken);
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
    private async Task<IReadOnlyCollection<IPersistentProcess>> HandleAsync(CancellationToken cToken)
    {
        return new List<IncomingData>().AsReadOnly();
    }
}
