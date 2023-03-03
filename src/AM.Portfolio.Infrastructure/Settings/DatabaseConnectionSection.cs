using Net.Shared.Persistence.Models.Settings.Connections;

namespace AM.Portfolio.Infrastructure.Settings;

public sealed class DatabaseConnectionSection
{
    public const string Name = "DatabaseConnections";
    public PostgreConnectionSettings PostgreSQL { get; set; } = null!;
    public MongoConnectionSettings MongoDB { get; set; } = null!;
}
