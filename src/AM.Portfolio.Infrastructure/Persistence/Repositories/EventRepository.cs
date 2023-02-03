﻿using AM.Services.Portfolio.Core.Abstractions.Persistence.Repositories;
using AM.Services.Portfolio.Core.Domain.Persistence.Entities;

using Microsoft.Extensions.Logging;
using Shared.Persistence.Abstractions.Contexts;
using Shared.Persistence.Repositories;

namespace AM.Services.Portfolio.Infrastructure.Persistence.Repositories
{
    public sealed class EventRepository : PostgreRepository<Event>, IEventRepository
    {
        public EventRepository(ILogger<Event> logger, IPostgrePersistenceContext context) : base(logger, context)
        {
        }
    }
}
