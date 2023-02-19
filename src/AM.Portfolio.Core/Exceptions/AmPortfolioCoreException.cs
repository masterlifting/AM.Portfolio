using Net.Shared.Exceptions;

namespace AM.Portfolio.Core.Exceptions;

public sealed class AmPortfolioCoreException : NetSharedException
{
    public AmPortfolioCoreException(string message) : base(message)
    {
    }

    public AmPortfolioCoreException(Exception exception) : base(exception)
    {
    }
}
