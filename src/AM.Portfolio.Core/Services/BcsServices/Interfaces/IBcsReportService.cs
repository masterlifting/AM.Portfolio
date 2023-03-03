using AM.Portfolio.Core.Persistence.Entities.Sql;
using AM.Portfolio.Core.Services.BcsServices.Models;

namespace AM.Portfolio.Core.Services.BcsServices.Interfaces;

public interface IBcsReportService
{
    BcsReportModel GetReportModel(string fileName, byte[] payload);
    Task<Deal[]> GetDeals(Guid userId, string agreement, IList<BcsReportDealModel> models, CancellationToken cToken = default);
    Task<Event[]> GetEvents(Guid userId, string agreement, IList<BcsReportEventModel> models, CancellationToken cToken = default);
}
