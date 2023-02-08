﻿using AM.Portfolio.Core.Abstractions.Persistence;
using AM.Portfolio.Core.Domain.Persistence.Entities;
using AM.Portfolio.Core.Domain.Persistence.Entities.Catalogs;

using Shared.Background.Core.BackgroundTasks;
using Shared.Background.Core.Handlers;

namespace AM.Portfolio.Worker.BackgroundTasks;

public sealed class BackgroundTaskDealProcessing : BackgroundTaskProcessing<Deal, ProcessStep>
{
    public BackgroundTaskDealProcessing(ILogger<BackgroundTaskDealProcessing> logger, IUnitOfWorkRepository unitOfWork)
        : base(logger, unitOfWork.Deal, unitOfWork.ProcessStep, new BackgroundTaskStepHandler<Deal>(new() { }))
    {
    }
}