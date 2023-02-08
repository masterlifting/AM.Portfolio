using AM.Portfolio.Core.Domain.Persistence.Collections;

using Microsoft.AspNetCore.Http;

using Shared.Models.Results;

using System;
using System.Threading.Tasks;

namespace AM.Portfolio.Api.Services.Interfaces
{
    public interface IReportApi
    {
        Task<TryResult<IncomingData[]>> TrySaveFilesAsync(Guid userId, int stepId, IFormFileCollection files);
    }
}
