using MSUAgent.Application.Models.Results;

namespace MSUAgent.Application.Interfaces;

public interface IAiClient
{
    Task<IResult<string>> SendChatRequest(string message, CancellationToken cancellationToken);
}