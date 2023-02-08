using Shared.Exceptions.Abstractions;
using Shared.Exceptions.Models;

namespace AM.Portfolio.Api.Exceptions;

public sealed class PortfolioAPIException : SharedException
{
    public PortfolioAPIException(string initiator, string action, ExceptionDescription description) : base(initiator, action, description) { }
}