using static AM.Shared.Abstractions.Constants.Enums;
using static AM.Portfolio.Core.Constants.Enums;

namespace AM.Portfolio.Core.Services.BcsServices.Models;

public sealed record BcsReportEventModel
{
    public string Asset { get; init; } = null!;
    public decimal Value { get; init; }
    public DateTime Date { get; init; }
    public EventTypes EventType { get; init; } = 0;
    public Exchanges Exchange { get; init; } = 0;
    public string? Info { get; init; } = null!;
}