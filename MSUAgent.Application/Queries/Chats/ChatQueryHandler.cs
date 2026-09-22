using MediatR;
using MSUAgent.Application.Interfaces;

namespace MSUAgent.Application.Queries.Chats;

public sealed class ChatQueryHandler : IRequestHandler<ChatQuery, string>
{
    private readonly IAiClient _aiClient;

    public ChatQueryHandler(IAiClient aiClient)
    {
        _aiClient = aiClient;
    }

    public async Task<string> Handle(ChatQuery request, CancellationToken cancellationToken)
    {
        return await _aiClient.SendChatRequest(request.Message, cancellationToken);
    }
}