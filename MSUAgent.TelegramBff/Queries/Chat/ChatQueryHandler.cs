using MediatR;
using MSUAgent.TelegramBff.Clients;

namespace MSUAgent.TelegramBff.Queries.Chat;

public sealed class ChatQueryHandler : IRequestHandler<ChatQuery, string>
{
    private readonly IMSUAgentClient _msuAgentClient;

    public ChatQueryHandler(IMSUAgentClient msuAgentClient)
    {
        _msuAgentClient = msuAgentClient;
    }

    public async Task<string> Handle(ChatQuery request, CancellationToken cancellationToken)
    {
        var response = await _msuAgentClient.SendChatRequest(request.Message, cancellationToken);

        return $"{response}";
    }
}