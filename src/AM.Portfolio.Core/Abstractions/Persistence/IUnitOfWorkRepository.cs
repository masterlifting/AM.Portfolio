﻿using AM.Portfolio.Core.Abstractions.Persistence.Repositories;

using Net.Shared.Persistence.Abstractions.Contexts;

namespace AM.Portfolio.Core.Abstractions.Persistence
{
    public interface IUnitOfWorkRepository
    {
        IPersistencePostgreContext PostgreContext { get; }
        IPersistenceMongoContext MongoContext { get; }

        IProcessStepRepository ProcessStep { get; }
        IIncomingDataRepository IncomingData { get; }
        IAssetRepository Asset { get; }
        IDealRepository Deal { get; }
        IEventRepository Event { get; }
        IDerivativeRepository Derivative { get; }
        IUserRepository User { get; }
        IAccountRepository Account { get; }
    }
}
