namespace AM.Portfolio.Core.Models.RabbitMq;

public sealed record ProviderReportDto(string Name, string ContentType, byte[] Payload, string UserId);