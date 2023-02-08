using Shared.Web.Settings.Connections;

namespace AM.Portfolio.Infrastructure.Settings;

public sealed class WebclientConnectionSection
{
    public const string Name = "WebclientConnections";
    public WebClientConnectionSettings Moex { get; set; } = null!;
}