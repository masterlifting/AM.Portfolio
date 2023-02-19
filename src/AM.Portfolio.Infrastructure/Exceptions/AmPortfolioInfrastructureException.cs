using Net.Shared.Exceptions;

namespace AM.Portfolio.Infrastructure.Exceptions;

public sealed class AmPortfolioInfrastructureException : NetSharedException
{
    public AmPortfolioInfrastructureException(string message) : base(message)
    {
    }

    public AmPortfolioInfrastructureException(Exception exception) : base(exception)
    {
    }
}
