using AM.Portfolio.Api.Models;
using AM.Portfolio.Core.Persistence.Entities.Sql;
using Shared.Models.Pagination;
using Shared.Models.Results;

using System;
using System.Threading.Tasks;

namespace AM.Portfolio.Api.Services;

public sealed class EventApi
{
    public Task<PaginatedResult<EventGetDto>> GetAsync(string companyId, Paginator<Event> paginator)
    {
        throw new NotImplementedException();
    }
    public Task<PaginatedResult<EventGetDto>> GetAsync(Paginator<Event> paginator)
    {
        throw new NotImplementedException();
    }
}