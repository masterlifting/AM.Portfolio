﻿using Net.Shared.Persistence.Models.Settings.Connections;

namespace AM.Portfolio.Infrastructure.Settings;

public sealed class DatabaseConnectionSection
{
    public const string Name = "DatabaseConnections";
    public PostgreSQLConnectionSettings PostgreSQL { get; set; } = null!;
    public MongoDBConnectionSettings MongoDB { get; set; } = null!;
}
