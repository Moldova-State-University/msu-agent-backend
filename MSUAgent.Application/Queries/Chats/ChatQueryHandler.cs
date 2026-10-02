using MediatR;
using MSUAgent.Application.Interfaces;
using MSUAgent.Application.Models.Results;

namespace MSUAgent.Application.Queries.Chats;

public sealed class ChatQueryHandler : IRequestHandler<ChatQuery, IResult<string>>
{
    private readonly IAiClient _aiClient;

    public ChatQueryHandler(IAiClient aiClient)
    {
        _aiClient = aiClient;
    }

    public async Task<IResult<string>> Handle(ChatQuery request, CancellationToken cancellationToken)
    {
        return await _aiClient.SendChatRequest(request.Message, cancellationToken);
    }
}