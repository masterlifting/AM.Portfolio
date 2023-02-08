using AM.Portfolio.Core.Models.WebClient;

using static AM.Shared.Abstractions.Constants.Enums;

namespace AM.Portfolio.Core.Abstractions.WebServices;

public interface IMoexWebclient
{
    Task<MoexIsinData> GetIsinAsync(string ticker, Countries country);
    Task<MoexIsinData> GetIsinsAsync(Countries country);
}