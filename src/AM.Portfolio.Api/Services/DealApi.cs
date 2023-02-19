using AM.Portfolio.Api.Models;
using AM.Portfolio.Core.Persistence.Entities.Sql;
using Shared.Models.Pagination;
using Shared.Models.Results;

using System;
using System.Threading.Tasks;

namespace AM.Portfolio.Api.Services;

public sealed class DealApi
{
    public Task<PaginatedResult<DealGetDto>> GetAsync(string companyId, Paginator<Deal> paginator)
    {
        throw new NotImplementedException();
    }
    public Task<PaginatedResult<DealGetDto>> GetAsync(Paginator<Deal> paginator)
    {
        throw new NotImplementedException();
    }
}