using Net.Shared.Exceptions;

namespace AM.Portfolio.Worker.Exceptions;

public sealed class AmPortfolioWorkerException : NetSharedException
{
    public AmPortfolioWorkerException(string message) : base(message)
    {
    }

    public AmPortfolioWorkerException(Exception exception) : base(exception)
    {
    }
}
