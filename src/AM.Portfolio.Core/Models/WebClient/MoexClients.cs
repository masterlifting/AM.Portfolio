namespace AM.Portfolio.Core.Models.WebClient;

public sealed record MoexIsinData(Securities Securities);
public sealed record Securities(object[][] Data);