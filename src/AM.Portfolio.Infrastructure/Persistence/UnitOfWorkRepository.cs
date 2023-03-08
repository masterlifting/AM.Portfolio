using AM.Portfolio.Core.Abstractions.Persistence;
using AM.Portfolio.Core.Abstractions.Persistence.Repositories;
using Net.Shared.Persistence.Abstractions.Core.Contexts;

namespace AM.Portfolio.Infrastructure.Persistence
{
    public sealed class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        private readonly Lazy<IPersistencePostgreContext> _postgreContext;
        private readonly Lazy<IPersistenceMongoContext> _mongoContext;
        private readonly Lazy<IProcessStepRepository> _processStep;
        private readonly Lazy<IIncomingDataRepository> _incomingData;
        private readonly Lazy<IAssetRepository> _asset;
        private readonly Lazy<IDealRepository> _deal;
        private readonly Lazy<IEventRepository> _event;
        private readonly Lazy<IDerivativeRepository> _derivative;
        private readonly Lazy<IUserRepository> _user;
        private readonly Lazy<IAccountRepository> _account;

        public UnitOfWorkRepository(
            Lazy<IPersistencePostgreContext> postgreContext,
            Lazy<IPersistenceMongoContext> mongoContext,
            Lazy<IProcessStepRepository> processStep,
            Lazy<IIncomingDataRepository> incomingData,
            Lazy<IAssetRepository> asset,
            Lazy<IDealRepository> deal,
            Lazy<IEventRepository> _event,
            Lazy<IDerivativeRepository> derivative,
            Lazy<IUserRepository> user,
            Lazy<IAccountRepository> account)
        {
            _postgreContext = postgreContext;
            _mongoContext = mongoContext;
            _processStep = processStep;
            _incomingData = incomingData;
            _asset = asset;
            _deal = deal;
            this._event = _event;
            _derivative = derivative;
            _user = user;
            _account = account;
        }

        public IPersistencePostgreContext PostgreContext { get => _postgreContext.Value; }
        public IPersistenceMongoContext MongoContext { get => _mongoContext.Value; }

        public IProcessStepRepository ProcessStep { get => _processStep.Value; }
        public IIncomingDataRepository IncomingData { get => _incomingData.Value; }
        public IAssetRepository Asset { get => _asset.Value; }
        public IDealRepository Deal { get => _deal.Value; }
        public IEventRepository Event { get => _event.Value; }
        public IDerivativeRepository Derivative { get => _derivative.Value; }
        public IUserRepository User { get => _user.Value; }
        public IAccountRepository Account { get => _account.Value; }
    }
}
